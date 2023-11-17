using System;
using FluentValidation;

namespace Notes.Application.Notes.Queries.GetNoteDetails
{
    public class GetNoteDetailsQuerryValidator: AbstractValidator<GetNoteDetalisQuerry>
    {
        public GetNoteDetailsQuerryValidator()
        {
            RuleFor(getDetailsQuerryNoteCommand =>
                getDetailsQuerryNoteCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(getDetailsQuerryNoteCommand =>
                getDetailsQuerryNoteCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
