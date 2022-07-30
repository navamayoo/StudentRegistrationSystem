using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentRegistration.Models
{
    public class Classroom
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string ClassroomName { get; set; }
        public List<Student> Students { get; set; }

        //Navigations Properties
        public List<TeacherClassroom> TeacherClassrooms { get; set; }
    }
}
