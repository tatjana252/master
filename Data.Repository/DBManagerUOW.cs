using Data.EF;
using Data.Repository.Interfaces;

namespace Data.Repository
{
    public class DBManagerUOW : IDbManagerUOW
	{
		public DBManagerUOW(MASV2Context masv2Context)
		{
			Masv2Context = masv2Context;
			CityRepository = new CityRepository(masv2Context);
			ProfessorRepository = new ProfessorRepository(masv2Context);
			StudentRepository = new StudentRepository(masv2Context);
			SubjectRepository = new SubjectRepository(masv2Context);
		}

		private MASV2Context Masv2Context { get; }


		public ICityRepository CityRepository { get; }
		public IProfessorRepository ProfessorRepository { get; }
		public IStudentRepository StudentRepository { get;  }
		public ISubjectRepository SubjectRepository { get; }

		public void Save()
		{
			Masv2Context.SaveChanges();
		}

        public void Dispose()
        {
            Masv2Context.Dispose();
        }

    }
}
