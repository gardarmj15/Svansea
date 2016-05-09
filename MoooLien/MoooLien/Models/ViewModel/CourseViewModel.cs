using MoooLien.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoooLien.Models.ViewModel
{
    public class CourseViewModel
    {
        public List<Course> courses { get; set; }
        public Course course { get; set; }
    }

    public class CreateCourseViewModel
    {
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
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-dd-MM}", ApplyFormatInEditMode = true)]
        public DateTime startDate { get; set; }

        [Required]
        public DateTime endDate { get; set; }

    }
}