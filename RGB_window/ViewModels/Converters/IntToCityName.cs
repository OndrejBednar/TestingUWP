using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace UWPConvertersDemo.ViewModels.Converters
{
    class IntToCityName : IValueConverter
    {
        private List<string> _names = new List<string> { "Amsterdam", "Bergen", "Budapest", "Copenhagen", "Dubrovnik", "Edinburgh", "London", "New York", "Paris", "Prague", "Rome", "St. ", "Viena" };
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is int && targetType == typeof(string))
            {
                int cislo = ((int)value) % _names.Count;
                return _names[cislo];
            }
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is string && targetType == typeof(int))
            {
                int found = _names.IndexOf(value as string);
                if (found > 0) return found;
            }
            return value.ToString();
        }
    }
}
