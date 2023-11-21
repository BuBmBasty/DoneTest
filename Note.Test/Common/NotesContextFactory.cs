using System;
using Microsoft.EntityFrameworkCore;
using Notes.Domain;
using Notes.Persistence;

namespace Notes.Tests.Common
{
	public class NotesContextFactory
	{
		public static Guid[] UserAId = new Guid[50];
		public static float startBallance = 500;

		public static NotesDbContext Create()
		{
			var options = new DbContextOptionsBuilder<NotesDbContext>()
				.UseInMemoryDatabase(Guid.NewGuid().ToString())
				.Options;
			var context = new NotesDbContext(options);
			for (int i =0; i < UserAId.Length; i++)
			{
				UserAId[i]= Guid.NewGuid();
				context.Database.EnsureCreated();
				context.Notes.AddRange(
					new Note
					{
						FirstName = "FirstName"+i.ToString(),
						LastName = "LastName" + i.ToString(),
						Patronymic = "Patronymic" + i.ToString(),
						BirstDay = DateTime.Today,
						Ballance = startBallance + i,
						UserId = UserAId[i]
					}
				);
				context.SaveChanges();
			}		

			return context;
		}

		public static void Destroy(NotesDbContext context)
		{
			context.Database.EnsureDeleted();
			context.Dispose();
		}
	}
}
