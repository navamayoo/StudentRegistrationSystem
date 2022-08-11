using StudentRegistration.Models;
using System.Collections.Generic;

namespace StudentRegistration.Interface
{
    public interface ITeacherClassRepository
    {

        IEnumerable<TeacherClass> GetAllTeacherClass();
        TeacherClass GetTeacherClassById(int id);
        TeacherClass CreateTeacherClass(TeacherClass subject);
        TeacherClass UpdateTeacherClass(TeacherClass subject, int id);
        TeacherClass DeleteTeacherClass(int id);
    }
}
