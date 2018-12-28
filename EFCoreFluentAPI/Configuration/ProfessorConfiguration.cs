using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EF.Configuration
{
	class ProfessorConfiguration : IEntityTypeConfiguration<Professor>
	{
		public void Configure(EntityTypeBuilder<Professor> builder)
		{
			builder.HasKey(s => s.Id);
			builder.Property(p => p.Id).ValueGeneratedOnAdd();
			builder.HasBaseType<Person>();
			builder.Property<DateTime>("DateCreated").HasDefaultValueSql("CONVERT(date, GETDATE())");
			builder.OwnsMany(p => p.Articles).HasKey(a => a.Id);
		}
	}
}