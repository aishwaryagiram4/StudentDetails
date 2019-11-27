using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentDetails.Models
{
    public partial class RegisterTable
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        [Required]
        public DateTime CratedDate { get; set; }
    }
}
