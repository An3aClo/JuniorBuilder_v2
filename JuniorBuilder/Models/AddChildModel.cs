using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JuniorBuilder.Models
{
    public class AddChildModel
    {
        [Display(Name = "Name")]
        [Required]
        public string Name { get; set; }

        //[Display(Name = "Email")]
        //[Required]
        //[EmailAddress]
        //public string EmailAddress { get; set; }

        //[Display(Name = "Password")]
        //[Required]
        //[DataType(DataType.Password)]
        //[MinLength(10)]
        //public string Password { get; set; }
    }
}