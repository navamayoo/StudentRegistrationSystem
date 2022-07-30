using StudentRegistration.Data;
using StudentRegistration.Interface;
using StudentRegistration.Models;
using System.Collections.Generic;
using System;

namespace StudentRegistration.Repository
{
    public class TeacherSubjectRepository : ITeacherSubjectRepository
    {
        private readonly AppDbContext _context;

        public TeacherSubjectRepository(AppDbContext context)
        {
            this._context = context;
        }
        public TeacherSubject CreateSubject(TeacherSubject subject)
        {
            try
            {
                _context.TeacherSubjects.Add(subject);
                _context.SaveChanges();
                return subject;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public TeacherSubject DeleteSubject(int id)
        {

            try
            {
                TeacherSubject _subject = _context.TeacherSubjects.Find(id);
                if(_subject != null)
                {
                    _context.TeacherSubjects.Remove(_subject);
                    _context.SaveChanges();
                }

                return _subject;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<TeacherSubject> GetAllSubjects()
        {
            return _context.TeacherSubjects;
        }

        public TeacherSubject GetSubjectById(int id)
        {
            return _context.TeacherSubjects.Find(id);
        }

        public TeacherSubject UpdateSubject(TeacherSubject subject, int id)
        {
            try
            {
                if (id == subject.Id)
                {
                    var _teacher = _context.TeacherSubjects.Attach(subject);
                    _teacher.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
