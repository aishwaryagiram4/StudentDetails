using System;
using System.Collections.Generic;

namespace StudentDetails.Models
{
    public partial class Register
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public DateTime CratedDate { get; set; }
    }
}
