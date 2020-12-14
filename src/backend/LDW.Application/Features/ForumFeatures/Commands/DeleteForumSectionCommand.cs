using LDW.Application.Interfaces;
using LDW.Domain.Common.Exceptions;
using MediatR;
using System;
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
			public DeleteForumSectionCommandHandler(IApplicationDbContext context)
			{
				_context = context;
			}

			public async Task<Guid> Handle(DeleteForumSectionCommand request, CancellationToken cancellationToken)
			{
				var forumSectionToDelete = await _context.ForumSections.FindAsync(request.Id);

				if (forumSectionToDelete == null)
				{
					throw new NotFoundException("ForumSection", request.Id);
				}

				_context.ForumSections.Remove(forumSectionToDelete);
				await _context.SaveChangesAsync(cancellationToken);

				return forumSectionToDelete.Id;
			}
		}
	}
}
