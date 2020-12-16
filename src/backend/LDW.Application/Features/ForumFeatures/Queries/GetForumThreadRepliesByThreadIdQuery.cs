using LDW.Application.Interfaces;
using LDW.Application.Models.Forum;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LDW.Application.Features.ForumFeatures.Queries
{
	public class GetForumThreadRepliesByThreadIdQuery : IRequest<IEnumerable<ForumThreadReplyModel>>
	{
		public Guid ThreadId { get; set; }

		public GetForumThreadRepliesByThreadIdQuery(Guid threadId)
		{
			ThreadId = threadId;
		}
		public class GetForumThreadsByForumSectionQueryHandler : IRequestHandler<GetForumThreadRepliesByThreadIdQuery, IEnumerable<ForumThreadReplyModel>>
		{
			private readonly IApplicationDbContext _context;

			public GetForumThreadsByForumSectionQueryHandler(IApplicationDbContext context)
			{
				_context = context;
			}

			public async Task<IEnumerable<ForumThreadReplyModel>> Handle(GetForumThreadRepliesByThreadIdQuery request, CancellationToken cancellationToken)
			{
				var forumThreadReplyEntities = await _context.ForumThreadReplies
					.Where(ftr => ftr.ParentForumThreadId == request.ThreadId)
					.Include(ftr => ftr.ForumThreadReplies)
					.ToListAsync();

				var forumThreadReplyModels = forumThreadReplyEntities.Select(entity =>
				{
					var forumThreadReplyModel = new ForumThreadReplyModel
					{
						Id = entity.Id,
						AuthorId = entity.AuthorId,
						CreationDate = entity.CreationDate,
						ParentForumThreadId = entity.ParentForumThreadId,
						ReplyBody = entity.ReplyBody
					};

					if (entity.ParentForumThreadReply != null)
					{
						forumThreadReplyModel.ParentForumThreadReply = new ForumThreadReplyModel
						{
							AuthorId = entity.ParentForumThreadReply.AuthorId,
							CreationDate = entity.ParentForumThreadReply.CreationDate,
							ParentForumThreadId = entity.ParentForumThreadReply.ParentForumThreadId,
							ReplyBody = entity.ParentForumThreadReply.ReplyBody
						};
					}

					return forumThreadReplyModel;
				});

				return forumThreadReplyModels;
			}
		}
	}
}
