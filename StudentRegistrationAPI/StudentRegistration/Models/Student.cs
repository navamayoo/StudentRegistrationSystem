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
        public string Email { get; set; }
        [Required]
        public string DateOfBirth { get; set; }

        //Navigations Properties
        [Required]
        public int? ClassId { get; set; }
        public Class Class { get; set; }


    }
}
