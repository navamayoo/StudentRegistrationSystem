using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentRegistration.Models
{
    public class Class
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }

        //Navigations Properties
        public ICollection<TeacherClass> TeacherClasses { get; set; }
    }
}
