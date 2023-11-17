using System;
using FluentValidation;

namespace Notes.Application.Notes.Queries.GetNoteList
{
    public class GetNoteListQuerryValidator: AbstractValidator<GetNoteListQuery>
    {
        public GetNoteListQuerryValidator()
        {
            RuleFor(getNoteListQuerryNoteCommand =>
                getNoteListQuerryNoteCommand.UserId).NotEqual(Guid.Empty);            
        }
    }
}
