using LDW.Application.Interfaces;
using LDW.Application.Models.Forum;
using LDW.Domain.Common.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LDW.Application.Features.ForumFeatures.Queries
{
	public class GetForumThreadWithBodyByThreadIdQuery : IRequest<ForumThreadWithBodyModel>
	{
		public Guid Id { get; set; }

		public GetForumThreadWithBodyByThreadIdQuery(Guid id)
		{
			Id = id;
		}

		public class GetForumThreadWithBodyByThreadIdQueryHandler : IRequestHandler<GetForumThreadWithBodyByThreadIdQuery, ForumThreadWithBodyModel>
		{
			private readonly IApplicationDbContext _context;

			public GetForumThreadWithBodyByThreadIdQueryHandler(IApplicationDbContext context)
			{
				_context = context;
			}

			public async Task<ForumThreadWithBodyModel> Handle(GetForumThreadWithBodyByThreadIdQuery request, CancellationToken cancellationToken)
			{
				var forumThreadEntity = await _context.ForumThreads.FindAsync(request.Id);

				if (forumThreadEntity == null)
				{
					throw new NotFoundException("ForumThread", request.Id);
				}

				return new ForumThreadWithBodyModel
				{
					ThreadTitle = forumThreadEntity.ThreadTitle,
					ThreadBody = forumThreadEntity.ThreadBody,
					AuthorId = forumThreadEntity.AuthorId,
					CreationDate = forumThreadEntity.CreationDate
				};
			}
		}
	}
}
