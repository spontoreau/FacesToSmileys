using System;
using System.Globalization;
using Xamarin.Forms;

namespace FacesToSmileys.Converters
{
	/// <summary>
	/// Not empty array to bool converter.
	/// </summary>
	public class NotEmptyArrayToBoolConverter : IValueConverter
	{
		/// <summary>
		/// Convert the specified value, targetType, parameter and culture.
		/// </summary>
		/// <returns>The convert.</returns>
		/// <param name="value">Value.</param>
		/// <param name="targetType">Target type.</param>
		/// <param name="parameter">Parameter.</param>
		/// <param name="culture">Culture.</param>
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var byteArray = value as byte[];
			return byteArray != null && byteArray.Length > 0;
		}

		/// <summary>
		/// Converts the back.
		/// </summary>
		/// <returns>The back.</returns>
		/// <param name="value">Value.</param>
		/// <param name="targetType">Target type.</param>
		/// <param name="parameter">Parameter.</param>
		/// <param name="culture">Culture.</param>
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
