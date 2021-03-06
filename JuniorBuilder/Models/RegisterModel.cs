﻿using System.ComponentModel.DataAnnotations;

namespace JuniorBuilder.Models
{
    public class RegisterModel
    {
        [Display(Name = "Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Email")]
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Display(Name = "Security question: Where were you born?")]
        [Required]
        public string PasswordQuestionAnswer { get; set; }

        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        [MinLength(10)]
        public string Password { get; set; }
    }
}