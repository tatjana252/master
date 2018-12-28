using System;

namespace Data.EF
{
	public abstract class Person
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string LastName { get; set; }
        public virtual int? CityId { get; set; }
		public virtual City City { get; set; }
		public DateTime DateOfBirth { get; set; }
	}
}
