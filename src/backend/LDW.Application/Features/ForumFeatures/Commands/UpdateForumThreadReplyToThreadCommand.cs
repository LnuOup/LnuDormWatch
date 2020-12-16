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
	public class UpdateForumThreadReplyToThreadCommand : IRequest<Guid>
	{
		public Guid Id { get; set; }
		public string ReplyBody { get; set; }

		public class UpdateForumThreadReplyToThreadCommandHandler : IRequestHandler<UpdateForumThreadReplyToThreadCommand, Guid>
		{
			private readonly IApplicationDbContext _context;

			public UpdateForumThreadReplyToThreadCommandHandler(IApplicationDbContext context)
			{
				_context = context;
			}

			public async Task<Guid> Handle(UpdateForumThreadReplyToThreadCommand request, CancellationToken cancellationToken)
			{
				var forumThreadReplyToUpdate = await _context.ForumThreadReplies.FindAsync(request.Id);

				if (forumThreadReplyToUpdate == null)
				{
					throw new NotFoundException("ForumThreadReply", request.Id);
				}

				forumThreadReplyToUpdate.ReplyBody = request.ReplyBody;

				await _context.SaveChangesAsync(cancellationToken);

				return forumThreadReplyToUpdate.Id;
			}
		}
	}
}
