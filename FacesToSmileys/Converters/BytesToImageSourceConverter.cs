using System;
using System.Globalization;
using System.IO;
using Xamarin.Forms;

namespace FacesToSmileys.Converters
{
    /// <summary>
    /// Byte array to image converter
    /// </summary>
    public class BytesToImageSourceConverter : IValueConverter
    {
        /// <summary>
        /// Convert a byte array to an image
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var byteArray = value as byte[];
            return  byteArray != null ? ImageSource.FromStream(() => new MemoryStream(byteArray)) : null;
        }

        /// <summary>
        /// Convert an image to a byte array
        /// </summary>
        /// <exception cref="NotImplementedException">Not implemented method</exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
