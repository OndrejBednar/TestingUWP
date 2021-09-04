using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UWPConvertersDemo.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        private int _cityIndex = 3;

        public int CityIndex
        {
            get
            {
                return _cityIndex;
            }
            set
            {
                _cityIndex = value;
                NotifyPropertyChanged();
                //NotifyPropertyChanged("CityName");
            }
        }
        //public string CityName
        //{
        //    get
        //    {
        //        return _names[_cityIndex];
        //    }
        //}


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
