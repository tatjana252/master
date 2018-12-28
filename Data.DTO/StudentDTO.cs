using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DTO
{
	public class StudentDTO : PersonDTO
	{
		public int EnrollmentYear { get; set; }
		public int EnrollmentNum { get; set; }
		public List<GradeDTO> Grades { get; set; }
		public StudentDetailsDTO StudentDetails { get; set; }
	}
}
