using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Bai13
{
    public class BirthDayException : Exception
    {
        public BirthDayException(string message) : base(message)
        {
        }
    }

    public class EmailException : Exception
    {
        public EmailException(string message) : base(message)
        {
        }
    }

    public class FullNameExcepTion : Exception
    {
        public FullNameExcepTion(string message) : base(message)
        {
        }
    }

    public class PhoneException : Exception
    {
        public PhoneException(string message) : base(message)
        {
        }
    }

    class Employee
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Employee_type { get; set; }
        private static int Employee_count = 0;
        public List<Certificate> Certificates { get; set; }
        public Employee(int id, string fullName, DateTime birthDay, string phone, string email)
        {
            ID = id;
            FullName = fullName;
            BirthDay = birthDay;
            Phone = phone;
            Email = email;
            Employee_count += 1;
            Certificates = new List<Certificate>();
        }

        public static List<Employee> Employees = new List<Employee>();

        public static void AddEmployee(Employee employee)
        {
            try
            {
                if (IsValidBirthDay(employee.BirthDay) && 
                    IsValidEmail(employee.Email) && 
                    IsValidName(employee.FullName) && 
                    IsValidPhone(employee.Phone))
                {
                    Employees.Add(employee);
                    Console.WriteLine($"Nhan vien co ID {employee.ID}  da duoc them moi.");
                }
                else
                {
                    Console.WriteLine("Thong tin cua nhan vien khong hop le. Vui long kiem tra lai.");
                }
            }
            catch (BirthDayException Ex)
            {
                Console.WriteLine($"Loi ngay sinh: {Ex.Message}");
            }
            catch (EmailException Ex)
            {
                Console.WriteLine($"Loi email: {Ex.Message}");
            }
            catch (FullNameExcepTion Ex)
            {
                Console.WriteLine($"Loi ten: {Ex.Message}");
            }
            catch (PhoneException Ex)
            {
                Console.WriteLine($"Loi So Dien thoai {Ex.Message}");
            }
        }

        public virtual void UpdateInfo(Employee updatedEmployee)
        {
            FullName = updatedEmployee.FullName;
            BirthDay = updatedEmployee.BirthDay;
            Phone = updatedEmployee.Phone;
            Email = updatedEmployee.Email;
        }

        public static void updatedEmployee(int id, Employee updatedEmployee)
        {
            Employee existingEmployee = Employees.FirstOrDefault(e => e.ID == id);
            if (existingEmployee != null)
            {
                //Sửa thông tin của existingEmployee
                existingEmployee.FullName = updatedEmployee.FullName;
                existingEmployee.BirthDay = updatedEmployee.BirthDay;
                existingEmployee.Phone = updatedEmployee.Phone;
                existingEmployee.Email = updatedEmployee.Email;
                if (existingEmployee is Experience)
                {
                    //Cập nhật thông tin riêng cho từng loại nhân viên(Experience, Fresher, Intern)
                    Experience existingExperience = (Experience)existingEmployee;
                    Experience updatedExperience = (Experience)updatedEmployee;
                    existingExperience.ExpInYear = updatedExperience.ExpInYear;
                    existingExperience.ProSkill = updatedExperience.ProSkill;
                }
                else if (existingEmployee is Fresher)
                {
                    Fresher existingFresher = (Fresher)existingEmployee;
                    Fresher updatedFresher = (Fresher)updatedEmployee;
                    existingFresher.Graduation_date = updatedFresher.Graduation_date;
                    existingFresher.Graduation_rank = updatedFresher.Graduation_rank;
                    existingFresher.Education = updatedFresher.Education;
                }
                else if (existingEmployee is Intern)
                {
                    Intern existingIntern = (Intern)existingEmployee;
                    Intern updatedIntern = (Intern)updatedEmployee;
                    existingIntern.Majors = updatedIntern.Majors;
                    existingIntern.Semester = updatedIntern.Semester;
                    existingIntern.University_name = updatedIntern.University_name;
                }
                Console.WriteLine($"Thong tin cua nhan vien co ID {id} da duoc cap nhat.");
            }
            else
            {
                Console.WriteLine($"Khong tim thay nhan vien co ID {id} de cap nhat.");
            }
        }

        public static void DeleteEmployee(int id)
        {
            Employee employeeToDelete = Employees.FirstOrDefault(e => e.ID == id);
            if (employeeToDelete != null)
            {
                Employees.Remove(employeeToDelete);
                Console.WriteLine($"Nhan vien co ID {id} da duoc xoa khoi danh sach.");
            }
            else
            {
                Console.WriteLine($"Khong tim thay nhan vien co ID {id} de xoa khoi danh sach.");
            }
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"ID: {ID}, FullName: {FullName}, BirthDay: {BirthDay}, Phone: {Phone}, Email: {Email}, Employee_type: {Employee_type}, Employee_count: {Employee_count}");
        }

        //Tìm tất cả nhân viên
        public static List<Employee> GetInterns()
        {
            return Employees.Where(e => e is Intern).ToList();
        }
        public static List<Employee> GetExperiences()
        {
            return Employees.Where(e => e is Experience).ToList();
        }
        public static List<Employee> GetFreshers()
        {
            return Employees.Where(e => e is Fresher).ToList();
        }

        //Kiểm tra tính hợp lệ áp dụng chung chức năng số 7
        public static bool IsValidBirthDay(DateTime birthDay)
        {
            if (birthDay > DateTime.Now)
            {
                throw new BirthDayException("Ngay sinh khong the la ngay trong tuong lai.");
            }
            return true;
        }
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email) || !email.Contains("@"))
            {
                throw new EmailException("Email khong hop le.");
            }
            return true;
        }
        public static bool IsValidName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new FullNameExcepTion("Ten khong hop le.");
            }
            return true;
        }
        public static bool IsValidPhone(string phone)
        {
            if (string.IsNullOrEmpty(phone) || !phone.All(char.IsDigit))
            {
                throw new PhoneException("So dien thoai khong hop le.");
            }
            return true;
        }
    }
    class Experience : Employee
    {
        public int ExpInYear { get; set; }
        public string ProSkill { get; set; }

        public Experience(int id, string fullName, DateTime birthDay, string phone, string email, int expInYear, string proSkill)
        : base(id, fullName, birthDay, phone, email)
        {
            ExpInYear = expInYear;
            ProSkill = proSkill;
        }

        public override void UpdateInfo(Employee updatedEmployee)
        {
            base.UpdateInfo(updatedEmployee);
            Experience updatedExperience = (Experience)updatedEmployee;
            ExpInYear = updatedExperience.ExpInYear;
            ProSkill = updatedExperience.ProSkill;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"ExpInYear: {ExpInYear}, ProSkill: {ProSkill}");
        }
    }
    class Fresher : Employee
    {
        public DateTime Graduation_date { get; set; }
        public string Graduation_rank { get; set; }
        public string Education { get; set; }

        public Fresher(int id, string fullName, DateTime birthDay, string phone, string email, DateTime graduation_date, string graduation_rank, string education)
        : base(id, fullName, birthDay, phone, email)
        {
            Graduation_date = graduation_date;
            Graduation_rank = graduation_rank;
            Education = education;
        }

        public override void UpdateInfo(Employee updatedEmployee)
        {
            base.UpdateInfo(updatedEmployee);
            Fresher updatedFresher = (Fresher)updatedEmployee;
            Graduation_date = updatedFresher.Graduation_date;
            Graduation_rank = updatedFresher.Graduation_rank;
            Education = updatedFresher.Education;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Graduation_date: {Graduation_date}, Graduation_rank: {Graduation_rank}, Education: {Education}");
        }
    }
    class Intern : Employee
    {
        public string Majors { get; set; }
        public string Semester { get; set; }
        public string University_name { get; set; }

        public Intern(int id, string fullName, DateTime birthDay, string phone, string email, string majors, string semester, string university_name)
        : base(id, fullName, birthDay, phone, email)
        {
            Majors = majors;
            Semester = semester;
            University_name = university_name;
        }

        public override void UpdateInfo(Employee updatedEmployee)
        {
            base.UpdateInfo(updatedEmployee);
            Intern updatedIntern = (Intern)updatedEmployee;
            Majors = updatedIntern.Majors;
            Semester = updatedIntern.Semester;
            University_name = updatedIntern.University_name;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Majors: {Majors}, Semester: {Semester}, University_name: {University_name}");
        }
    }
    class Certificate
    {
        public int CertificateId { get; set; }
        public string CertificateName { get; set; }
        public string CertificateRank { get; set; }
        public DateTime CertificateDate { get; set; }

        public Certificate(int certificateId, string certificateName, string certificateRank, DateTime certificateDate)
        {
            CertificateId = certificateId;
            CertificateName = certificateName;
            CertificateRank = certificateRank;
            CertificateDate = certificateDate;
        }
    }
    public static class Bai13
    {
        public static void Main()
        {
            Employee.AddEmployee(new Intern(1, "Nguyen Van A", new DateTime(1990, 1, 1), "123456789", "a@example.com", "IT", "Spring", "University A"));
            Employee.AddEmployee(new Experience(2, "Tran Thi B", new DateTime(1985, 5, 5), "987654321", "b@example.com", 5, "C#"));
            Employee.AddEmployee(new Fresher(3, "Le Van C", new DateTime(2000, 10, 10), "567891234", "c@example.com", new DateTime(2022, 7, 1), "Good", "University B"));

            Console.WriteLine("Danh sach tat ca nhan vien:");
            foreach (Employee employee in Employee.Employees)
            {
                employee.ShowInfo();
            }
            Console.WriteLine("-----------------------------");

            Employee.updatedEmployee(1, new Intern(1, "Nguyen Van A", new DateTime(1990, 1, 1), "123456789", "a@example.com", "IT", "Spring", "University A"));
            Employee.updatedEmployee(2, new Experience(2, "Tran Thi B", new DateTime(1985, 5, 5), "987654321", "b@example.com", 5, "C#"));
            Employee.updatedEmployee(3, new Fresher(3, "Le Van C", new DateTime(2000, 10, 10), "567891234", "c@example.com", new DateTime(2022, 7, 1), "Good", "University B"));
            Console.WriteLine("Danh sach tat ca nhan vien sau khi cap nhat:");
            foreach (Employee employee in Employee.Employees)
            {
                employee.ShowInfo();
            }
            Console.WriteLine("-----------------------------");

            Employee.DeleteEmployee(1);
            Console.WriteLine("Danh sach tat ca nhan vien sau khi xoa:");
            foreach (Employee employee in Employee.Employees)
            {
                employee.ShowInfo();
            }
        }
    }
}