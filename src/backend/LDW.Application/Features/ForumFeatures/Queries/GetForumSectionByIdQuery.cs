using LDW.Application.Interfaces;
using LDW.Application.Models.Forum;
using LDW.Domain.Common.Exceptions;
using LDW.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LDW.Application.Features.ForumFeatures.Queries
{
	public class GetForumSectionByIdQuery : IRequest<ForumSectionModel>
	{
		public Guid Id { get; set; }

		public GetForumSectionByIdQuery(Guid id)
		{
			Id = id;
		}

		public class GetForumSectionByIdQueryHandler : IRequestHandler<GetForumSectionByIdQuery, ForumSectionModel>
		{
			private readonly IApplicationDbContext _context;

			public GetForumSectionByIdQueryHandler(IApplicationDbContext context)
			{
				_context = context;
			}

			public async Task<ForumSectionModel> Handle(GetForumSectionByIdQuery request, CancellationToken cancellationToken)
			{
				var forumSectionEntity = await _context.ForumSections.FindAsync(request.Id);

				if (forumSectionEntity == null)
				{
					throw new NotFoundException("ForumSection", request.Id);
				}

				var numberOfThreads = _context.ForumThreads
					.Count(ft => ft.ForumSectionId == forumSectionEntity.Id);

				IQueryable<ForumThreadReplyEntity> forumThreadRepliesQuery = _context.ForumThreads
							.Include(ft => ft.ForumThreadReplies)
							.Where(ft => ft.ForumSectionId == forumSectionEntity.Id)
							.SelectMany(ft => ft.ForumThreadReplies);

				DateTime? lastReply;
				if (forumThreadRepliesQuery.Any())
				{
					lastReply = forumThreadRepliesQuery.Max(ftr => ftr.CreationDate);
				}
				else
				{
					lastReply = null;
				}

				var forumSectionModel = new ForumSectionModel
				{
					id = forumSectionEntity.Id,
					SectionTitle = forumSectionEntity.SectionTitle,
					SectionDescription = forumSectionEntity.SectionDescription,
					AuthorId = forumSectionEntity.AuthorId,
					CreationDate = forumSectionEntity.CreationDate,
					NumberOfThreads = numberOfThreads,
					LastReply = lastReply
				};


				return forumSectionModel;
			}
		}
	}
}
