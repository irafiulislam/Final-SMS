using static Final_SMS.Enums.Enums;

namespace Final_SMS.Models
{
    public class Semester
    {
        public int Id { get; set; }
        public SemesterCode SemesterCode { get; set; }
        public string? Year { get; set; }
        public IList<Student> Students { get; set; }
    }
}
