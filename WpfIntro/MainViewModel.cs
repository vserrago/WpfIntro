using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
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

            InitCommands();
        }

        private void InitCommands()
        {
            AddNewStudent = new RelayCommand(
                canExecute: () => true,
                execute: () => Students.Add(new Student("First", "Last", "000000000")));

            ClearStudents = new RelayCommand(
                canExecute: () => 0 < Students.Count,
                execute: () => Students.Clear());

            DeleteSelectedStudent = new RelayCommand(
                canExecute: () => SelectedStudent != null,
                execute: () =>
                {
                    if (SelectedStudent != null)
                        Students.Remove(SelectedStudent);
                });

            ReadFromFile = new RelayCommand(
                canExecute: () => true,
                execute: () =>
                {
                    var openDialog = new OpenFileDialog();
                    var result = openDialog.ShowDialog();

                    if (result == true)
                    {
                        //Paramater is not used so pass in null
                        if (ClearStudents.CanExecute(null))
                            ClearStudents.Execute(null);

                        var students = FileIo.ReadStudentsFromCsv(openDialog.FileName);
                        foreach (var s in students)
                        {
                            Students.Add(s);
                        }
                    }
                });

            SaveToFile = new RelayCommand(
                canExecute: () => 0 < Students.Count,
                execute: () =>
                {
                    var saveDialog = new SaveFileDialog();
                    var result = saveDialog.ShowDialog();

                    if (result == true)
                        FileIo.WriteStudentsToCsv(Students, saveDialog.FileName);
                });
        }

        public ICommand AddNewStudent { get; private set; }
        public ICommand ClearStudents { get; private set; }
        public ICommand DeleteSelectedStudent { get; private set; }
        public ICommand ReadFromFile { get; private set; }
        public ICommand SaveToFile { get; private set; }

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
