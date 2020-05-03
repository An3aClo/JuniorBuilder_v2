using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JuniorBuilder.Models
{
    public class ResetPasswordModel
    {
        [Display(Name = "Security question: Where were you born?")]
        [Required]
        public string PasswordQuestionAnswer { get; set; }

        [Display(Name = "Email")]
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        [MinLength(10)]
        public string Password { get; set; }
    }
}