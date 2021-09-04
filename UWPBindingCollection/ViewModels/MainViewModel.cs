using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UWPBindingCollection.Models;

namespace UWPBindingCollection.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Student> _students = new ObservableCollection<Student>();
        private int? _selectedIndex;
        private Student _selectedStudent;

        public ObservableCollection<Student> Students { get { return _students; } set { _students = value; NotifyPropertyChanged(); } }
        public Student SelectedStudent { get { return _selectedStudent; } set { _selectedStudent = value; NotifyPropertyChanged(); } }
        public int? SelectedIndex { get { return _selectedIndex; } set { _selectedIndex = value; NotifyPropertyChanged(); } }

        public IEnumerable<Gender> Genders { get { return Enum.GetValues(typeof(Gender)).Cast<Gender>(); } }

        public RelayCommand AddStudent { get; set; }
        public RelayCommand BalanceAverage { get; set; }
        public MainViewModel()
        {
            _students.Add(new Student { Firstname = "Adam", Lastname = "Novák", Average = 2.85, Gender = Gender.Man, Examined = false });
            _students.Add(new Student { Firstname = "Bobik", Lastname = "Proki", Average = 2.2, Gender = Gender.Man, Examined = true });
            _students.Add(new Student { Firstname = "Beata", Lastname = "Pokorná", Average = 1.8, Gender = Gender.Female, Examined = false });
            AddStudent = new RelayCommand(
                () => _students.Add(new Student { Firstname = "Xena", Lastname = "Zlatorádová", Average = 1.5, Gender = Gender.Female, Examined = true }),
                () => true
                );
           BalanceAverage = new RelayCommand(
                () =>
                {
                    foreach (var item in _students)
                    {
                        item.Average = 5;
                    }
                },
                () => true
                );
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
