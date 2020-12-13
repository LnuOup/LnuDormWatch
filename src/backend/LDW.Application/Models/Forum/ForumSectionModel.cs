using System;

namespace LDW.Application.Models.Forum
{
	public class ForumSectionModel
	{
		public string SectionTitle { get; set; }
		public string SectionDescription { get; set; }
		public DateTime CreationDate { get; set; }
		public string AuthorId { get; set; }

		public int NumberOfThreads { get; set; }
		public DateTime? LastReply { get; set; }
	}
}
