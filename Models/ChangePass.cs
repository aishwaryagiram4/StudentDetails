using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentDetails.Models
{
    public partial class ChangePass
    {
        [Required]
        public string EmailId { get; set; }
        [Required]
        public string NewPassword { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
    }
}
