using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.EF;
using Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
	public class StudentRepository : GenericRepository<Student>, IStudentRepository
	{
		public StudentRepository(DbContext dbContext) : base(dbContext)
		{

		}

        public override IQueryable<Student> GetAll()
        {
            return base.GetAll().Include(s => s.City);
        }
    }
}
