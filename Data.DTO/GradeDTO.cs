using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DTO
{
	public class GradeDTO
	{
		public int ProfessorId { get; set; }
		public int SubjectId { get; set; }
		public int StudentId { get; set; }

		public ProfessorSubjectDTO ProfessorSubject { get; set; }
		public StudentDTO Student { get; set; }
		public int StudentsGrade { get; set; }
		public DateTime Date { get; set; }

	}
}
