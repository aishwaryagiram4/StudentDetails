using System;
using System.ComponentModel.DataAnnotations;

namespace StudentDetails.Models
{
    public partial class Students
    {
        [Required]
        public long StudId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string DeptName { get; set; }
        [Required]
        public decimal Marks { get; set; }
        [Required]
       public DateTime CratedDate { get; set;}
    }
}
