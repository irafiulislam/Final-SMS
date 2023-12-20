using Final_SMS.Enums;
using static Final_SMS.Enums.Enums;

namespace Final_SMS.Models
{
    public class Student
    {
        //public Student()
        //{
        //    SemestersAttended = new List<Semester>();
        //    AttendedCourse = new List<Course>();
        //    JoiningBatch = string.Empty;
        //}
        public int id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string MidlleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string StudentId { get; set; } = string.Empty;
        public string? JoiningBatch { get; set; }
        public Dept Department { get; set; } = Dept.None;
        public Degree Degree { get; set; } = Degree.None;
        public IList<Course> AttendedCourse { get; set; }
        public IList<Semester> SemestersAttended { get; set; }   
        
    }
}
