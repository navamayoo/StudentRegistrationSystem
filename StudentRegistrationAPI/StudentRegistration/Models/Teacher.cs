﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentRegistration.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string FirstName { get; set; }

        [StringLength (100)]
        public string LastName { get; set; }
        [Required,StringLength (100)]
        public string ContactNo { get; set; }

        [Required, StringLength(200)]
        public string Email { get; set; }

        //Navigations Properties
        public ICollection<TeacherClass> TeacherClasses { get; set; }

        public ICollection<TeacherSubject> TeacherSubjects { get; set; }


    }
}
