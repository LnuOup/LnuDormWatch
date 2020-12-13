using LDW.Domain.Entities.Common;
using System;
using System.Collections.Generic;

namespace LDW.Domain.Entities
{
	public class ForumThreadReplyEntity : BaseEntity<Guid>
	{
		public Guid AuthorId { get; set; }
		public string ReplyBody { get; set; }
		public string ParentForumThreadId { get; set; }
		public Guid? ParentForumThreadReplyId { get; set; }
		public DateTime CreationDate { get; set; }

		public UserRefEntity Author { get; set; }
		public ForumThreadEntity ForumThread { get; set; }
		public ForumThreadReplyEntity ParentForumThreadReply { get; set; }
		public ICollection<ForumThreadReplyEntity> ForumThreadReplies { get; set; }
	}
}
