using LDW.Application.Interfaces;
using LDW.Domain.Common.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;


namespace LDW.Application.Features.ForumFeatures.Commands
{
	public class DeleteForumThreadCommand : IRequest<Guid>
	{
		public Guid Id { get; set; }

		public class DeteteForumThreadCommandHandler : IRequestHandler<DeleteForumThreadCommand, Guid>
		{
			private readonly IApplicationDbContext _context;
			private readonly IHttpContextAccessor _httpContextAccessor;

			public DeteteForumThreadCommandHandler(IApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
			{
				_context = context;
				_httpContextAccessor = httpContextAccessor;
			}

			public async Task<Guid> Handle(DeleteForumThreadCommand request, CancellationToken cancellationToken)
			{
				var forumThreadToDelete = await _context.ForumThreads.FindAsync(request.Id);
				var currentLoggedInUserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

				if (forumThreadToDelete == null)
				{
					throw new NotFoundException("ForumThread", request.Id);
				}

				if (forumThreadToDelete.AuthorId != currentLoggedInUserId)
				{
					throw new AccessForbiddenException("ForumThread", request.Id);
				}

				_context.ForumThreads.Remove(forumThreadToDelete);
				await _context.SaveChangesAsync(cancellationToken);

				return forumThreadToDelete.Id;
			}
		}
	}
}
