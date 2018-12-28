using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EF.Configuration
{
	class PersonConfiguration : IEntityTypeConfiguration<Person>
	{
		public void Configure(EntityTypeBuilder<Person> builder)
		{
			builder.HasOne(p => p.City).WithMany().HasForeignKey(p => p.CityId);
			builder.HasKey(s => s.Id);
			builder.Property(p => p.Id).ValueGeneratedOnAdd();

		}
	}
}