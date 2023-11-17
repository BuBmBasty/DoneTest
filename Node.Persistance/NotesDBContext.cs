using Notes.Persistance.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using Notes.Domain;

namespace Notes.Persistance
{
    public class NotesDBContext: DbContext, INotesDBContext
    {
        public DbSet<Note> Notes { get; set;}
        public NotesDBContext(DbContextOptions<NotesDBContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new NoteConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
