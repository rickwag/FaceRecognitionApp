using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Input;

using Emgu.CV;
using Emgu.CV.Face;
using Emgu.CV.Structure;

using FaceRecognitionApp.Commands;
using FaceRecognitionApp.Models;
using FaceRecognitionApp.Services;
using FaceRecognitionApp.Stores;

namespace FaceRecognitionApp.ViewModels
{
    public class MarkAttendanceViewModel : BaseViewModel
    {
        #region fields
        private Image<Bgr, Byte> currentFrame = null;
        private Image<Bgr, Byte> currentFrameROI = null;
        private Rectangle[] faces = null;
        private IDBService dBService;
        #endregion


        public IFaceRecognitionService FaceRecognitionServ { get; set; }
        public Image<Bgr, Byte> CurrentFrame
        {
            get { return currentFrame; }
            set
            {
                currentFrame = value;

                OnPropertyChanged(nameof(CurrentFrame));
            }
        }

        public Image<Bgr, Byte> CurrentFrameROI
        {
            get { return currentFrameROI; }
            set
            {
                currentFrameROI = value;

                OnPropertyChanged(nameof(CurrentFrameROI));
            }
        }
        public bool HasDetectedFaces => faces.Length > 0;
        public ObservableCollection<AttendanceEntry> AttendanceEntries { get; set; }
        public ICommand NavigateToDashBoard { get; set; }
        public ICommand PrintToExcelCommand { get; set; }

        public MarkAttendanceViewModel(NavigationStore navigationStore, IDBService _dBService)
        {
            NavigateToDashBoard = new NavigateCommand(() => navigationStore.CurrentViewModel = new DashBoardViewModel(navigationStore, _dBService));
            PrintToExcelCommand = new PrintToExcelCommand(this, new SpreadSheetService());

            dBService = _dBService;

            AttendanceEntries = new();

            FaceRecognitionServ = new FaceRecognitionService(_dBService);

            FaceRecognitionServ.InitialiseTimer(OnTimerTick);
        }

        private async void OnTimerTick(object arg1, EventArgs arg2)
        {
            CurrentFrame = FaceRecognitionServ.CaptureVideo();

            faces = FaceRecognitionServ.DetectFaces(CurrentFrame);

            //CurrentFrame = FaceRecognitionServ.DrawRectangleOnDetectedFaces(faces, CurrentFrame, new Bgr(0, 100, 255));

            var hasDetectedFaces = faces.Length > 0;

            if (hasDetectedFaces)
            {
                CurrentFrameROI = FaceRecognitionServ.GetRegionOfInterest(currentFrame, faces[0]);

                var predictionResults = FaceRecognitionServ.RecognizeFaces(faces, CurrentFrame);

                MarkAttendance(predictionResults.Values);

                CurrentFrame = FaceRecognitionServ.IndicateFacePredictionResults(predictionResults, CurrentFrame);
            }
        }

        private void MarkAttendance(Dictionary<Rectangle, FaceRecognizer.PredictionResult>.ValueCollection values)
        {
            foreach (var result in values)
            {
                if (FaceRecognitionServ.CheckIfKnowFace(result) == -1) //if doesn't know the face, pass
                    continue;

                var student = dBService.GetStudent(result.Label);

                //check if student has already been added to attendance
                if (CheckIfAttendanceExists(student.ID)) continue;

                var attendanceEntry = new AttendanceEntry()
                {
                    Student = student,
                    AttendanceDateTime = DateTime.Now,
                    Lecture = dBService.GetLecture(student.LectureID)
                };

                AttendanceEntries.Add(attendanceEntry);

                dBService.AddAttendance(attendanceEntry);
            }
        }

        private bool CheckIfAttendanceExists(int studentID)
        {
            foreach (var attendanceEntry in AttendanceEntries)
            {
                if (attendanceEntry.Student.ID == studentID)
                    return true;
            }

            return false;
        }


        public IList<AttendanceEntry> GetAttendanceEntries()
        {
            var attendanceEntries = new List<AttendanceEntry>();

            if (AttendanceEntries == null) return attendanceEntries;

            foreach (var entry in AttendanceEntries)
            {
                attendanceEntries.Add(entry);
            }

            return attendanceEntries;
        }

        public override void Dispose()
        {
            FaceRecognitionServ.StopCaptureVideo();
        }
    }
}
