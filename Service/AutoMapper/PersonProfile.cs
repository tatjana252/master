using AutoMapper;
using Data.DTO;
using Data.EF;

namespace Service.AutoMapper
{
	public class PersonProfile : Profile
	{
		public PersonProfile()
		{
			CreateMap<Person, PersonDTO>();
            CreateMap<City, CityDTO>();
            CreateMap<CityDTO, City>();
        }
	}
}