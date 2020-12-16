using System;
using System.Collections.Generic;
using System.Text;

namespace LDW.Application.Models.Forum
{
	public class ForumThreadReplyModel
	{
		public string AuthorId { get; set; }
		public string ReplyBody { get; set; }
		public Guid ParentForumThreadId { get; set; }
		public DateTime CreationDate { get; set; }
		public ForumThreadReplyModel ParentForumThreadReply { get; set; }
	}
}
