using LDW.Application.Interfaces;
using LDW.Application.Models.Forum;
using LDW.Domain.Common.Exceptions;
using LDW.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using LDW.Application.Models;

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
			private readonly UserManager<UserEntity> _userManager;

			public GetForumThreadWithBodyByThreadIdQueryHandler(IApplicationDbContext context, UserManager<UserEntity> userManager)
			{
				_context = context;
				_userManager = userManager;
			}

			public async Task<ForumThreadWithBodyModel> Handle(GetForumThreadWithBodyByThreadIdQuery request, CancellationToken cancellationToken)
			{
				var forumThreadEntity = await _context.ForumThreads.FindAsync(request.Id);

				if (forumThreadEntity == null)
				{
					throw new NotFoundException("ForumThread", request.Id);
				}

				var user = await _userManager.FindByIdAsync(forumThreadEntity.AuthorId);

				return new ForumThreadWithBodyModel
				{
					Id = forumThreadEntity.Id,
					ThreadTitle = forumThreadEntity.ThreadTitle,
					ThreadBody = forumThreadEntity.ThreadBody,
					AuthorId = forumThreadEntity.AuthorId,
					CreationDate = forumThreadEntity.CreationDate,
					AuthorInfo = new ForumAuthorInfo
					{
						UserName = user.UserName,
						PhotoUrl = user.PhotoUrl
					}
				};
			}
		}
	}
}
