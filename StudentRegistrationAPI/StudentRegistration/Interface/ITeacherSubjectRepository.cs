using StudentRegistration.Models;
using System.Collections.Generic;

namespace StudentRegistration.Interface
{
    public interface ITeacherSubjectRepository
    {

        IEnumerable<TeacherSubject> GetAllTSubjects();
        TeacherSubject GetTSubjectById(int id);
        TeacherSubject CreateTSubject(TeacherSubject subject);
        TeacherSubject UpdateTSubject(TeacherSubject subject, int id);
        TeacherSubject DeleteTSubject(int id);
    }
}
