using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace UWPConvertersDemo.ViewModels.Converters
{
    class IntToCityPicture : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is int cislo)
            {
                switch (cislo)
                {
                    case 0:
                        return Picture01;
                    case 1:
                        return Picture02;
                    case 2:
                        return Picture03;
                    case 3:
                        return Picture04;
                    case 4:
                        return Picture05;
                    case 5:
                        return Picture06;
                    case 6:
                        return Picture07;
                    case 7:
                        return Picture08;
                    case 8:
                        return Picture09;
                    case 9:
                        return Picture10;
                    case 10:
                        return Picture11;
                    case 11:
                        return Picture12;
                    case 12:
                        return Picture13;
                    default:
                        return Picture02;
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        public BitmapImage Picture01 { get; set; }
        public BitmapImage Picture02 { get; set; }
        public BitmapImage Picture03 { get; set; }
        public BitmapImage Picture04 { get; set; }
        public BitmapImage Picture05 { get; set; }
        public BitmapImage Picture06 { get; set; }
        public BitmapImage Picture07 { get; set; }
        public BitmapImage Picture08 { get; set; }
        public BitmapImage Picture09 { get; set; }
        public BitmapImage Picture10 { get; set; }
        public BitmapImage Picture11 { get; set; }
        public BitmapImage Picture12 { get; set; }
        public BitmapImage Picture13 { get; set; }
    }
}
