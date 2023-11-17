using MediatR;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Notes.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Notes.Application.Notes.Queries.GetNoteList
{
    internal class GetNoteListQueryHandler
        : IRequestHandler<GetNoteListQuery, NoteListVm>
    {
        private readonly INotesDBContext _dbContext;
        private readonly IMapper _mapper;

        public GetNoteListQueryHandler(INotesDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<NoteListVm> Handle(GetNoteListQuery request, CancellationToken cancellationToken)
        {
            var notesQuerry = await _dbContext.Notes.Where(note => note.UserId == request.UserId)
                .ProjectTo<NoteLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new NoteListVm {Notes = notesQuerry};
        }
    }
}
