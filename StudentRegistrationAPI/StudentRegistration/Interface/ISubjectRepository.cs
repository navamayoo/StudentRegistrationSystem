using StudentRegistration.Models;
using System.Collections.Generic;

namespace SubjectRegistration.Interface
{
    public interface ISubjectRepository
    {
        IEnumerable<Subject> GetAllSubjects();
        Subject GetSubjectById(int id);
        Subject CreateSubject(Subject subject);
        Subject UpdateSubject(Subject subject, int id);
        Subject DeleteSubject(int id);
    }
}
