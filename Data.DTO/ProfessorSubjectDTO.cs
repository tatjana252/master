using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DTO
{
	public class ProfessorSubjectDTO
	{
		public int SubjectId { get; set; }
		public SubjectDTO Subject { get; set; }

		public int ProfessorId { get; set; }
		public ProfessorDTO Professor { get; set; }
	}

	public class SubjectDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<ProfessorSubjectDTO> Professors { get; set; }
	}
}
