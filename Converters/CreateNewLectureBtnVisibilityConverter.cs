using System;
using System.Globalization;
using System.Windows.Data;

namespace FaceRecognitionApp.Converters
{
    public class CreateNewLectureBtnVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? "Visible" : "Hidden";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
