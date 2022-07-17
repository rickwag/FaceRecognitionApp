using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Threading;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;

using FaceRecognitionApp.ViewModels;

using Newtonsoft.Json;

namespace FaceRecognitionApp.Services
{
    public class FaceRecognitionService : IFaceRecognitionService
    {
        private DispatcherTimer timer = null;
        private VideoCapture videoCapture;

        private CascadeClassifier cascadeClassifier = new CascadeClassifier("haarcascade_frontalface_alt2.xml");

        private string mainDirPath = Directory.GetCurrentDirectory() + @"\TrainingImages";
        private int totalImageSaveTime = 10; //seconds

        private List<Mat> trainingImages = new();
        private List<int> trainingImagesLabels = new();

        private EventHandler savedTrainingImagesEvent;
        private IDBService dBService;

        public EventHandler SavedTrainingImagesEvent { get => savedTrainingImagesEvent; set => savedTrainingImagesEvent = value; }
        public Rectangle[] DetectedFaces { get; set; } 

        public FaceRecognitionService(IDBService _dBService)
        {
            dBService = _dBService;

            videoCapture = new VideoCapture();
        }
        

        public void InitialiseTimer(Action<object, EventArgs> timer_tick)
        {
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_tick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timer.Start();
        }

        public Image<Bgr, byte> CaptureVideo()
        {
            return videoCapture.QueryFrame().ToImage<Bgr, Byte>();
        }

        public void StopCaptureVideo()
        {
            timer.Stop();
            videoCapture.Dispose();
        }

        public Rectangle[] DetectFaces(Image<Bgr, byte> currentFrame)
        {
            //convert to gray image for detection
            Image<Gray, Byte> grayImage = currentFrame.Convert<Gray, Byte>();

            var faces = cascadeClassifier.DetectMultiScale(grayImage, 1.3, 3, System.Drawing.Size.Empty, System.Drawing.Size.Empty);

            DetectedFaces = faces;

            return faces;
        }

        public Image<Bgr, Byte> DrawRectangleOnDetectedFaces(Rectangle[] faces, Image<Bgr, byte> currentFrame, Bgr color)
        {
            var recThickness = 2;

            foreach (var face in faces)
            {
                CvInvoke.Rectangle(currentFrame, face, color.MCvScalar, recThickness);
            }

            return currentFrame;
        }

        public async Task StoreTrainingImages(string studentName, Image<Bgr, byte> currentFrame, int numberOfImages, ProgressViewModel progressViewModel)
        {
            var path = mainDirPath + @"\" + studentName;
            //create new if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            //save the images on a separate thread to avoid freezes
            await Task.Factory.StartNew(() =>
            {
                var count = 0;
                while (count < numberOfImages)
                {
                    try
                    {
                        var face = DetectedFaces[0];

                        var roiImage = GetRegionOfInterest(currentFrame, face);
                        var savePath = path + @"\" + (count + 1) + ".jpg";
                        roiImage.Resize(200, 200, Inter.Cubic).Save(savePath);

                        progressViewModel.ProgressValue += 1;

                        //wait before saving again
                        var delay = (int)MathF.Ceiling(((float)totalImageSaveTime / (float)numberOfImages * 1000));
                        Thread.Sleep(delay);

                        count++;
                    }
                    catch (IndexOutOfRangeException)
                    {

                        
                    }
                }
            });

            SavedTrainingImagesEvent?.Invoke(this, EventArgs.Empty);
        }

        public void Train()
        {
            //training
            //get all image files from directory 
            string[] files = Directory.GetFiles(mainDirPath, "*.jpg", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                //create grayscale image
                Image<Gray, Byte> trainingImage = new Image<Gray, byte>(file);

                var fileSplits = file.Split("\\");
                var studentLabel = fileSplits[fileSplits.Length - 2]; //get directory name

                trainingImages.Add(trainingImage.Mat);

                var id = Int32.Parse(studentLabel);

                trainingImagesLabels.Add(id);
            }

            var faceRecognizer = new LBPHFaceRecognizer();
            faceRecognizer.Train(trainingImages.ToArray(), trainingImagesLabels.ToArray());
            faceRecognizer.Write("trainner.yml");
        }

        

        public Dictionary<Rectangle, FaceRecognizer.PredictionResult> RecognizeFaces(Rectangle[] faces, Image<Bgr, byte> currentFrame)
        {
            var predictionResults = new Dictionary<Rectangle, FaceRecognizer.PredictionResult>();

            foreach (var face in faces)
            {
                //set region of interest to recognize
                var roiImage = currentFrame.Convert<Bgr, Byte>();
                roiImage.ROI = face;

                var faceRecognizer = new LBPHFaceRecognizer();
                faceRecognizer.Read(Directory.GetCurrentDirectory() + @"\" + "trainner.yml");

                //grayscale
                var grayScaleRoi = roiImage.Convert<Gray, Byte>().Resize(200, 200, Inter.Cubic);
                CvInvoke.EqualizeHist(grayScaleRoi, grayScaleRoi);

                var result = faceRecognizer.Predict(grayScaleRoi);
                
                predictionResults.Add(face, result);
            }

            return predictionResults;
        }

        /// <summary>
        /// checks if a face has been recognized
        /// </summary>
        /// <param name="result">takes in the result of prediction</param>
        /// <returns>returns -1 if the face was not recognized otherwise returns the student id</returns>
        public int CheckIfKnowFace(FaceRecognizer.PredictionResult result)
        {
            if (result.Label != -1 && (result.Distance > 20 && result.Distance < 57))
                return result.Label;
            else
                return -1;
        }

        public Image<Bgr, Byte> IndicateFacePredictionResults(Dictionary<Rectangle, FaceRecognizer.PredictionResult> predictionResults, Image<Bgr, Byte> currentFrame)
        {
            foreach (var predictionResult in predictionResults)
            {
                var face = predictionResult.Key;
                var result = predictionResult.Value;

                var faceKnown = CheckIfKnowFace(result) != -1;

                if (faceKnown)
                {
                    CvInvoke.PutText(currentFrame, predictionResult.Value.Distance.ToString("F"), new Point(face.X - 2, face.Y + 30), FontFace.HersheyComplex, 1, new Bgr(255, 0, 0).MCvScalar);
                    CvInvoke.PutText(currentFrame, GetStudentLabelFromID(result.Label), new Point(face.X - 2, face.Y - 2), FontFace.HersheyComplex, 1, new Bgr(0, 255, 0).MCvScalar);
                    CvInvoke.Rectangle(currentFrame, face, new Bgr(0, 255, 0).MCvScalar, 2);
                }
                else
                {
                    CvInvoke.PutText(currentFrame, "unknown", new Point(face.X - 2, face.Y - 2), FontFace.HersheyComplex, 1, new Bgr(255, 0, 0).MCvScalar);
                    CvInvoke.Rectangle(currentFrame, face, new Bgr(0, 0, 255).MCvScalar, 2);
                }
            }

            return currentFrame;
        }

        private Dictionary<string, int> GetStudentToIDDictionary()
        {
            try
            {
                var dic = JsonConvert.DeserializeObject<Dictionary<string, int>>(File.ReadAllText("studentImagesToID.txt"));
                return dic;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return new Dictionary<string, int>();
        }

        private string GetStudentLabelFromID(int id)
        {
            return dBService.GetStudentName(id);
        }

        public ImageSource GetImageSourceFrom(Image<Bgr, Byte> image)
        {
            byte[] imageBytes = image.ToJpegData();

            return (ImageSource)new ImageSourceConverter().ConvertFrom(imageBytes);
        }
        public Image<Bgr, Byte> GetRegionOfInterest(Image<Bgr, Byte> currentFrame, Rectangle face)
        {
            var roiImage = currentFrame.Convert<Bgr, Byte>();
            roiImage.ROI = face;

            return roiImage;
        }
    }
}
