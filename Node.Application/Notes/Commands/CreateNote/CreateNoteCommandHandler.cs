using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Notes.Application.Interfaces;
using Notes.Domain;

namespace Notes.Application.Notes.Commands.CreateNote
{
	public class CreateNoteCommandHandler
		: IRequestHandler<CreateNoteCommand, Guid>
	{
		private readonly INotesDbContext _dbContext;

		public  CreateNoteCommandHandler(INotesDbContext dbContext) =>
			_dbContext = dbContext;

		public async Task<Guid> Handle(CreateNoteCommand request,
			CancellationToken cancellationToken)
		{
			var note = new Note
			{
				UserId = request.UserId,
				FirstName = request.FirstName,
				LastName = request.LastName,
				Patronymic = request.Patronymic,
				BirstDay = request.BirstDay,
				Ballance = request.Ballance,												
			};

			return note.UserId;
		}
	}
}
