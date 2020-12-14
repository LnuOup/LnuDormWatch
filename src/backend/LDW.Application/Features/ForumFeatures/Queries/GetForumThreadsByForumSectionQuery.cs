using LDW.Application.Interfaces;
using LDW.Application.Models.Forum;
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
	public class GetForumThreadsByForumSectionQuery : IRequest<IEnumerable<ForumThreadModel>>
	{
		public Guid SectionId { get; set; }

		public GetForumThreadsByForumSectionQuery(Guid sectionId)
		{
			SectionId = sectionId;
		}

        public class GetForumThreadsByForumSectionQueryHandler : IRequestHandler<GetForumThreadsByForumSectionQuery, IEnumerable<ForumThreadModel>>
        {
            private readonly IApplicationDbContext _context;

            public GetForumThreadsByForumSectionQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

			public async Task<IEnumerable<ForumThreadModel>> Handle(GetForumThreadsByForumSectionQuery request, CancellationToken cancellationToken)
			{
                var forumThreadEntities = await _context.ForumThreads
                    .Where(ft => ft.ForumSectionId == request.SectionId)
                    .ToListAsync();

				IQueryable<ForumThreadReplyEntity> forumThreadReplyEntitiesQuery;
				ForumThreadModel forumThreadModel;
				int numberOfReplies;
				DateTime? lastReplyDateTime;

				return await Task.Run(() =>
				{
					var forumThreadModels = forumThreadEntities.Select(entity =>
					{
						numberOfReplies = _context.ForumThreads
							.Where(ft => ft.ForumSectionId == request.SectionId)
							.Include(ft => ft.ForumThreadReplies)
							.Select(ft => ft.ForumThreadReplies)
							.Count();

						forumThreadReplyEntitiesQuery = _context.ForumThreadReplies
							.Where(ftr => ftr.ParentForumThreadId == entity.Id);

						if (forumThreadReplyEntitiesQuery.Any())
						{
							lastReplyDateTime = forumThreadReplyEntitiesQuery.Max(ftr => ftr.CreationDate);
						}
						else
						{
							lastReplyDateTime = null;
						}

						forumThreadModel = new ForumThreadModel
						{
							ThreadTitle = entity.ThreadTitle,
							AuthorId = entity.AuthorId,
							CreationDate = entity.CreationDate,
							ForumSectionId = entity.ForumSectionId,
							NumberOfReplies = numberOfReplies,
							LastReply = lastReplyDateTime
						};

						return forumThreadModel;
					});

					return forumThreadModels;
				});
			}
		}
    }
}
