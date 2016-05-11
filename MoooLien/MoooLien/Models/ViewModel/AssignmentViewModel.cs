using MoooLien.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoooLien.Models.ViewModel
{
    public class AssignmentViewModel
    {
        public List<Assignment> assignments { get; set; }
        public Assignment assignment { get; set; }
    }
    public class CreateAssignmentViewModel
    {
        public int courseID { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        [StringLength(100, ErrorMessage = "Enter a valid name for Course", MinimumLength = 2)]
        public string name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Description")]
        public string description { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Solution")]
        public string solution { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "StartDate")]
        public DateTime startDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "EndDate")]
        public DateTime endDate { get; set; }
    }
}