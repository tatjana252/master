using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EF
{
	public class Grade
	{
		public int ProfessorId { get; set; }
		public int SubjectId { get; set; }
		public int StudentId { get; set; }

		public virtual ProfessorSubject ProfessorSubject { get; set; }
		public virtual Student Student { get; set; }
		public int StudentsGrade { get; set; }
		public DateTime Date { get; set; }

	}
}
