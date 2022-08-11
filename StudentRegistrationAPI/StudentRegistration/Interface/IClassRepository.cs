using StudentRegistration.Models;
using System.Collections.Generic;

namespace StudentRegistration.Interface
{
    public interface IClassRepository
    {

        IEnumerable<Class> GetAllClasses();
        Class GetClassById(int id);
        Class CreateClass(Class Class);
        Class UpdateClass(Class ClassChange);
        Class DeleteClass(int id);
    }
}
