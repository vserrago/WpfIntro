using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace WpfIntro
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<Student> _students;

        public MainViewModel()
        {
            _students = new ObservableCollection<Student>();
        }

        public ObservableCollection<Student> Students
        {
            get { return _students; }
            set
            {
                _students = value;
                RaisePropertyChanged();
            }
        }
    }
}
