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
	public class UpdateForumSectionCommand : IRequest<Guid>
	{
		public Guid Id { get; set; }
		public string SectionTitle { get; set; }
		public string SectionDescription { get; set; }

		public class UpdateForumSectionCommandHandler : IRequestHandler<UpdateForumSectionCommand, Guid>
		{
			private readonly IApplicationDbContext _context;
			private readonly IHttpContextAccessor _httpContextAccessor;


			public UpdateForumSectionCommandHandler(IApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
			{
				_context = context;
				_httpContextAccessor = httpContextAccessor;
			}

			public async Task<Guid> Handle(UpdateForumSectionCommand request, CancellationToken cancellationToken)
			{
				var forumSectionToUpdate = await _context.ForumSections.FindAsync(request.Id);
				var currentLoggedInUserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);


				if (forumSectionToUpdate == null)
				{
					throw new NotFoundException("ForumSection", request.Id);
				}

				if (forumSectionToUpdate.AuthorId != currentLoggedInUserId)
				{
					throw new AccessForbiddenException("ForumSection", request.Id);
				}

				forumSectionToUpdate.SectionTitle = request.SectionTitle;
				forumSectionToUpdate.SectionDescription = request.SectionDescription;

				await _context.SaveChangesAsync(cancellationToken);

				return forumSectionToUpdate.Id;
			}
		}
	}
}
