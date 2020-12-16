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
	public class UpdateForumThreadCommand : IRequest<Guid>
	{
		public Guid Id { get; set; }
		public string ThreadTitle { get; set; }
		public string ThreadBody { get; set; }

		public class UpdateForumThreadCommandHandler : IRequestHandler<UpdateForumThreadCommand, Guid>
		{
			private readonly IApplicationDbContext _context;
			private readonly IHttpContextAccessor _httpContextAccessor;

			public UpdateForumThreadCommandHandler(IApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
			{
				_context = context;
				_httpContextAccessor = httpContextAccessor;
			}

			public async Task<Guid> Handle(UpdateForumThreadCommand request, CancellationToken cancellationToken)
			{
				var forumThreadToUpdate = await _context.ForumThreads.FindAsync(request.Id);
				var currentLoggedInUserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);


				if (forumThreadToUpdate == null)
				{
					throw new NotFoundException("ForumSection", request.Id);
				}

				if (forumThreadToUpdate.AuthorId != currentLoggedInUserId)
				{
					throw new AccessForbiddenException("ForumSection", request.Id);
				}

				forumThreadToUpdate.ThreadTitle = request.ThreadTitle;
				forumThreadToUpdate.ThreadBody = request.ThreadBody;

				await _context.SaveChangesAsync(cancellationToken);

				return forumThreadToUpdate.Id;
			}
		}
	}
}
