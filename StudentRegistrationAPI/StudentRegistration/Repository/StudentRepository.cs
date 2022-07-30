using StudentRegistration.Data;
using StudentRegistration.Interface;
using StudentRegistration.Models;
using System;
using System.Collections.Generic;

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
            return _dbcontext.Students;
        }

        public Student GetStudentById(int id)
        {
            return _dbcontext.Students.Find(id);
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
