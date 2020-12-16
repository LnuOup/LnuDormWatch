using LDW.Application.Interfaces;
using LDW.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace LDW.Application.Features.ForumFeatures.Commands
{
	public class CreateForumThreadCommand : IRequest<Guid>
	{
		public Guid SectionId { get; set; }
		public string ThreadTitle { get; set; }
		public string ThreadBody { get; set; }

		public class CreateForumThreadCommandHandler : IRequestHandler<CreateForumThreadCommand, Guid>
		{
			private readonly IApplicationDbContext _context;
			private readonly IHttpContextAccessor _httpContextAccessor;

			public CreateForumThreadCommandHandler(IApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
			{
				_context = context;
				_httpContextAccessor = httpContextAccessor;
			}

			public async Task<Guid> Handle(CreateForumThreadCommand request, CancellationToken cancellationToken)
			{
				var currentLoggedInUserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

				var newForumThreadEntity = new ForumThreadEntity
				{
					ForumSectionId = request.SectionId,
					ThreadTitle = request.ThreadTitle,
					ThreadBody = request.ThreadBody,
					AuthorId = currentLoggedInUserId
				};

				await _context.ForumThreads.AddAsync(newForumThreadEntity, cancellationToken: cancellationToken);
				await _context.SaveChangesAsync(cancellationToken);

				return newForumThreadEntity.Id;
			}
		}
	}
}
