using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using ValueModel.BaseType;

namespace WPFMnemoLibrary
{
    public class IncrementValueConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double baseValue = (double)value;
            double increment = 1.0;
            if (parameter != null)
                double.TryParse(Convert.ToString(parameter), out increment);
            double result = baseValue / increment;
            if (result < 0) result = 0;
            return result;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    [ValueConversion(typeof(bool), typeof(System.Windows.Visibility))]

    public class BitToVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool baseVal = (bool)value;
            if (baseVal) return Visibility.Visible;
            return Visibility.Hidden;
           
        }
        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


}


