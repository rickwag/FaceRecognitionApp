using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Emgu.CV;
using Emgu.CV.Structure;

using static Emgu.CV.Face.FaceRecognizer;

namespace FaceRecognitionApp.Services
{
    public interface IFaceRecognitionService
    {
        public EventHandler SavedTrainingImagesEvent { get; set; }

        public void InitialiseTimer(Action<object, EventArgs> onTimerTick);
        public Image<Bgr, Byte> CaptureVideo();
        public System.Drawing.Rectangle[] DetectFaces(Image<Bgr, Byte> currentFrame);
        public Image<Bgr, Byte> DrawRectangleOnDetectedFaces(System.Drawing.Rectangle[] faces, Image<Bgr, Byte> currentFrame, Bgr color);
        public Task StoreTrainingImages(string studentName, System.Drawing.Rectangle face, Image<Bgr, Byte> currentFrame, int numberOfImages);
        public void Train();
        public Dictionary<System.Drawing.Rectangle, PredictionResult> RecognizeFaces(System.Drawing.Rectangle[] faces, Image<Bgr, Byte> currentFrame);
        public int CheckIfKnowFace(PredictionResult result);
        public Image<Bgr, Byte> IndicateFacePredictionResults(Dictionary<System.Drawing.Rectangle, PredictionResult> predictionResults, Image<Bgr, Byte> currentFrame);
        public Image<Bgr, Byte> GetRegionOfInterest(Image<Bgr, Byte> currentFrame, System.Drawing.Rectangle face);
    }
}
