using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using Notes.Domain;
using Notes.Application.Common.Exceptions;

namespace Notes.Application.Notes.Queries.GetNoteDetails
{
    public class GetNoteDetalisQuerryHandler
        : IRequestHandler<GetNoteDetalisQuerry, NoteDetailsVm>
    {
        private readonly INotesDBContext _dBContext;
        private readonly IMapper _mapper;

        public GetNoteDetalisQuerryHandler(INotesDBContext dBContext, IMapper mapper)=>(_dBContext, _mapper) = (dBContext, mapper);
        

        public async Task<NoteDetailsVm> Handle(GetNoteDetalisQuerry request, CancellationToken cancellationToken)
        {
            var entity = await _dBContext.Notes
                .FirstOrDefaultAsync(note => note.Id == request.Id, cancellationToken);
            if (entity == null || entity.UserId != request.UserId) 
            { 
                throw new NotFoundException(nameof(Note), request.Id);
            }

            return _mapper.Map<NoteDetailsVm>(entity);
        }
    }
}
