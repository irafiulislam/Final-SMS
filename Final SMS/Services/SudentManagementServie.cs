﻿using Final_SMS.Data;
using Final_SMS.DataTransferObject;
using Final_SMS.Interfaces;
using Final_SMS.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using static Final_SMS.Data.GenericRepo;

namespace Final_SMS.Services
{
    public class SudentManagementServie : IStudentManagementInterface
    {
        private readonly ILogger<SudentManagementServie> _logger;
        private readonly IGenericRepo<Student> _studentRepository;
        private readonly IGenericRepo<Course> _courseRepository;
        private readonly IGenericRepo<Semester> _semesterRepository;
        private readonly AppData _context;

        public SudentManagementServie(ILogger<SudentManagementServie> logger,
            IGenericRepo<Student> studentRepository,
            IGenericRepo<Course> courseRepository,
            IGenericRepo<Semester> semesterRepository,
            AppData context
            )
        {
            _logger = logger;
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _semesterRepository = semesterRepository;
            _context = context;
        }
        public async Task<List<StudentDto>> GetAll()
        {
            //var result = await _studentRepository.GetAll();
            var result = await _context.Students.Include(x => x.SemestersAttended).Include(x => x.AttendedCourse).ToListAsync();
            var response = result.Select(x => new StudentDto
            {
                FirstName = x.FirstName,
                MidlleName = x.MidlleName,
                LastName = x.LastName,
                JoiningBatch = x.JoiningBatch,
                Degree = x.Degree,
                Department = x.Department,
                AttendedCourse = x.AttendedCourse.Select(x => x.Id).ToList(),
                SemestersAttended = x.SemestersAttended.Select(x => x.Id).ToList(),

            });
            return response.ToList();
        }

        public async Task<Student?> GetById(int id)
        {
            var result = await _studentRepository.GetById(id);
            if (result is null)
                return null;

            return result;
        }
        public async Task Add(StudentDto s)
        {
            var student = new Student
            {
                FirstName = s.FirstName,
                MidlleName = s.MidlleName,
                LastName = s.LastName,
                Degree = s.Degree,
                Department = s.Department,
                JoiningBatch = s.JoiningBatch,
            };
            var courses = await _courseRepository.GetAll();
            var cous = courses.Where(x => s.AttendedCourse.Contains(x.Id)).ToList();
            student.AttendedCourse = cous;

            var semesters = await _semesterRepository.GetAll();
            var sem = semesters.Where(x => s.SemestersAttended.Contains(x.Id)).ToList();
            student.SemestersAttended = sem;

            await _studentRepository.Add(student);
        }
        public async Task AddSingleCourse(CourseDto c)
        {
            var course = new Course
            {
                CourseCode = c.CourseCode,
                CourseName = c.CourseName,
                NumberOfCredits = c.NumberOfCredits,
                InstructorName = c.InstructorName,
            };
            await _courseRepository.Add(course);
        }
        public async Task AddSingleSemester(SemesterDto se)
        {
            var semester = new Semester
            {
                SemesterCode = se.SemesterCode,
                Year = se.Year,
            };
            await _semesterRepository.Add(semester);
        }
        public async Task Update(int id, StudentDto request)
        {
            var result = await _studentRepository.GetById(id);
            if (result is null)
                return;

            result.FirstName = request.FirstName;
            result.MidlleName = request.MidlleName;
            result.LastName = request.LastName;
            result.JoiningBatch = request.JoiningBatch;

            await _studentRepository.Update(result);
        }
        public async Task Delete(int id)
        {
            var result = await _studentRepository.GetById(id);
            if (result is null)
                return;

            await _studentRepository.Delete(id);
        }
    }

        
}
