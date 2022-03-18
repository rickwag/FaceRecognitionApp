using System.Windows;


namespace FaceRecognitionApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //private void OnCaptureClick(object sender, RoutedEventArgs e)
        //{
        //    faceRecognitionService.InitialiseTimer(timer_tick);
        //}
       
        //private void timer_tick(object sender, EventArgs e)
        //{
        //    currentFrame = faceRecognitionService.CaptureVideo();

        //    if (currentFrame != null)
        //    {
        //        var faces = faceRecognitionService.DetectFaces(currentFrame);

        //        //if faces detected
        //        if (faces.Length > 0)   
        //        {
        //            faceRecognitionService.DrawRectangleOnDetectedFaces(faces, currentFrame, new Bgr(0, 100, 255));

        //            foreach (var face in faces)
        //            {

        //                //show image of ROI(region of interest)
        //                var roiImage = currentFrame.Convert<Bgr, Byte>();
        //                roiImage.ROI = face;

        //                roiImageBox.Source = GetImageSourceFrom(roiImage);

        //                if (canAddStudent && !String.IsNullOrEmpty(newStudentTxtBox.Text))
        //                {
        //                    faceRecognitionService.StoreTrainingImages(newStudentTxtBox.Text, face, currentFrame, 60);

        //                    canAddStudent = false;
        //                }
        //            }
        //        }


        //        if (canRecognizeFaces)
        //        {
        //            var predictionResults = faceRecognitionService.RecognizeFaces(faces, currentFrame);

        //            faceRecognitionService.IndicateFacePredictionResults(predictionResults, currentFrame);
        //        }

        //        imageBox.Source = GetImageSourceFrom(currentFrame);
        //    }
        //}

        //private ImageSource GetImageSourceFrom(Image<Bgr, Byte> image)
        //{
        //    byte[] imageBytes = image.ToJpegData();

        //    return (ImageSource)new ImageSourceConverter().ConvertFrom(imageBytes);
        //}

        //private void OnAddStudentClick(object sender, RoutedEventArgs e)
        //{
        //    canAddStudent = true;
        //}

        //private void OnTrainClick(object sender, RoutedEventArgs e)
        //{
        //    faceRecognitionService.Train();
        //}

        //private void OnRecognizeClick(object sender, RoutedEventArgs e)
        //{
        //    canRecognizeFaces = true;
        //}
    }
}
