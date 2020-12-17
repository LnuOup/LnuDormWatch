using LDW.Application.Interfaces;
using LDW.Application.Models.Forum;
using LDW.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
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
			private readonly IApplicationDbContext _applicationDbcontext;
			private readonly IUserDbContext _userDbContext;

			public GetForumThreadsByForumSectionQueryHandler(IApplicationDbContext context, IUserDbContext userDbContext)
			{
				_applicationDbcontext = context;
				_userDbContext = userDbContext;
			}

			public async Task<IEnumerable<ForumThreadReplyModel>> Handle(GetForumThreadRepliesByThreadIdQuery request, CancellationToken cancellationToken)
			{
				var forumThreadReplyEntities = await _applicationDbcontext.ForumThreadReplies
					.Where(ftr => ftr.ParentForumThreadId == request.ThreadId)
					.Include(ftr => ftr.ForumThreadReplies)
					.ToListAsync();

				var replyAuthorIds = forumThreadReplyEntities.Select(ftr => ftr.AuthorId);

				var replyToReplyAuthorIds = forumThreadReplyEntities
					.SelectMany(ftr => ftr.ForumThreadReplies)
					.Select(ftr => ftr.AuthorId);

				var allAuthorIds = replyAuthorIds.Union(replyToReplyAuthorIds);

				var authors = await _userDbContext.Users
					.Where(u => allAuthorIds.Contains(u.Id))
					.ToListAsync();

				var forumThreadReplyModels = forumThreadReplyEntities.Select(entity =>
				{
					var replyAutor = authors.FirstOrDefault(a => a.Id == entity.AuthorId);
					var forumThreadReplyModel = new ForumThreadReplyModel
					{
						Id = entity.Id,
						AuthorId = entity.AuthorId,
						CreationDate = entity.CreationDate,
						ParentForumThreadId = entity.ParentForumThreadId,
						ReplyBody = entity.ReplyBody,
						AuthorInfo = new ForumAuthorInfo
						{
							UserName = replyAutor.UserName,
							PhotoUrl = replyAutor.PhotoUrl
						}
					};

					if (entity.ParentForumThreadReply != null)
					{
						var replyToReplyAuthor = authors.FirstOrDefault(a => a.Id == entity.ParentForumThreadReply.AuthorId);
						forumThreadReplyModel.ParentForumThreadReply = new ForumThreadReplyModel
						{
							Id = entity.ParentForumThreadReply.Id,
							AuthorId = entity.ParentForumThreadReply.AuthorId,
							CreationDate = entity.ParentForumThreadReply.CreationDate,
							ParentForumThreadId = entity.ParentForumThreadReply.ParentForumThreadId,
							ReplyBody = entity.ParentForumThreadReply.ReplyBody,
							AuthorInfo = new ForumAuthorInfo
							{
								UserName = replyToReplyAuthor.UserName,
								PhotoUrl = replyToReplyAuthor.PhotoUrl
							}
						};
					}

					return forumThreadReplyModel;
				});

				return forumThreadReplyModels;
			}
		}
	}
}
