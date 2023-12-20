namespace Final_SMS.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseCode { get; set; } = string.Empty;
        public string CourseName { get; set; } = string.Empty;
        public string InstructorName {  get; set; } = string.Empty;
        public double NumberOfCredits { get; set; }
        public IList<Student> Students { get; set; }    



    }
}
