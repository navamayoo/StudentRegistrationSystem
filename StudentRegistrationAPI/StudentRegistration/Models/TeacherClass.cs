using System.ComponentModel.DataAnnotations;

namespace StudentRegistration.Models
{
    public class TeacherClass
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        [Required]
        public int ClassId { get; set; }
        public Class Class { get; set; }



    }
}
