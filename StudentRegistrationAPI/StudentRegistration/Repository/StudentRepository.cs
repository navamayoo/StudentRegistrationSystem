using StudentRegistration.Data;
using StudentRegistration.Interface;
using StudentRegistration.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace StudentRegistration.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _dbcontext;
        public StudentRepository(AppDbContext context)
        {
            this._dbcontext = context;
        }

        public Student CreateStudent(Student student)
        {
            try
            {
                _dbcontext.Students.Add(student);
                _dbcontext.SaveChanges();
                return student;
            }
            catch (Exception ex)
            {

                throw new Exception($"Unexpected error in controller when creating category: {ex.Message}");
            }


        }

        public Student DeleteStudent(int id)
        {
            try
            {
                Student student = _dbcontext.Students.Find(id);
                if(student != null)
                {
                    _dbcontext.Students.Remove(student);
                    _dbcontext.SaveChanges();
                }
               return student;
            }
            catch (Exception ex)
            {

                throw new Exception($"Unexpected error in controller when creating category: {ex.Message}");
            }


        }

        public IEnumerable<Student> GetAllStudents()
        {
            var students = _dbcontext.Students.Include(c => c.Class).ToList();
            return students;
        }

        public Student GetStudentById(int id)
        {
          var  student = _dbcontext.Students
                .Where(c => c.Id == id)
                .Include(c => c.Class).FirstOrDefault();

            return student;
        }

        public Student UpdateStudent(Student student, int id)
        {
            try
            {
                if (id == student.Id)
                {
                    var _student = _dbcontext.Students.Attach(student);
                    _student.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _dbcontext.SaveChanges();

                    return student;

                }
                else
                {
                    throw new ArgumentException("Student not found for specified id.");
                }
                   
            }
            catch (Exception ex)
            {

                throw new Exception($"Unexpected error in controller when creating category: {ex.Message}");
            }
        }
    }
}
