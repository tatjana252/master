using System;

namespace Data.DTO
{
	public abstract class PersonDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string LastName { get; set; }
        public int? CityId { get; set; }
		public CityDTO City { get; set; }
	}
}
