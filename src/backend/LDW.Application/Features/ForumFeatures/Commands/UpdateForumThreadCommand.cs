using LDW.Application.Interfaces;
using LDW.Domain.Common.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
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
			public UpdateForumThreadCommandHandler(IApplicationDbContext context)
			{
				_context = context;
			}

			public async Task<Guid> Handle(UpdateForumThreadCommand request, CancellationToken cancellationToken)
			{
				var forumThreadToUpdate = await _context.ForumThreadEntities.FindAsync(request.Id);

				if (forumThreadToUpdate == null)
				{
					throw new NotFoundException("ForumSection", request.Id);
				}

				forumThreadToUpdate.ThreadTitle = request.ThreadTitle;
				forumThreadToUpdate.ThreadBody = request.ThreadBody;

				await _context.SaveChangesAsync(cancellationToken);

				return forumThreadToUpdate.Id;
			}
		}
	}
}
