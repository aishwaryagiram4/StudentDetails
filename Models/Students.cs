using NHibernate.Impl;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Xceed.Wpf.Toolkit;

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


        /* [DataType(DataType.Date)]
         [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
         [Display(Name = "Date")]
         [Required(ErrorMessage = "Date is mandatory")]*/
        [Required]
        public DateTime CratedDate { get; set; }


    }
}

