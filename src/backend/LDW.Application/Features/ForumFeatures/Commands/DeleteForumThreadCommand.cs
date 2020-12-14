using LDW.Application.Interfaces;
using LDW.Domain.Common.Exceptions;
using MediatR;
using System;
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

			public DeteteForumThreadCommandHandler(IApplicationDbContext context)
			{
				_context = context;
			}

			public async Task<Guid> Handle(DeleteForumThreadCommand request, CancellationToken cancellationToken)
			{
				var forumThreadToDelete = await _context.ForumThreadEntities.FindAsync(request.Id);

				if (forumThreadToDelete == null)
				{
					throw new NotFoundException("ForumThread", request.Id);
				}

				_context.ForumThreadEntities.Remove(forumThreadToDelete);
				await _context.SaveChangesAsync(cancellationToken);

				return forumThreadToDelete.Id;
			}
		}
	}
}
