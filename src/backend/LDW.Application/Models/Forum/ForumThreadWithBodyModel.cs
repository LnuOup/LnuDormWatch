using System;

namespace LDW.Application.Models.Forum
{
	public class ForumThreadWithBodyModel
	{
		public string ThreadTitle { get; set; }
		public string ThreadBody { get; set; }
		public string AuthorId { get; set; }
		public DateTime CreationDate { get; set; }
	}
}
