using System;
using System.Drawing;
using System.Windows;
using System.Windows.Input;

using Emgu.CV;
using Emgu.CV.Structure;

using FaceRecognitionApp.Commands;
using FaceRecognitionApp.Models;
using FaceRecognitionApp.Services;
using FaceRecognitionApp.Stores;

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
        private IDialogService dialogService = new DialogService();
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
        public ICommand NavigateToDashBoard { get; set; }
        public bool HasDetectedFaces => faces.Length > 0;
        public ProgressViewModel ProgViewModel { get; set; } = new ProgressViewModel();
        #endregion

        public RegisterStudentViewModel(NavigationStore navigationStore, IDBService _dBService, Lecture lecture)
        {
            NewStudent.Lecture = lecture;

            NavigateToDashBoard = new NavigateCommand(() => navigationStore.CurrentViewModel = new DashBoardViewModel(navigationStore, _dBService));

            dBService = _dBService;

            AddNewStudentCommand = new AddNewStudentCommand(this, dBService, dialogService);

            FaceRecognitionServ = new FaceRecognitionService(_dBService);

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
                    FaceRecognitionServ.StoreTrainingImages(currentStudentID.ToString(), CurrentFrame, numberOfImagesToStore, ProgViewModel);

                    canStoreTrainingImages = false;
                }
            }
        }


        public void SaveTrainingImages(int studentID)
        {
            canStoreTrainingImages = true;
            currentStudentID = studentID;

            ProgViewModel.ProgressValue = 40;
            ProgViewModel.Info = "saving training images...";
        }

        private void OnSavedTrainingImages(object sender, EventArgs e)
        {
            ProgViewModel.Info = "training...";

            //train just after saving
            FaceRecognitionServ.Train();

            dialogService.CloseDialog(nameof(ProgressViewModel));

            MessageBox.Show($"successfully added {NewStudent.FullName} with registration number {NewStudent.RegNumber}.", "adding new student", MessageBoxButton.OK, MessageBoxImage.Information);

            NavigateToDashBoard.Execute(null);
        }

        public override void Dispose()
        {
            FaceRecognitionServ.StopCaptureVideo();
        }
    }
}
