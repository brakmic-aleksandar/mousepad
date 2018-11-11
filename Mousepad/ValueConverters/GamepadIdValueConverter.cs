using System;
using System.Globalization;
using System.Windows.Data;

namespace Mousepad.ValueConverters
{
    class GamepadIdValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (ushort) value + 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (ushort) value - 1;
        }
    }
}
