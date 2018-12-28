using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Data.EF.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.EF
{
	public class MASV2Context : DbContext
	{
		public DbSet<City> Cities { get; set; }
		public DbSet<Grade> Grades { get; set; }
		public DbSet<Professor> Professors { get; set; }
		public DbSet<Subject> Subjects { get; set; }
		public DbSet<Student> Students{ get; set; }


		//public IConfiguration configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
		//	.AddJsonFile("appsettings.json")
		//	.Build();

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			//optionsBuilder.UseSqlServer(configuration["connectionString"]);
			optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=MASV2; Trusted_Connection=true;");
			optionsBuilder.UseLazyLoadingProxies();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new CityConfiguration());
			modelBuilder.ApplyConfiguration(new GradeConfiguration());
			modelBuilder.ApplyConfiguration(new ProfessorSubjectConfiguration());
			modelBuilder.ApplyConfiguration(new ProfessorConfiguration());
			modelBuilder.ApplyConfiguration(new PersonConfiguration());
			modelBuilder.ApplyConfiguration(new SubjectConfiguration());
			modelBuilder.ApplyConfiguration(new StudentConfiguration());
		}
	}
}
