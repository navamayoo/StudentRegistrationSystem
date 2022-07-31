using StudentRegistration.Data;
using StudentRegistration.Interface;
using StudentRegistration.Models;
using System.Collections.Generic;
using System;

namespace StudentRegistration.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly AppDbContext _contxt;

        public TeacherRepository(AppDbContext contxt)
        {
            this._contxt = contxt;
        }
        public Teacher CreateTeacher(Teacher teacher)
        {
            try
            {
                _contxt.Teachers.Add(teacher);
                _contxt.SaveChanges();
                return teacher;
            }
            catch (Exception ex)
            {

                throw new Exception($"Unexpected error in controller when creating category: {ex.Message}");
            }
        }

        public Teacher DeleteTeacher(int id)
        {
            try
            {
                Teacher teacher = _contxt.Teachers.Find(id);
                if(teacher != null)
                {
                    _contxt.Teachers.Remove(teacher);
                    _contxt.SaveChanges();
                }
                return teacher;
            }
            catch (Exception ex)
            {
                throw new Exception($"Unexpected error in controller when creating category: {ex.Message}");
            }
        }

        public IEnumerable<Teacher> GetAllTeachers()
        {
            return _contxt.Teachers;    
        }

        public Teacher GetTeacherById(int id)
        {
            return _contxt.Teachers.Find(id);
        }

        public Teacher UpdateTeacher(Teacher teacher, int id)
        {
            try
            {
                if(id == teacher.Id)
                {
                    var _teacher = _contxt.Teachers.Attach(teacher);
                    _teacher.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _contxt.SaveChanges();
                }
                return teacher;

            }
            catch (Exception ex)
            {
                throw new Exception($"Unexpected error in controller when creating category: {ex.Message}");
            }
        }
    }
}
