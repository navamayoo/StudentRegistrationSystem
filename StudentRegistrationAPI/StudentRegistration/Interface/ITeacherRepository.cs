
using StudentRegistration.Models;
using System.Collections.Generic;

namespace StudentRegistration.Interface
{
    public interface ITeacherRepository
    {
        IEnumerable<Teacher> GetAllTeachers();
        Teacher GetTeacherById(int id);
        Teacher CreateTeacher(Teacher teacher);
        Teacher UpdateTeacher(Teacher teacher, int id);
        Teacher DeleteTeacher(int id);
    }
}
