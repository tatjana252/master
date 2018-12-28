using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WA2.Models
{
    public class StudentViewModel : PersonViewModel
    {
        [Range(1000, 3000, ErrorMessage = "Enrollment year must be a value between 1000 and 3000")]
        [Required(ErrorMessage = "Enrollment year is required field!")]
        public int? EnrollmentYear { get; set; }

        [Range(1, 9999, ErrorMessage = "Enrollment number must be a value between 1 and 9999")]
        [Required(ErrorMessage = "Enrollment number is required field!")]
        public int? EnrollmentNum { get; set; }
        //public List<GradeDTO> Grades { get; set; }
        //public StudentDetailsDTO StudentDetails { get; set; }

        [Browsable(false)]
        public List<CityViewModel> Cities { get; set; }
    }
}
