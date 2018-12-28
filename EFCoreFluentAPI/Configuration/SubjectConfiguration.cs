using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EF.Configuration
{
	class SubjectConfiguration : IEntityTypeConfiguration<Subject>
	{
		public void Configure(EntityTypeBuilder<Subject> builder)
		{
			builder.HasKey(c => c.Id);
			//builder.HasMany(s => s.Professors).WithOne(p => p.Subject);
		}
	}
}