using Final_SMS.Enums;
using Final_SMS.Models;
using static Final_SMS.Enums.Enums;

namespace Final_SMS.DataTransferObject
{
    public class StudentDto
    {
        public StudentDto()
        {
            AttendedCourse = new List<int>();
            SemestersAttended = new List<int>();
        }
        public int id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string MidlleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string StudentId { get; set; } = string.Empty;
        public string? JoiningBatch { get; set; }
        public Dept Department { get; set; } = Dept.None;
        public Degree Degree { get; set; } = Degree.None;
        public IList<int> AttendedCourse { get; set; }
        public IList<int> SemestersAttended { get; set; }
    }
}
