using AutoMapper;
using Data.DTO;
using Data.EF;

namespace Service.AutoMapper
{
	public class StudentProfile : Profile
	{
		public StudentProfile()
		{
			CreateMap<Student, StudentDTO>();
			CreateMap<StudentDetails, StudentDetailsDTO>();
		}
	}
}