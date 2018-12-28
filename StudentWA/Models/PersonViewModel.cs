using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace WA2.Models
{
	public class PersonViewModel
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Name is required field!")]
		public string Name { get; set; }
		[Required]
		public string LastName { get; set; }

        public int? CityId { get; set; }
		public CityViewModel City { get; set; }
		//public CityDTO City { get; set; }
	}
}
