using AutoMapper;
using Data.DTO;
using Data.EF;

namespace Service.AutoMapper
{
public class ProfessorProfile : Profile
	{
		public ProfessorProfile()
		{
			CreateMap<Professor, ProfessorDTO>();
			CreateMap<ProfessorDTO, Professor>();
			CreateMap<ProfessorSubject, ProfessorSubjectDTO>();
			CreateMap<ScientificArticle, ScientificArticleDTO>();
		}
	}
}
