using System;
using System.Drawing;

using Emgu.CV;
using Emgu.CV.Structure;

using FaceRecognitionApp.Services;

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

        public MarkAttendanceViewModel(IDBService _dBService, IFaceRecognitionService _faceRecognitionService)
        {
            dBService = _dBService;

            FaceRecognitionServ = _faceRecognitionService;

            FaceRecognitionServ.InitialiseTimer(OnTimerTick);
        }

        private void OnTimerTick(object arg1, EventArgs arg2)
        {
            CurrentFrame = FaceRecognitionServ.CaptureVideo();

            faces = FaceRecognitionServ.DetectFaces(CurrentFrame);

            CurrentFrame = FaceRecognitionServ.DrawRectangleOnDetectedFaces(faces, CurrentFrame, new Bgr(0, 100, 255));

            var hasDetectedFaces = faces.Length > 0;

            if (hasDetectedFaces)
            {
                CurrentFrameROI = FaceRecognitionServ.GetRegionOfInterest(currentFrame, faces[0]);

                var predictionResults = FaceRecognitionServ.RecognizeFaces(faces, CurrentFrame);

                CurrentFrame = FaceRecognitionServ.IndicateFacePredictionResults(predictionResults, CurrentFrame);
            }
        }
    }
}
