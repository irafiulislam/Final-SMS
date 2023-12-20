using Final_SMS.DataTransferObject;
using Final_SMS.Models;

namespace Final_SMS.Interfaces
{
    public interface IStudentManagementInterface
    {
        Task<List<StudentDto>> GetAll();
        Task<Student?> GetById(int id);
        Task Add(StudentDto student);
        Task Update(int id, StudentDto request);
        Task Delete(int id);
        Task AddSingleCourse(CourseDto course);
        Task AddSingleSemester(SemesterDto semester);
    }
}
