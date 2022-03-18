﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Threading;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;

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

        private Dictionary<string, int> imagesStudentToID = new();
        private List<Mat> trainingImages = new();
        private List<int> trainingImagesLabels = new();

        private EventHandler savedTrainingImagesEvent;

        public EventHandler SavedTrainingImagesEvent { get => savedTrainingImagesEvent; set => savedTrainingImagesEvent = value; }

        public FaceRecognitionService()
        {
            videoCapture = new VideoCapture();

            imagesStudentToID = GetStudentToIDDictionary();
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

        public Rectangle[] DetectFaces(Image<Bgr, byte> currentFrame)
        {
            //convert to gray image for detection
            Image<Gray, Byte> grayImage = currentFrame.Convert<Gray, Byte>();

            var faces = cascadeClassifier.DetectMultiScale(grayImage, 1.3, 3, System.Drawing.Size.Empty, System.Drawing.Size.Empty);

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

        public async Task StoreTrainingImages(string studentName, Rectangle face, Image<Bgr, byte> currentFrame, int numberOfImages)
        {
            //store 10 images with 1 second delay
            var path = mainDirPath + @"\" + studentName;
            //create new if not exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            //save the images on a separate thread to avoid freezes
            await Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < numberOfImages; i++)
                {
                    var roiImage = GetRegionOfInterest(currentFrame, face);
                    var savePath = path + @"\" + (i + 1) + ".jpg";
                    roiImage.Resize(200, 200, Inter.Cubic).Save(savePath);

                    Debug.WriteLine(savePath);

                    //wait before saving again
                    Thread.Sleep(totalImageSaveTime / numberOfImages * 1000);
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

        public int CheckIfKnowFace(FaceRecognizer.PredictionResult result)
        {
            if (result.Label != -1 && (result.Distance > 20 && result.Distance < 57))
                return result.Label;
            else
                return -1;
        }

        public void IndicateFacePredictionResults(Dictionary<Rectangle, FaceRecognizer.PredictionResult> predictionResults, Image<Bgr, Byte> currentFrame)
        {
            foreach (var predictionResult in predictionResults)
            {
                var face = predictionResult.Key;
                var result = predictionResult.Value;

                var faceKnown = CheckIfKnowFace(result) != -1;

                if (faceKnown)
                {
                    CvInvoke.PutText(currentFrame, GetStudentLabelFromID(result.Label), new System.Drawing.Point(face.X - 2, face.Y - 2), FontFace.HersheyComplex, 1, new Bgr(0, 255, 0).MCvScalar);
                    CvInvoke.Rectangle(currentFrame, face, new Bgr(0, 255, 0).MCvScalar, 2);
                }
                else
                {
                    CvInvoke.PutText(currentFrame, "unknown", new System.Drawing.Point(face.X - 2, face.Y - 2), FontFace.HersheyComplex, 1, new Bgr(255, 0, 0).MCvScalar);
                    CvInvoke.Rectangle(currentFrame, face, new Bgr(0, 0, 255).MCvScalar, 2);
                }
            }
        }

        private void SaveStudentToIDDictionary()
        {
            File.WriteAllText("studentImagesToID.txt", JsonConvert.SerializeObject(imagesStudentToID));
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
            var result = imagesStudentToID.Keys.Count > 0 ? imagesStudentToID.First(keyValue => keyValue.Value == id).Key : id.ToString();

            return result;
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