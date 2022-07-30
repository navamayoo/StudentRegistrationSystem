using System.ComponentModel.DataAnnotations;

namespace StudentRegistration.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        [Required]
        [StringLength(200)]
        public string ContactPerson { get; set; }
        [Required]
        public string ContactNo { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        public string Dateofbirth { get; set; }

        //Navigations Properties
        [Required]
        public int? ClassroomId { get; set; }
        public Classroom Classroom { get; set; }


    }
}
