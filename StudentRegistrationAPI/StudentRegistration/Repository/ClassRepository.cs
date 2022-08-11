using StudentRegistration.Data;
using StudentRegistration.Interface;
using StudentRegistration.Models;
using System;
using System.Collections.Generic;

namespace StudentRegistration.Repository
{
    public class ClassRepository : IClassRepository
    {
        private readonly AppDbContext _context;

        public ClassRepository(AppDbContext context)
        {
            this._context = context;
        }
        public Class CreateClass(Class Class)
        {
            try
            {
                
               _context.Classes.Add(Class);
                _context.SaveChanges();
                return Class;
            }
            catch (Exception ex)
            {

                throw new Exception($"Unexpected error in controller when creating category: {ex.Message}");
            }
        }

        public Class DeleteClass(int id)
        {
            try
            {
               Class Class = _context.Classes.Find(id);
                if(Class != null)
                {
                    _context.Classes.Remove(Class);
                    _context.SaveChanges();
                   
                }

                return Class;
            }
            catch (Exception ex)
            {

                throw new Exception($"Unexpected error in controller when creating category: {ex.Message}");
            }
        }

        public IEnumerable<Class> GetAllClasses()
        {
            return _context.Classes; 
        }

        public Class GetClassById(int id)
        {
            return _context.Classes.Find(id);
        }

 

        public Class UpdateClass(Class ClassChange)
        {
            try
            {
               
                    var room = _context.Classes.Attach(ClassChange);
                    room.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                    _context.SaveChanges();

                    return ClassChange;
              

            }
            catch (Exception ex)
            {

                throw new Exception($"Unexpected error in controller when creating category: {ex.Message}");
            }
        }
    }
}
