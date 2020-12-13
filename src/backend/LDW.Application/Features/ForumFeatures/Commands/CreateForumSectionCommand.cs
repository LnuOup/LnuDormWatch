using LDW.Application.Interfaces;
using LDW.Domain.Entities;
using MediatR;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace LDW.Application.Features.ForumFeatures.Commands
{
	public class CreateForumSectionCommand : IRequest<Guid>
	{
		public string SectionTitle { get; set; }
		public string SectionDescription { get; set; }

		public class CreateForumSectionCommandHandler : IRequestHandler<CreateForumSectionCommand, Guid>
		{
			private readonly IApplicationDbContext _context;
			private readonly IHttpContextAccessor _httpContextAccessor;


			public CreateForumSectionCommandHandler(IApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
			{
				_context = context;
				_httpContextAccessor = httpContextAccessor;
			}

			public async Task<Guid> Handle(CreateForumSectionCommand request, CancellationToken cancellationToken)
			{
				var currentLoggedInUserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

				var newForumSectionEntity = new ForumSectionEntity
				{
					SectionTitle = request.SectionTitle,
					SectionDescription = request.SectionDescription,
					AuthorId = currentLoggedInUserId
				};

				await _context.ForumSectionEntities.AddAsync(newForumSectionEntity, cancellationToken: cancellationToken);
				await _context.SaveChangesAsync(cancellationToken);

				return newForumSectionEntity.Id;
			}
		}
	}
}
