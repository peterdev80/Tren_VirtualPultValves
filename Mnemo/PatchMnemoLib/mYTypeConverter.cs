using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Data;
using System.Globalization;

namespace PatchMnemoLib
{
    [ValueConversion(typeof(List<int>), typeof(String))]
    public class DateConverterListint : IValueConverter
    {

        protected readonly TypeConverter _typeConverter = TypeDescriptor.GetConverter(typeof(int));
     protected string[] GetStringArray(string input)
        {
            string[] result = input.Split(',');
            Array.ForEach(result, s => s.Trim());
            return result;
        }

       
        
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return string.Join(",", ((IList<int>)value));
    }
        
     public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        string strValue = value as string;
        string[] items = GetStringArray(strValue);

                List<int> result = new List<int>();
                Array.ForEach(items, s =>
                {
                    object item = _typeConverter.ConvertFromInvariantString(s);
                    if (item != null)
                    {
                        result.Add((int)item);
                    }
                });

                return result;
        
    }    
        
        
        
       
    }
}

