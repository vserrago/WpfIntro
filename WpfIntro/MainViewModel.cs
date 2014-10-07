using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace WpfIntro
{
    public class MainViewModel : ViewModelBase
    {
        private Student _selectedStudent;
        private readonly ObservableCollection<Student> _students;

        public MainViewModel()
        {
            _students = new ObservableCollection<Student>();

            AddNewStudent = new RelayCommand(
                canExecute: () => true,
                execute: () => Students.Add(new Student("First", "Last", "000000000")));

            DeleteSelectedStudent = new RelayCommand(
                canExecute: () => true,
                execute: () =>
                {
                    if (SelectedStudent != null)
                        Students.Remove(SelectedStudent);
                });

            SaveToFile = new RelayCommand(
                canExecute: () => true,
                execute: () => { });

            ReadFromFile = new RelayCommand(
                canExecute: () => true,
                execute: () => { });
        }

        public ICommand AddNewStudent { get; private set; }
        public ICommand DeleteSelectedStudent { get; private set; }
        public ICommand SaveToFile { get; private set; }
        public ICommand ReadFromFile { get; private set; }

        public ObservableCollection<Student> Students
        {
            get { return _students; }
        }

        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                _selectedStudent = value;
                RaisePropertyChanged();
            }
        }
    }
}
