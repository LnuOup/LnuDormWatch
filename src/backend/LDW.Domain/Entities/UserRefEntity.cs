using LDW.Domain.Entities.Common;
using System.Collections.Generic;

namespace LDW.Domain.Entities
{
	public class UserRefEntity : BaseEntity<string>
	{
		public ICollection<ForumSectionEntity> ForumSections { get; set; }
		public ICollection<ForumThreadEntity> ForumThreads { get; set; }
		public ICollection<ForumThreadReplyEntity> ForumThreadReplies { get; set; }
	}
}
