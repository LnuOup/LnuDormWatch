using LDW.Application.Interfaces;
using LDW.Application.Models.Forum;
using LDW.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace LDW.Application.Features.ForumFeatures.Commands
{
	public class CreateForumThreadReplyToThreadCommand : IRequest<ForumThreadReplyModel>
	{
		public Guid ThreadId { get; set; }
		public string ReplyBody { get; set; }

		public class CreateForumThreadReplyToThreadCommandHandler : IRequestHandler<CreateForumThreadReplyToThreadCommand, ForumThreadReplyModel>
		{
			private readonly IApplicationDbContext _context;
			private readonly IHttpContextAccessor _httpContextAccessor;

			public CreateForumThreadReplyToThreadCommandHandler(IApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
			{
				_context = context;
				_httpContextAccessor = httpContextAccessor;
			}

			public async Task<ForumThreadReplyModel> Handle(CreateForumThreadReplyToThreadCommand request, CancellationToken cancellationToken)
			{
				var currentLoggedInUserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);


				var newForumThreadReplyEntity = new ForumThreadReplyEntity
				{
					AuthorId = currentLoggedInUserId,
					ReplyBody = request.ReplyBody,
					ParentForumThreadId = request.ThreadId
				};

				await _context.ForumThreadReplies.AddAsync(newForumThreadReplyEntity);
				await _context.SaveChangesAsync(cancellationToken);

				var forumThreadReplyModel = new ForumThreadReplyModel
				{
					AuthorId = newForumThreadReplyEntity.AuthorId,
					ReplyBody = newForumThreadReplyEntity.ReplyBody,
					ParentForumThreadId = newForumThreadReplyEntity.ParentForumThreadId,
					CreationDate = newForumThreadReplyEntity.CreationDate
				};

				return forumThreadReplyModel;
			}
		}
	}
}
