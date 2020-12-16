using LDW.Domain.Entities.Common;
using System;
using System.Collections.Generic;

namespace LDW.Domain.Entities
{
	public class ForumSectionEntity : BaseEntity<Guid>
	{
		public string SectionTitle { get; set; }
		public string SectionDescription { get; set; }
		public DateTime CreationDate { get; set; }
		public string AuthorId { get; set; }

		public UserRefEntity Author { get; set; }
		public ICollection<ForumThreadEntity> ForumThreads { get; set; }
	}
}
