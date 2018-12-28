using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EF
{
	public class Student : Person
	{
		public int EnrollmentYear { get; set; }
		public int EnrollmentNum { get; set; }
		public virtual List<Grade> Grades { get; set; }
        public virtual StudentDetails StudentDetails { get; set; } = new StudentDetails();
	}
}
