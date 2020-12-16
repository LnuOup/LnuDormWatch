using LDW.Application.Interfaces;
using LDW.Application.Models.Forum;
using LDW.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LDW.Application.Features.ForumFeatures.Queries
{
	public class GetAllForumSectionsQuery : IRequest<IEnumerable<ForumSectionModel>>
	{
		public class GetAllForumEntitiesQueryHandler : IRequestHandler<GetAllForumSectionsQuery, IEnumerable<ForumSectionModel>>
		{
			private readonly IApplicationDbContext _context;

			public GetAllForumEntitiesQueryHandler(IApplicationDbContext context)
			{
				_context = context;
			}

			public async Task<IEnumerable<ForumSectionModel>> Handle(GetAllForumSectionsQuery request, CancellationToken cancellationToken)
			{
				var forumSessionEntities = await _context.ForumSections.ToListAsync(cancellationToken);

				IQueryable<ForumThreadReplyEntity> forumThreadRepliesQuery;
				int numberOfThreads;
				DateTime? lastReply;
				ForumSectionModel forumSectionModel;

				return await Task.Run(() =>
				{
					var forumSessionModels = forumSessionEntities.Select(entity =>
					{
						numberOfThreads = _context.ForumThreads
							.Count(ft => ft.ForumSectionId == entity.Id);

						forumThreadRepliesQuery = _context.ForumThreads
							.Include(ft => ft.ForumThreadReplies)
							.Where(ft => ft.ForumSectionId == entity.Id)
							.SelectMany(ft => ft.ForumThreadReplies);

						if (forumThreadRepliesQuery.Any())
						{
							lastReply = forumThreadRepliesQuery.Max(ftr => ftr.CreationDate);
						}
						else
						{
							lastReply = null;
						}

						forumSectionModel = new ForumSectionModel
						{
							id = entity.Id,
							SectionTitle = entity.SectionTitle,
							SectionDescription = entity.SectionDescription,
							AuthorId = entity.AuthorId,
							CreationDate = entity.CreationDate,
							NumberOfThreads = numberOfThreads,
							LastReply = lastReply
						};

						return forumSectionModel;
					});

					return forumSessionModels;
				});
			}
		}
	}
}
