using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bai14
{
    public class InvalidFullNameException : Exception
    {
        public InvalidFullNameException(string message) : base(message)
        {
        }
    }
    public class InvalidDoBException : Exception
    {
        public InvalidDoBException(string message) : base(message)
        {
        }
    }
    public class InvalidPhoneNumberException : Exception
    {
        public InvalidPhoneNumberException(string message) : base(message)
        {
        }
    }
    class Student
    {
        //Thuộc tính bao đóng
        private string fullName;
        public string FullName
        {
            get { return fullName; }
            set
            {
                if (value.Length < 10 || value.Length > 50)
                {
                    throw new InvalidFullNameException("Invalid full name length");
                }
                fullName = value;
            }
        }

        private DateTime doB;
        public DateTime DoB
        {
            get { return doB; }
            set
            {
                if (value.ToString("d/M/yyyy") != value.ToShortDateString())
                {
                    throw new InvalidDoBException("Invalid date of birth");
                }
                doB = value;
            }
        }

        private string sex;
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        private string phoneNumber;
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                string[] validPrefiXes = { "090", "098", "091", "031", "035", "038" };
                if (value.Length != 10 || !validPrefiXes.Any(value.StartsWith) || !value.All(char.IsDigit))
                {
                    throw new InvalidPhoneNumberException("Invalid phone number");
                }
                phoneNumber = value;
            }
        }

        private string universityName;
        public string UniversityName
        {
            get { return universityName; }
            set { universityName = value; }
        }

        private string gradeLevel;
        public string GradeLevel
        {
            get { return gradeLevel; }
            set { gradeLevel = value; }
        }

        //Phương thức trườu tượng
        public virtual void ShowInfo()
        {
            Console.WriteLine($"Full Name: {FullName}");
            Console.WriteLine($"Date of Birth: {DoB}");
            Console.WriteLine($"Sex: {Sex}");
            Console.WriteLine($"Phone Number: {PhoneNumber}");
            Console.WriteLine($"University Name: {UniversityName}");
            Console.WriteLine($"Grade Level: {GradeLevel}");
        }

        public static void SelectCandidates(List<Student> students)
        {
            Console.WriteLine("Enter the number of candidates to recruit: ");
            int numberOfCandidates;

            while (!int.TryParse(Console.ReadLine(), out numberOfCandidates) || numberOfCandidates <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid positive integer.");
            }

            List<Student> selectedCandidates = new List<Student>();

            // Chọn ứng viên giỏi
            List<GoodStudent> goodStudents = students.OfType<GoodStudent>().OrderByDescending(s => s.Gpa).ThenBy(s => s.FullName).ToList();
            int goodStudentsNeeded = Math.Min(numberOfCandidates, goodStudents.Count);
            selectedCandidates.AddRange(goodStudents.Take(goodStudentsNeeded));

            // Chọn ứng viên trung bình nếu còn thiếu
            if (selectedCandidates.Count < numberOfCandidates)
            {
                List<NormalStudent> normalStudents = students.OfType<NormalStudent>().OrderByDescending(s => s.EntryTestScore).ThenByDescending(s => s.EnglishScore).ThenBy(s => s.FullName).ToList();
                int normalStudentsNeeded = numberOfCandidates - selectedCandidates.Count;
                selectedCandidates.AddRange(normalStudents.Take(normalStudentsNeeded));
            }

            // Hiển thị thông tin ứng viên trúng tuyển
            Console.WriteLine("\nSelected Candidates:");
            foreach (var candidate in selectedCandidates)
            {
                candidate.ShowInfo();
                Console.WriteLine();
            }
        }
        public static void ShowAllStudentsInfo(List<Student> students)
        {
            var sortedStudents = students
                .OrderByDescending(s => s.FullName)
                .ThenBy(s => s is GoodStudent ? ((GoodStudent)s).Gpa : double.MinValue)
                .ThenBy(s => s is NormalStudent ? ((NormalStudent)s).EntryTestScore : string.Empty)
                .ThenBy(s => s.FullName)
                .ToList();

            Console.WriteLine("\nAll Students Information");
            foreach (var student in sortedStudents)
            {
                Console.WriteLine($"Full Name: {student.FullName} PhoneNumber {student.PhoneNumber}");
            }
        }
    }
    class GoodStudent : Student
    {
        private double gpa;
        public double Gpa
        {
            get { return gpa; }
            set { gpa = value; }
        }

        private string bestRewardName;
        public string BestRewardName
        {
            get { return bestRewardName; }
            set { bestRewardName = value; }
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"GPA: {Gpa}");
            Console.WriteLine($"Best Reward Name: {BestRewardName}");
        }
    }
    class NormalStudent : Student
    {
        private string englishScore;
        public string EnglishScore
        {
            get { return englishScore; }
            set { englishScore = value; }
        }

        private string entryTestScore;
        public string EntryTestScore
        {
            get { return entryTestScore; }
            set { entryTestScore = value; }
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"EnglishScore: {EnglishScore}");
            Console.WriteLine($"EntryTestScore: {EntryTestScore}");
        }
    }
    public static class Bai14
    {
        public static void Main()
        {
            List<Student> students = new List<Student>
            {
                new Student
                {
                    FullName = "Nguyen Van A",
                    DoB = new DateTime(2000, 1, 1),
                    Sex = "Male",
                    PhoneNumber = "0902345678",
                    UniversityName = "Hanoi University",
                    GradeLevel = "1",
                },
                new GoodStudent
                {
                    FullName = "Nguyen Van B",
                    DoB = new DateTime(2000, 1, 1),
                    Sex = "Female",
                    PhoneNumber = "0902345679",
                    UniversityName = "Hanoi University",
                    GradeLevel = "1",
                    Gpa = 4.0,
                    BestRewardName = "Best reward"
                },
                new NormalStudent
                {
                    FullName = "Nguyen Van C",
                    DoB = new DateTime(2000, 1, 1),
                    Sex = "Male",
                    PhoneNumber = "0902345677",
                    UniversityName = "Hanoi University",
                    GradeLevel = "1",
                    EnglishScore = "A",
                    EntryTestScore = "A"
                }
            };

            Student.SelectCandidates(students);
            Student.ShowAllStudentsInfo(students);
        }
    }
}
