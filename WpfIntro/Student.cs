using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfIntro
{
    public class Student : INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;
        private string _studentNumber;

        public event PropertyChangedEventHandler PropertyChanged;

        public Student(string firstName, string lastName, string studentNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            StudentNumber = studentNumber;
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                NotifyPropertyChanged();
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                NotifyPropertyChanged();
            }
        }

        public string StudentNumber
        {
            get { return _studentNumber; }
            set
            {
                _studentNumber = value;
                NotifyPropertyChanged();
            }
        }

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
