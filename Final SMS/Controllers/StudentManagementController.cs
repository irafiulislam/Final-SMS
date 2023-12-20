using Final_SMS.DataTransferObject;
using Final_SMS.Interfaces;
using Final_SMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Final_SMS.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class StudentManagementController : ControllerBase
    {
        private readonly ILogger<Student> _logger;
        private readonly IStudentManagementInterface _service;
        public StudentManagementController (ILogger<Student> logger, IStudentManagementInterface service)
        {
            _logger = logger;
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetAllStudents()
        {
            var item = await _service.GetAll();
            return Ok(item);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>>GetSingleStudent(int id)
        {
            var result = await _service.GetById(id);
            if(result == null)
            {
                return NotFound("Student Not Found");
            }
            return Ok(result);
        }
        [HttpPost]
        [Authorize]
        public async Task AddStudent(StudentDto student)
        {
            await _service.Add(student);
        }
        [HttpPost]
        public async Task AddCourse(CourseDto course)
        {
            await _service.AddSingleCourse(course);
             
        }
        [HttpPost]
        public async Task AddSemester(SemesterDto semester)
        {
            await _service.AddSingleSemester(semester);
             
        }
        [HttpPut("{id}")]
        public  async Task Update(int id, StudentDto student)
        {
            var result = await _service.GetById(id);
            if (result == null)
            {
                return;
            }
            await _service.Update(id,student);
        }
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var result = await _service.GetById(id);
            if (result is null)
                return;

            await _service.Delete(id);
        }





    }
}
