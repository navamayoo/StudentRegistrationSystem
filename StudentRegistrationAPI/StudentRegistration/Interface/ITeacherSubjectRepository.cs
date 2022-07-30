using StudentRegistration.Models;
using System.Collections.Generic;

namespace StudentRegistration.Interface
{
    public interface ITeacherSubjectRepository
    {

        IEnumerable<TeacherSubject> GetAllSubjects();
        TeacherSubject GetSubjectById(int id);
        TeacherSubject CreateSubject(TeacherSubject subject);
        TeacherSubject UpdateSubject(TeacherSubject subject, int id);
        TeacherSubject DeleteSubject(int id);
    }
}
