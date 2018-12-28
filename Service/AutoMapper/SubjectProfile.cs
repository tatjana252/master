using AutoMapper;
using Data.DTO;
using Data.EF;

namespace Service.AutoMapper
{
	public class SubjectProfile : Profile
	{
		public SubjectProfile()
		{
			CreateMap<Subject, SubjectDTO>();
		}
	}
}