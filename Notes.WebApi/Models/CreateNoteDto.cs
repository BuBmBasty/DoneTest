using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Application.Notes.Commands.CreateNote;
using System.ComponentModel.DataAnnotations;

namespace Notes.WebApi.Models
{
	public class CreateNoteDto : IMapWith<CreateNoteCommand>
	{
		[Required]
		public float Ballance { get; set; }
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		public string Patronymic { get; set; }
		[Required]
		public DateTime BirstDay { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<CreateNoteDto, CreateNoteCommand>()
				.ForMember(noteCommand => noteCommand.Ballance,
					opt => opt.MapFrom(noteDto => noteDto.Ballance))
				.ForMember(noteCommand => noteCommand.FirstName,
					opt => opt.MapFrom(noteDto => noteDto.FirstName))
				.ForMember(noteCommand => noteCommand.LastName,
					opt => opt.MapFrom(noteDto => noteDto.LastName))
				.ForMember(noteCommand => noteCommand.Patronymic,
					opt => opt.MapFrom(noteDto => noteDto.Patronymic))
				.ForMember(noteCommand => noteCommand.BirstDay,
					opt => opt.MapFrom(noteDto => noteDto.BirstDay));
		}
	}
}
