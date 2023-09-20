using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectinMVC.Models
{
    public class User
    {
        public int U_Id { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "Name length should be more than 2 and can't be more than 10")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "Name length should be more than 2 and can't be more than 10")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [NotMapped]
        [Compare("Password", ErrorMessage = "Password does not matched")]
        public string ConfirmPassword { get; set; }
    }
}