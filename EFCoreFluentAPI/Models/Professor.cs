using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Data.EF
{
	public class Professor : Person
	{
		
		public virtual List<ProfessorSubject> Subjects { get; set; }
		public virtual List<ScientificArticle> Articles { get; set; }
	}
}
