using System;
using FluentValidation;

namespace Notes.Application.Notes.Commands.CreateNote
{
	public class CreateNoteCommandValidator : AbstractValidator<CreateNoteCommand>
	{
		public CreateNoteCommandValidator()
		{
			RuleFor(createNoteCommand =>
				createNoteCommand.Ballance);
			RuleFor(createNoteCommand =>
				createNoteCommand.UserId).NotEqual(Guid.Empty);
		}
	}
}
