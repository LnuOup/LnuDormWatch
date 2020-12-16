using LDW.Application.Interfaces;
using LDW.Domain.Common.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LDW.Application.Features.ForumFeatures.Commands
{
	public class UpdateForumThreadReplyCommand : IRequest<Guid>
	{
		public Guid Id { get; set; }
		public string ReplyBody { get; set; }

		public class UpdateForumThreadReplyToHandler : IRequestHandler<UpdateForumThreadReplyCommand, Guid>
		{
			private readonly IApplicationDbContext _context;
			private readonly IHttpContextAccessor _httpContextAccessor;

			public UpdateForumThreadReplyToHandler(IApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
			{
				_context = context;
				_httpContextAccessor = httpContextAccessor;
			}

			public async Task<Guid> Handle(UpdateForumThreadReplyCommand request, CancellationToken cancellationToken)
			{
				var forumThreadReplyToUpdate = await _context.ForumThreadReplies.FindAsync(request.Id);
				var currentLoggedInUserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);


				if (forumThreadReplyToUpdate == null)
				{
					throw new NotFoundException("ForumThreadReply", request.Id);
				}

				if (forumThreadReplyToUpdate.AuthorId != currentLoggedInUserId)
				{
					throw new AccessForbiddenException("ForumThreadReply", request.Id);
				}

				forumThreadReplyToUpdate.ReplyBody = request.ReplyBody;

				await _context.SaveChangesAsync(cancellationToken);

				return forumThreadReplyToUpdate.Id;
			}
		}
	}
}
