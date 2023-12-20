using Final_SMS.Models;

namespace Final_SMS.DataTransferObject
{
    public class CourseDto
    {
        public string CourseCode { get; set; } = string.Empty;
        public string CourseName { get; set; } = string.Empty;
        public string InstructorName { get; set; } = string.Empty;
        public double NumberOfCredits { get; set; }
     }
}
