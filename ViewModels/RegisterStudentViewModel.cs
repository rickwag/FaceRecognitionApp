using System;
using System.Drawing;
using System.Windows;
using System.Windows.Input;

using Emgu.CV;
using Emgu.CV.Structure;

using FaceRecognitionApp.Commands;
using FaceRecognitionApp.Models;
using FaceRecognitionApp.Services;

namespace FaceRecognitionApp.ViewModels
{
    public class RegisterStudentViewModel : BaseViewModel
    {
        #region fields
        private Image<Bgr, Byte> currentFrame = null;
        private Image<Bgr, Byte> currentFrameROI = null;
        private Rectangle[] faces = null;
        private IDBService dBService;
        private int numberOfImagesToStore = 60;
        private bool canStoreTrainingImages = false;
        private int currentStudentID = -1;
        #endregion

        #region properties
        public Student NewStudent { get; set; } = new();

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

        public ICommand AddNewStudentCommand { get; set; }
        public bool HasDetectedFaces => faces.Length > 0;
        #endregion

        public RegisterStudentViewModel(IDBService _dBService, IFaceRecognitionService _faceRecognitionService)
        {
            dBService = _dBService;

            AddNewStudentCommand = new AddNewStudentCommand(this, dBService);

            FaceRecognitionServ = _faceRecognitionService;

            FaceRecognitionServ.InitialiseTimer(OnTimerTick);

            FaceRecognitionServ.SavedTrainingImagesEvent += OnSavedTrainingImages;
        }

        public void OnTimerTick(object sender, EventArgs eventArgs)
        {
            CurrentFrame = FaceRecognitionServ.CaptureVideo();

            faces = FaceRecognitionServ.DetectFaces(CurrentFrame);

            CurrentFrame = FaceRecognitionServ.DrawRectangleOnDetectedFaces(faces, CurrentFrame, new Bgr(0, 100, 255));

            var hasDetectedFaces = faces.Length > 0;

            if (hasDetectedFaces)
            {
                CurrentFrameROI = FaceRecognitionServ.GetRegionOfInterest(currentFrame, faces[0]);

                if (canStoreTrainingImages)
                {
                    var firstFace = faces[0];
                    FaceRecognitionServ.StoreTrainingImages(currentStudentID.ToString(), firstFace, CurrentFrame, numberOfImagesToStore);

                    canStoreTrainingImages = false;
                }
            }
        }


        public void SaveTrainingImages(int studentID)
        {
            canStoreTrainingImages = true;
            currentStudentID = studentID;
        }

        private void OnSavedTrainingImages(object sender, EventArgs e)
        {
            //train just after saving
            FaceRecognitionServ.Train();

            MessageBox.Show($"successfully added {NewStudent.FullName} with registration number {NewStudent.RegNumber}.", "adding new student", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
