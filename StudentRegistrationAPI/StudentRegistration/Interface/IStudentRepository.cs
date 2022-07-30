using StudentRegistration.Models;
using System.Collections.Generic;

namespace StudentRegistration.Interface
{
    public interface IStudentRepository
    {

        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int id);
        Student CreateStudent(Student student);
        Student UpdateStudent(Student student, int id);
        Student DeleteStudent(int id);
    }
}
