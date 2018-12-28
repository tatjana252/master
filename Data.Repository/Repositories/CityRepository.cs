using Data.EF;
using Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
	public class CityRepository : GenericRepository<City>, ICityRepository
	{
		public CityRepository(DbContext dbContext) : base(dbContext)
		{

		}
	}
}