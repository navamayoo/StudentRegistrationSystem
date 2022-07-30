using StudentRegistration.Data;
using StudentRegistration.Interface;
using StudentRegistration.Models;
using System;
using System.Collections.Generic;

namespace StudentRegistration.Repository
{
    public class ClassroomRepository : IClassroomRepository
    {
        private readonly AppDbContext _context;

        public ClassroomRepository(AppDbContext context)
        {
            this._context = context;
        }
        public Classroom CreateClassroom(Classroom classroom)
        {
            try
            {
               _context.Classrooms.Add(classroom);
                _context.SaveChanges();
                return classroom;
            }
            catch (Exception ex)
            {

                throw new Exception($"Unexpected error in controller when creating category: {ex.Message}");
            }
        }

        public Classroom DeleteClassroom(int id)
        {
            try
            {
               Classroom classroom = _context.Classrooms.Find(id);
                if(classroom != null)
                {
                    _context.Classrooms.Remove(classroom);
                    _context.SaveChanges();
                   
                }

                return classroom;
            }
            catch (Exception ex)
            {

                throw new Exception($"Unexpected error in controller when creating category: {ex.Message}");
            }
        }

        public IEnumerable<Classroom> GetAllClassrooms()
        {
            return _context.Classrooms; 
        }

        public Classroom GetClassroomById(int id)
        {
            return _context.Classrooms.Find(id);
        }

 

        public Classroom UpdateClassroom(Classroom classroomChange)
        {
            try
            {
               
                    var room = _context.Classrooms.Attach(classroomChange);
                    room.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                    _context.SaveChanges();

                    return classroomChange;
              

            }
            catch (Exception ex)
            {

                throw new Exception($"Unexpected error in controller when creating category: {ex.Message}");
            }
        }
    }
}
