using StudentRegistration.Data;
using StudentRegistration.Models;
using SubjectRegistration.Interface;
using System.Collections.Generic;
using System;

namespace StudentRegistration.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly AppDbContext _context;

        public SubjectRepository(AppDbContext context)
        {
            this._context = context;
        }
        public Subject CreateSubject(Subject subject)
        {
            try
            {
                _context.Subjects.Add(subject);
                _context.SaveChanges();
                return subject;
            }
            catch (Exception ex)
            {

                throw new Exception($"Unexpected error in controller when creating category: {ex.Message}");
            }
        }

        public Subject DeleteSubject(int id)
        {
            try
            {
               Subject subject = _context.Subjects.Find(id);

                if(subject != null)
                {
                    _context.Subjects.Remove(subject);
                    _context.SaveChanges();

                   

                }
                return subject;

            }
            catch (Exception ex)
            {

                throw new Exception($"Unexpected error in controller when creating category: {ex.Message}");
            }
        }

        public IEnumerable<Subject> GetAllSubjects()
        {
            return _context.Subjects;
        }

        public Subject GetSubjectById(int id)
        {
            return _context.Subjects.Find(id);
        }

        public Subject UpdateSubject(Subject subject, int id)
        {
            try
            {
                if (id == subject.Id)
                {
                   var _subject = _context.Subjects.Attach(subject);
                    _subject.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
                return subject;
            }
            catch (Exception ex)
            {

                throw new Exception($"Unexpected error in controller when creating category: {ex.Message}");
            }

        }
    }
}
