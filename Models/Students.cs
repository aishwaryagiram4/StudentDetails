using System;
using System.Collections.Generic;

namespace StudentDetails.Models
{
    public partial class Students
    {
        public long StudId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string DeptName { get; set; }
        public decimal Marks { get; set; }
        public DateTime CratedDate { get; set; }
    }
}
