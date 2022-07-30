using System.ComponentModel.DataAnnotations;

namespace StudentRegistration.Models
{
    public class TeacherClassroom
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        [Required]
        public int ClassroomId { get; set; }
        public Classroom Classroom { get; set; }



    }
}
