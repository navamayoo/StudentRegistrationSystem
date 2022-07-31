using StudentRegistration.Models;
using System.Collections.Generic;

namespace StudentRegistration.Interface
{
    public interface ITeacherClassroomRepository
    {

        IEnumerable<TeacherClassroom> GetAllTClassroom();
        TeacherClassroom GetTClassroomById(int id);
        TeacherClassroom CreateTClassroom(TeacherClassroom subject);
        TeacherClassroom UpdateTClassroom(TeacherClassroom subject, int id);
        TeacherClassroom DeleteTClassroom(int id);
    }
}
