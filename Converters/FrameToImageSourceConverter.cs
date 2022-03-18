using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using Emgu.CV;
using Emgu.CV.Structure;

namespace FaceRecognitionApp.Converters
{
    public class FrameToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return new BitmapImage(new Uri("girlHatFace.jpg", UriKind.Relative));

            var frame = (value as Image<Bgr, Byte>);

            byte[] frameBytes = frame.ToJpegData();

            return (ImageSource)new ImageSourceConverter().ConvertFrom(frameBytes);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
