using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace WpfIntro
{
    public static class FileIo
    {
        public static void WriteStudentsToCsv(ObservableCollection<Student> students, string path)
        {
            using (var fileOut = new StreamWriter(path))
            {
                foreach (var student in students)
                {
                    fileOut.WriteLine("{0},{1},{2}", student.FirstName, student.LastName, student.StudentNumber);
                }
            }
        }

        public static List<Student> ReadStudentsFromCsv(string path)
        {
            var students = new List<Student>();
            using (var fileIn = new StreamReader(path))
            {
                while (!fileIn.EndOfStream)
                {
                    string line = fileIn.ReadLine();
                    var values = line.Split(',');

                    students.Add(new Student(values[0], values[1], values[2]));
                }
            }

            return students;
        }
    }
}
