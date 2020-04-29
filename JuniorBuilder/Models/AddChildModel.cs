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
    }
}