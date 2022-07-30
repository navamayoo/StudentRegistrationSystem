using StudentRegistration.Models;
using System.Collections.Generic;

namespace StudentRegistration.Interface
{
    public interface ITeacherClassroomRepository
    {

        IEnumerable<TeacherClassroom> GetAllSubjects();
        TeacherClassroom GetSubjectById(int id);
        TeacherClassroom CreateSubject(TeacherClassroom subject);
        TeacherClassroom UpdateSubject(TeacherClassroom subject, int id);
        TeacherClassroom DeleteSubject(int id);
    }
}
