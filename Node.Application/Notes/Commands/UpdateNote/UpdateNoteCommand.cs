using System;
using MediatR;

namespace Notes.Application.Notes.Commands.UpdateNote
{
	public class UpdateNoteCommand : IRequest
	{
		public Guid UserId { get; set; }
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public string Patronymic { get; set; }
		public DateTime BirstDay { get; set; }
		public float Ballance { get; set; }
		
	}
}
