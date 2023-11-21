using System;

namespace Notes.Domain
{
	public class Note
	{
		public Guid UserId { get; set; }
		//public Guid Id { get; set; }
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public string Patronymic { get; set; }
		public DateTime BirstDay { get; set; }
		public float Ballance { get; set; }
		
	}
}
