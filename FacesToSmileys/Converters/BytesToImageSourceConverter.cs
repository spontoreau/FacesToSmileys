using System;
using System.Globalization;
using System.IO;
using Xamarin.Forms;

namespace FacesToSmileys.Converters
{
    public class BytesToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var byteArray = value as byte[];
            return  byteArray != null ? ImageSource.FromStream(() => new MemoryStream(byteArray)) : null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
