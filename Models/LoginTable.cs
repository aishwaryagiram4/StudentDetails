using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentDetails.Models
{
    public partial class LoginTable
    {
        [Required]
        public string EmailId { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
