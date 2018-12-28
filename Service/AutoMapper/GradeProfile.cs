using AutoMapper;
using Data.DTO;
using Data.EF;

namespace Service.AutoMapper
{
	public class GradeProfile : Profile
	{
		public GradeProfile()
		{
			CreateMap<Grade, GradeDTO>();
		}
	}
}