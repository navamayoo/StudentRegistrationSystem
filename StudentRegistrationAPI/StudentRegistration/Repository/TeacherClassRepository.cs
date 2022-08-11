using StudentRegistration.Data;
using StudentRegistration.Interface;
using StudentRegistration.Models;
using System.Collections.Generic;
using System;

namespace StudentRegistration.Repository
{
    public class TeacherClassRepository : ITeacherClassRepository
    {
        private readonly AppDbContext _context;

        public TeacherClassRepository(AppDbContext context)
        {
            this._context = context;
        }
        public TeacherClass CreateTeacherClass(TeacherClass subject)
        {
            try
            {
                _context.TeacherClasses.Add(subject);
                _context.SaveChanges();
                return subject;

            }
            catch (Exception ex)
            {
                throw new Exception($"Unexpected error in controller: {ex.Message}");
            }
        }

        public TeacherClass DeleteTeacherClass(int id)
        {
            try
            {
                TeacherClass _teacher = _context.TeacherClasses.Find(id);
                if(_teacher != null )
                {
                    _context.TeacherClasses.Remove(_teacher);
                    _context.SaveChanges();
                }
                return _teacher;

            }
            catch (Exception ex)
            {

                throw new Exception($"Unexpected error in controller : {ex.Message}");
            }
        }

        public IEnumerable<TeacherClass> GetAllTeacherClass()
        {
            return _context.TeacherClasses;
        }


        public TeacherClass GetTeacherClassById(int id)
        {
            return _context.TeacherClasses.Find(id);
        }

        public TeacherClass UpdateTeacherClass(TeacherClass subject, int id)
        {
            try
            {
                if (id == subject.Id)
                {
                    var _student = _context.TeacherClasses.Attach(subject);
                    _student.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();

                    return subject;

                }
                else
                {
                    throw new ArgumentException("Student not found for specified id.");
                }

            }
            catch (Exception ex)
            {

                throw new Exception($"Unexpected error in controller : {ex.Message}");
            }
        }
    }
}
