using Data.EF;
using Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
	public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
	{
		public SubjectRepository(DbContext dbContext) : base(dbContext)
		{

		}
	}
}