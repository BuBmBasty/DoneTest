using AutoMapper;
using System;
using Notes.Application.Common.Mappings;
using Notes.Domain;

namespace Notes.Application.Notes.Queries.GetNoteList
{
	public class NoteLookupDto : IMapWith<Note>
	{
		public Guid UserId { get; set; }
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public string Patronymic { get; set; }
		public DateTime BirstDay { get; set; }
		public float Ballance { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<Note, NoteLookupDto>()
				.ForMember(noteDto => noteDto.UserId,
					opt => opt.MapFrom(note => note.UserId))
				.ForMember(noteDto => noteDto.LastName,
					opt => opt.MapFrom(note => note.LastName))
				.ForMember(noteDto => noteDto.FirstName,
					opt => opt.MapFrom(note => note.FirstName))
				.ForMember(noteDto => noteDto.Patronymic,
					opt => opt.MapFrom(note => note.Patronymic))
				.ForMember(noteDto => noteDto.BirstDay,
					opt => opt.MapFrom(note => note.BirstDay))
				.ForMember(noteDto => noteDto.Ballance,
					opt => opt.MapFrom(note => note.Ballance));
		}
	}
}
