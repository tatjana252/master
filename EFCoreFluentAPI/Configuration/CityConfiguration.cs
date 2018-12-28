using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EF.Configuration
{
	class CityConfiguration : IEntityTypeConfiguration<City>
	{
		public void Configure(EntityTypeBuilder<City> builder)
		{
			builder.HasKey(c => c.Id);
			builder.HasAlternateKey(c => c.Name);
		}
	}
}
