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
	public class DeleteForumSectionCommand : IRequest<Guid>
	{
		public Guid Id { get; set; }

		public class DeleteForumSectionCommandHandler : IRequestHandler<DeleteForumSectionCommand, Guid>
		{
			private readonly IApplicationDbContext _context;
			private readonly IHttpContextAccessor _httpContextAccessor;

			public DeleteForumSectionCommandHandler(IApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
			{
				_context = context;
				_httpContextAccessor = httpContextAccessor;
			}

			public async Task<Guid> Handle(DeleteForumSectionCommand request, CancellationToken cancellationToken)
			{
				var forumSectionToDelete = await _context.ForumSections.FindAsync(request.Id);
				var currentLoggedInUserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

				if (forumSectionToDelete == null)
				{
					throw new NotFoundException("ForumSection", request.Id);
				}

				if (forumSectionToDelete.AuthorId != currentLoggedInUserId)
				{
					throw new AccessForbiddenException("ForumSection", request.Id);
				}

				_context.ForumSections.Remove(forumSectionToDelete);
				await _context.SaveChangesAsync(cancellationToken);

				return forumSectionToDelete.Id;
			}
		}
	}
}
