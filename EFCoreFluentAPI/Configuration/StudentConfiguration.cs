using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EF.Configuration
{
	class StudentConfiguration : IEntityTypeConfiguration<Student>
	{
		public void Configure(EntityTypeBuilder<Student> builder)
		{
			builder.OwnsOne(s => s.StudentDetails);
			builder.HasBaseType<Person>();
			builder.ToTable("TStudent");
			builder.Property(s => s.EnrollmentYear).IsRequired();
			builder.Property(s => s.EnrollmentNum).IsRequired();
			builder.HasMany(s => s.Grades).WithOne(g => g.Student).HasForeignKey(g => g.StudentId);
		}
	}
}