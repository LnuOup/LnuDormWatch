using System;

namespace LDW.Application.Models.Forum
{
	public class ForumThreadWithBodyModel
	{
		public Guid Id { get; set; }
		public string ThreadTitle { get; set; }
		public string ThreadBody { get; set; }
		public string AuthorId { get; set; }
		public DateTime CreationDate { get; set; }
		public ForumAuthorInfo AuthorInfo { get; set; }
	}
}
