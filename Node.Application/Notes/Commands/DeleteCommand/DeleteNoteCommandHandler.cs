using MediatR;
using Notes.Application.Interfaces;
using Notes.Application.Common.Exceptions;
using Notes.Domain;


namespace Notes.Application.Notes.Commands.DeleteCommand
{
    public class DeleteNoteCommandHandler
        : IRequestHandler<DeleteNoteCommand>
    {
        private readonly INotesDBContext _dbContext;
        public DeleteNoteCommandHandler(INotesDBContext dbContext) => _dbContext = dbContext;
        public async Task<Unit> Handler (DeleteNoteCommand request, CancellationToken   cancellationToken)
        {
            var entity = await _dbContext.Notes
                .FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null || entity.UserId!=request.UserId ) 
            {
                throw new NotFoundException(nameof (Note), request.Id);
            }
            _dbContext.Notes .Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
        public Task? Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            return null;
        }

        Task<Unit> IRequestHandler<DeleteNoteCommand, Unit>.Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
