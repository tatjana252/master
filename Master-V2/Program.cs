using System;
using System.Collections.Generic;
using Data.DTO;
using Data.EF;
using Data.Repository;
using Service;

namespace Master_V2
{
	class Program
	{
		static void Main(string[] args)
		{
			ServiceBase<ProfessorDTO> service = new ProfessorService(new DBManagerUOW(new MASV2Context()));
			service.Insert(new ProfessorDTO()
			{
				Name = "Tatjana",
				LastName = "Stojanovic",
				City = new CityDTO()
				{
					Name = "Belgrade"
				}
			});
			var smt = service.GetAll();
		}
	}
}
