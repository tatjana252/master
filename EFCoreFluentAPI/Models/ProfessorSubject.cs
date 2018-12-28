using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EF
{
	public class ProfessorSubject
	{
		public int SubjectId { get; set; }
		public virtual Subject Subject { get; set; }

		public int ProfessorId { get; set; }
		public virtual Professor Professor { get; set; }
	}
}
