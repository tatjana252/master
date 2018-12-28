using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EF.Configuration
{
	class GradeConfiguration : IEntityTypeConfiguration<Grade>
	{
		public void Configure(EntityTypeBuilder<Grade> builder)
		{
			builder.HasKey(c => new {c.StudentId, c.ProfessorId, c.SubjectId});
			builder.HasOne(p => p.ProfessorSubject).WithMany().HasForeignKey(g => new {g.ProfessorId, g.SubjectId}).OnDelete(DeleteBehavior.Restrict);
			builder.HasOne(g => g.Student).WithMany(s => s.Grades).HasForeignKey(g => g.StudentId).OnDelete(DeleteBehavior.Restrict);
		}
	}
}