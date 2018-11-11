using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using Gamepad;

namespace Mousepad.ValueConverters
{
    class ButtonNamesToStringValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<ButtonNames> names = (List<ButtonNames>) value;
            string result = names.Aggregate("", (current, name) => current + (name + ","));
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
