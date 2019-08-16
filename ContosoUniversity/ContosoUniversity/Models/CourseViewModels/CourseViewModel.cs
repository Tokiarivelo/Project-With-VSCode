using System;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models.CourseViewModels
{
    public class CourseViewModel
    {
        [Display(Name = "Number")]
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        [Display(Name = " Department")]
        public string DepartmentName { get; set; }
    }
}
