using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EF
{
	public class Subject
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public virtual List<ProfessorSubject> Professors { get; set; }
	}
}
