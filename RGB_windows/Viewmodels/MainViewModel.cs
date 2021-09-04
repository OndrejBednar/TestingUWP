using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace RGB_window.Viewmodels
{
    class MainViewModel : INotifyPropertyChanged
    {
        private int _red, _green, _blue;

        public SolidColorBrush SelectedColor
        {
            get
            {
                return new SolidColorBrush(Color.FromArgb(255, (byte)_red, (byte)_green, (byte)_blue));
            }
        }
        public int Red
        {
            get
            {
                return _red;
            }
            set
            {
                _red = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged("SelectedColor");
            }
        }
        public int Green
        {
            get
            {
                return _green;
            }
            set
            {
                _green = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged("SelectedColor");
            }
        }
        public int Blue
        {
            get
            {
                return _blue;
            }
            set
            {
                _blue = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged("SelectedColor");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
