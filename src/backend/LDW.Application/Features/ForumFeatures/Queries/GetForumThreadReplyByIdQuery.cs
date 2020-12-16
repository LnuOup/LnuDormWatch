using LDW.Application.Interfaces;
using LDW.Application.Models.Forum;
using LDW.Domain.Common.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LDW.Application.Features.ForumFeatures.Queries
{
	public class GetForumThreadReplyByIdQuery : IRequest<ForumThreadReplyModel>
	{
		public Guid Id { get; set; }

		public GetForumThreadReplyByIdQuery(Guid id)
		{
			Id = id;
		}
		public class GetForumThreadReplyByIdQueryHandler : IRequestHandler<GetForumThreadReplyByIdQuery, ForumThreadReplyModel>
		{
			private readonly IApplicationDbContext _context;
			private readonly IUserDbContext _userDbContext;

			public GetForumThreadReplyByIdQueryHandler(IApplicationDbContext context, IUserDbContext userDbContext)
			{
				_context = context;
				_userDbContext = userDbContext;
			}

			public async Task<ForumThreadReplyModel> Handle(GetForumThreadReplyByIdQuery request, CancellationToken cancellationToken)
			{
				var forumThreadReplyEntity = await _context.ForumThreadReplies
					.Include(ftr => ftr.ParentForumThreadReply)
					.SingleOrDefaultAsync(ftr => ftr.Id == request.Id);

				if (forumThreadReplyEntity == null)
				{
					throw new NotFoundException("ForumThreadReply", request.Id);
				}

				var replyAuthor = await _userDbContext.Users.FindAsync(forumThreadReplyEntity.AuthorId);
				var replyAuthorInfo = new ForumAuthorInfo
				{
					PhotoUrl = replyAuthor.PhotoUrl,
					UserName = replyAuthor.UserName
				};

				var forumThreadReplyModel = new ForumThreadReplyModel
				{
					Id = forumThreadReplyEntity.Id,
					AuthorId = forumThreadReplyEntity.AuthorId,
					CreationDate = forumThreadReplyEntity.CreationDate,
					ParentForumThreadId = forumThreadReplyEntity.ParentForumThreadId,
					ReplyBody = forumThreadReplyEntity.ReplyBody,
					AuthorInfo = replyAuthorInfo
				};

				if (forumThreadReplyEntity.ParentForumThreadReply != null)
				{
					var replyToReplyAuthor = await _userDbContext.Users.FindAsync(forumThreadReplyEntity.ParentForumThreadReply.AuthorId);
					var replyToReplyAuthorInfo = new ForumAuthorInfo
					{
						UserName = replyToReplyAuthor.UserName,
						PhotoUrl = replyToReplyAuthor.PhotoUrl
					};

					forumThreadReplyModel.ParentForumThreadReply = new ForumThreadReplyModel
					{
						Id = forumThreadReplyEntity.ParentForumThreadReply.Id,
						AuthorId = forumThreadReplyEntity.ParentForumThreadReply.AuthorId,
						CreationDate = forumThreadReplyEntity.ParentForumThreadReply.CreationDate,
						ParentForumThreadId = forumThreadReplyEntity.ParentForumThreadReply.ParentForumThreadId,
						ReplyBody = forumThreadReplyEntity.ParentForumThreadReply.ReplyBody,
						AuthorInfo = replyToReplyAuthorInfo
					};
				}

				return forumThreadReplyModel;
			}
		}
	}
}
