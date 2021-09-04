using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace UWPHangman.ViewModels.Converters
{
    class IntPictureConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is int cislo)
            {
                if (Images.Count > cislo) return Images[cislo];
                return Images.Last();
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        private readonly List<Uri> Images = new List<Uri>()
        {
            new Uri("ms-appx:///Assets/Hangman/HM-all-win.svg"),
            new Uri("ms-appx:///Assets/Hangman/HM-7life.svg"),
            new Uri("ms-appx:///Assets/Hangman/HM-6life.svg"),
            new Uri("ms-appx:///Assets/Hangman/HM-5life.svg"),
            new Uri("ms-appx:///Assets/Hangman/HM-4life.svg"),
            new Uri("ms-appx:///Assets/Hangman/HM-3life.svg"),
            new Uri("ms-appx:///Assets/Hangman/HM-2life.svg"),
            new Uri("ms-appx:///Assets/Hangman/HM-1life.svg"),
            new Uri("ms-appx:///Assets/Hangman/HM-all-loose.svg"),
        };
    }
}
