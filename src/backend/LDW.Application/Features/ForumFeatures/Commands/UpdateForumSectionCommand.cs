using LDW.Application.Interfaces;
using LDW.Domain.Common.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LDW.Application.Features.ForumFeatures.Commands
{
	public class UpdateForumSectionCommand : IRequest<Guid>
	{
		public Guid Id { get; set; }
		public string SectionTitle { get; set; }
		public string SectionDescription { get; set; }

		public class CreateForumSectionCommandHandler : IRequestHandler<UpdateForumSectionCommand, Guid>
		{
			private readonly IApplicationDbContext _context;

			public CreateForumSectionCommandHandler(IApplicationDbContext context)
			{
				_context = context;
			}

			public async Task<Guid> Handle(UpdateForumSectionCommand request, CancellationToken cancellationToken)
			{
				var forumSectionToUpdate = await _context.ForumSectionEntities.FindAsync(request.Id);

				if (forumSectionToUpdate == null)
				{
					throw new NotFoundException("ForumSection", request.Id);
				}

				forumSectionToUpdate.SectionTitle = request.SectionTitle;
				forumSectionToUpdate.SectionDescription = request.SectionDescription;

				await _context.SaveChangesAsync(cancellationToken);

				return forumSectionToUpdate.Id;
			}
		}
	}
}
