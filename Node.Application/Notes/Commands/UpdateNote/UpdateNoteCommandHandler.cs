using MediatR;
using Notes.Application.Interfaces;
using Notes.Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using Notes.Domain;

namespace Notes.Application.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommandHandler 
        : IRequestHandler<UpdateNoteCommand>
    {
        private readonly INotesDBContext _dbContext;
        public UpdateNoteCommandHandler(INotesDBContext dbContext) => _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateNoteCommand reqest,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Notes.FirstOrDefaultAsync(note => note.Id == reqest.Id, cancellationToken);
            if ( entity ==null || entity.UserId != reqest.UserId)
            {
                throw new NotFoundException(nameof(Note), reqest.Id);
            }

            entity.Details = reqest.Details;
            entity.Title = reqest.Title;
            entity.EditDate = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }       
    }
}
