using AutoMapper;
using System;
using Notes.Application.Common.Mappings;
using Notes.Application.Notes.Commands.UpdateNote;

namespace Notes.WebApi.Models
{
	public class UpdateNoteDto : IMapWith<UpdateNoteCommand>
	{
		public Guid UserId { get; set; }
		public float Ballance { get; set; }		

		public void Mapping(Profile profile)
		{
			profile.CreateMap<UpdateNoteDto, UpdateNoteCommand>()
				.ForMember(noteCommand => noteCommand.UserId,
					opt => opt.MapFrom(noteDto => noteDto.UserId))
				.ForMember(noteCommand => noteCommand.Ballance,
					opt => opt.MapFrom(noteDto => noteDto.Ballance));				
		}
	}
}
