using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EF.Configuration
{
	class ProfessorSubjectConfiguration : IEntityTypeConfiguration<ProfessorSubject>
	{
		public void Configure(EntityTypeBuilder<ProfessorSubject> builder)
		{
			builder.HasKey(s => new { s.ProfessorId, s.SubjectId });
			builder.HasOne(s => s.Professor).WithMany(p => p.Subjects).HasForeignKey(s=> s.ProfessorId);
			builder.HasOne(s => s.Subject).WithMany(s => s.Professors).HasForeignKey(s => s.SubjectId);
		}
	}
}