using System;
using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Domain;

namespace Notes.Application.Notes.Queries.GetNoteDetails
{
	public class NoteDetailsVm : IMapWith<Note>
	{
		public Guid UserId { get; set; }
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public string Patronymic { get; set; }
		public DateTime BirstDay { get; set; }
		public float Ballance { get; set; }
		

		public void Mapping(Profile profile)
		{
			profile.CreateMap<Note, NoteDetailsVm>()
				.ForMember(noteVm => noteVm.Ballance,
					opt => opt.MapFrom(note => note.Ballance))
				.ForMember(noteVm => noteVm.LastName,
					opt => opt.MapFrom(note => note.LastName))
				.ForMember(noteVm => noteVm.FirstName,
					opt => opt.MapFrom(note => note.FirstName))
				.ForMember(noteVm => noteVm.Patronymic,
					opt => opt.MapFrom(note => note.Patronymic))
				.ForMember(noteVm => noteVm.BirstDay,
					opt => opt.MapFrom(note => note.BirstDay))
				.ForMember(noteVm => noteVm.UserId,
					opt => opt.MapFrom(note => note.UserId));				
		}
	}
}
