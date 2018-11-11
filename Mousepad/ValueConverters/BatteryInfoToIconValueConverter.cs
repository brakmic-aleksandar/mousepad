using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using Gamepad;
using Gamepad.Xinput;

namespace Mousepad.ValueConverters
{
    class BatteryInfoToIconValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            BatteryInformation info = (BatteryInformation) value;
            switch (info.BatteryLevel)
            {
                case BatteryLevel.Empty:
                    if(info.BatteryType == BatteryType.Unknown || info.BatteryType == BatteryType.Disconnected)
                        return Application.Current.FindResource("GamepadBatteryUnknown");
                    return Application.Current.FindResource("GamepadBatteryEmpty");
                case BatteryLevel.Low:
                    return Application.Current.FindResource("GamepadBatteryLow");
                case BatteryLevel.Medium:
                    return Application.Current.FindResource("GamepadBatteryMedium");
                case BatteryLevel.Full:
                    return Application.Current.FindResource("GamepadBatteryFull");
                default:
                    return Application.Current.FindResource("GamepadOff");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
