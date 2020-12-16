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
	public class DeleteForumThreadReplyCommand : IRequest<Guid>
	{
		public Guid Id { get; set; }

		public class DeleteForumThreadReplyCommandHandler : IRequestHandler<DeleteForumThreadReplyCommand, Guid>
		{
			private readonly IApplicationDbContext _context;

			public DeleteForumThreadReplyCommandHandler(IApplicationDbContext context)
			{
				_context = context;
			}

			public async Task<Guid> Handle(DeleteForumThreadReplyCommand request, CancellationToken cancellationToken)
			{
				var forumThreadReplyToDelete = await _context.ForumThreadReplies.FindAsync(request.Id);

				if (forumThreadReplyToDelete == null)
				{
					throw new NotFoundException("ForumThreadReply", request.Id);
				}

				_context.ForumThreadReplies.Remove(forumThreadReplyToDelete);
				await _context.SaveChangesAsync(cancellationToken);

				return forumThreadReplyToDelete.Id;
			}
		}
	}
}
