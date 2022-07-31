using StudentRegistration.Data;
using StudentRegistration.Interface;
using StudentRegistration.Models;
using System.Collections.Generic;
using System;

namespace StudentRegistration.Repository
{
    public class TeacherClassroomRepository : ITeacherClassroomRepository
    {
        private readonly AppDbContext _context;

        public TeacherClassroomRepository(AppDbContext context)
        {
            this._context = context;
        }
        public TeacherClassroom CreateTClassroom(TeacherClassroom subject)
        {
            try
            {
                _context.TeacherClassrooms.Add(subject);
                _context.SaveChanges();
                return subject;

            }
            catch (Exception ex)
            {
                throw new Exception($"Unexpected error in controller: {ex.Message}");
            }
        }

        public TeacherClassroom DeleteTClassroom(int id)
        {
            try
            {
                TeacherClassroom _teacher = _context.TeacherClassrooms.Find(id);
                if(_teacher != null )
                {
                    _context.TeacherClassrooms.Remove(_teacher);
                    _context.SaveChanges();
                }
                return _teacher;

            }
            catch (Exception ex)
            {

                throw new Exception($"Unexpected error in controller : {ex.Message}");
            }
        }

        public IEnumerable<TeacherClassroom> GetAllTClassroom()
        {
            return _context.TeacherClassrooms;
        }


        public TeacherClassroom GetTClassroomById(int id)
        {
            return _context.TeacherClassrooms.Find(id);
        }

        public TeacherClassroom UpdateTClassroom(TeacherClassroom subject, int id)
        {
            try
            {
                if (id == subject.Id)
                {
                    var _student = _context.TeacherClassrooms.Attach(subject);
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
