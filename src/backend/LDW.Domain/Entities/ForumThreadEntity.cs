using LDW.Domain.Entities.Common;
using System;
using System.Collections.Generic;

namespace LDW.Domain.Entities
{
	public class ForumThreadEntity : BaseEntity<Guid>
	{
		public string ThreadTitle { get; set; }
		public string ThreadBody { get; set; }
		public string AuthorId { get; set; }
		public Guid ForumSectionId { get; set; }
		public DateTime CreationDate { get; set; }
		
		public UserRefEntity Author { get; set; }
		public ForumSectionEntity ForumSection { get; set; }
		public ICollection<ForumThreadReplyEntity> ForumThreadReplies { get; set; }
	}
}
