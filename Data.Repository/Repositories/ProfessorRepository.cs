using Data.EF;
using Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
	public class ProfessorRepository : GenericRepository<Professor>, IProfessorRepository
	{
		public ProfessorRepository(DbContext dbContext) : base(dbContext)
		{

		}
	}
}