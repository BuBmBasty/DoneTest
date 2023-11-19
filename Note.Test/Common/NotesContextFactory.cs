using System;
using Microsoft.EntityFrameworkCore;
using Notes.Domain;
using Notes.Persistence;

namespace Notes.Tests.Common
{
	public class NotesContextFactory
	{
		public static Guid UserAId = Guid.NewGuid();
		public static Guid UserBId = Guid.NewGuid();

		public static Guid NoteIdForDelete = Guid.NewGuid();
		public static Guid NoteIdForUpdate = Guid.NewGuid();

		public static NotesDbContext Create()
		{
			var options = new DbContextOptionsBuilder<NotesDbContext>()
				.UseInMemoryDatabase(Guid.NewGuid().ToString())
				.Options;
			var context = new NotesDbContext(options);
			context.Database.EnsureCreated();
			context.Notes.AddRange(
				new Note
				{
					CreationDate = DateTime.Today,
					Details = "Details1",
					EditDate = null,
					Id = Guid.Parse("C4ED8D75-FE50-4502-8AFE-78E6FDA554BD"),
					Title = "Title1",
					UserId = UserAId
				},
				new Note
				{
					CreationDate = DateTime.Today,
					Details = "Details2",
					EditDate = null,
					Id = Guid.Parse("5DFBCA92-36B5-42DB-9955-92C62DF606CE"),
					Title = "Title2",
					UserId = UserBId
				},
				new Note
				{
					CreationDate = DateTime.Today,
					Details = "Details3",
					EditDate = null,
					Id = NoteIdForDelete,
					Title = "Title3",
					UserId = UserAId
				},
				new Note
				{
					CreationDate = DateTime.Today,
					Details = "Details4",
					EditDate = null,
					Id = NoteIdForUpdate,
					Title = "Title4",
					UserId = UserBId
				}
			);
			context.SaveChanges();
			return context;
		}

		public static void Destroy(NotesDbContext context)
		{
			context.Database.EnsureDeleted();
			context.Dispose();
		}
	}
}
