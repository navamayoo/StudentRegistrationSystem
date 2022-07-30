using StudentRegistration.Models;
using System.Collections.Generic;

namespace StudentRegistration.Interface
{
    public interface IClassroomRepository
    {

        IEnumerable<Classroom> GetAllClassrooms();
        Classroom GetClassroomById(int id);
        Classroom CreateClassroom(Classroom classroom);
        Classroom UpdateClassroom(Classroom classroomChange);
        Classroom DeleteClassroom(int id);
    }
}
