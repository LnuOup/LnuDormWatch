using System;

namespace LDW.Application.Models.Forum
{
	public class ForumThreadModel
	{
		public Guid Id { get; set; }
		public string ThreadTitle { get; set; }
		public string AuthorId { get; set; }
		public Guid ForumSectionId { get; set; }
		public DateTime CreationDate { get; set; }
		public int NumberOfReplies { get; set; }
		public DateTime? LastReply { get; set; }
	}
}
