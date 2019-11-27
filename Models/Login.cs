using System;
using System.Collections.Generic;

namespace StudentDetails.Models
{
    public partial class Login
    {
        public string EmailId { get; set; }
        public string Password { get; set; }
        public DateTime CratedDate { get; set; }
    }
}
