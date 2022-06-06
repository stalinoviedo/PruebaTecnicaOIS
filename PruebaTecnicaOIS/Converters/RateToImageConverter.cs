using System;
using System.Globalization;
using Xamarin.Forms;

namespace PruebaTecnicaOIS.Converters
{
    public class RateToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((double)value >= 4.0)
            {
                return "Star.png";
            }
            else
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
