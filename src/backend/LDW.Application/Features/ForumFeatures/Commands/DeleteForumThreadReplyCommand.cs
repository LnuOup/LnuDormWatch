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
	public class DeleteForumThreadReplyCommand : IRequest<Guid>
	{
		public Guid Id { get; set; }

		public class DeleteForumThreadReplyCommandHandler : IRequestHandler<DeleteForumThreadReplyCommand, Guid>
		{
			private readonly IApplicationDbContext _context;
			private readonly IHttpContextAccessor _httpContextAccessor;

			public DeleteForumThreadReplyCommandHandler(IApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
			{
				_context = context;
				_httpContextAccessor = httpContextAccessor;
			}

			public async Task<Guid> Handle(DeleteForumThreadReplyCommand request, CancellationToken cancellationToken)
			{
				var forumThreadReplyToDelete = await _context.ForumThreadReplies.FindAsync(request.Id);
				var currentLoggedInUserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

				if (forumThreadReplyToDelete == null)
				{
					throw new NotFoundException("ForumThreadReply", request.Id);
				}

				if (forumThreadReplyToDelete.AuthorId != currentLoggedInUserId)
				{
					throw new AccessForbiddenException("ForumThreadReply", request.Id);
				}

				_context.ForumThreadReplies.Remove(forumThreadReplyToDelete);
				await _context.SaveChangesAsync(cancellationToken);

				return forumThreadReplyToDelete.Id;
			}
		}
	}
}
