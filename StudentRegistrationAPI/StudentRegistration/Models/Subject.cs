using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentRegistration.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string SubjectName { get; set; }

        //Navigations Properties
        public List<TeacherSubject> TeacherSubjects { get; set; }

    }
}
