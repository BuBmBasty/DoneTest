using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notes.Domain;

namespace Notes.Persistence.EntityTypeConfigurations
{
	public class NoteConfiguration : IEntityTypeConfiguration<Note>
	{
		public void Configure(EntityTypeBuilder<Note> builder)
		{
			builder.HasKey(note => note.UserId);
			builder.HasIndex(note => note.UserId).IsUnique();
			builder.Property(note => note.FirstName).HasMaxLength(250);
			builder.Property(note => note.LastName).HasMaxLength(250);
			builder.Property(note => note.Patronymic).HasMaxLength(250);
			builder.Property(note => note.Ballance).HasMaxLength(250);
		}
	}
}
