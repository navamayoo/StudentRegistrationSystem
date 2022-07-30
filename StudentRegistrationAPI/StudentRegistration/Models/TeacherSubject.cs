using System.ComponentModel.DataAnnotations;

namespace StudentRegistration.Models
{
    public class TeacherSubject
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        [Required]
        public int SubjectId { get; set; }
        public Subject Subject{ get; set; }




    }
}
