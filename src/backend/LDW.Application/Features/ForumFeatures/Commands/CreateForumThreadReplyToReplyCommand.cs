﻿using LDW.Application.Interfaces;
using LDW.Application.Models.Forum;
using LDW.Domain.Common.Exceptions;
using LDW.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LDW.Application.Features.ForumFeatures.Commands
{
	public class CreateForumThreadReplyToReplyCommand : IRequest<ForumThreadReplyModel>
	{
		public Guid ParentThreadReplyId { get; set; }
		public string ReplyBody { get; set; }

		public class CreateForumThreadReplyToReplyCommandHandler : IRequestHandler<CreateForumThreadReplyToReplyCommand, ForumThreadReplyModel>
		{
			private readonly IApplicationDbContext _context;
			private readonly IHttpContextAccessor _httpContextAccessor;

			public CreateForumThreadReplyToReplyCommandHandler(IApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
			{
				_context = context;
				_httpContextAccessor = httpContextAccessor;
			}

			public async Task<ForumThreadReplyModel> Handle(CreateForumThreadReplyToReplyCommand request, CancellationToken cancellationToken)
			{
				var currentLoggedInUserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

				var parentForumThreadReply = await _context.ForumThreadReplies.FindAsync(request.ParentThreadReplyId);

				if (parentForumThreadReply == null)
				{
					throw new NotFoundException("ForumThreadReply", request.ParentThreadReplyId);
				}

				var parentForumThreadId = parentForumThreadReply.ParentForumThreadId;

				var newForumThreadReplyEntity = new ForumThreadReplyEntity
				{
					ParentForumThreadReplyId = request.ParentThreadReplyId,
					AuthorId = currentLoggedInUserId,
					ReplyBody = request.ReplyBody,
					ParentForumThreadId = parentForumThreadId
				};

				await _context.ForumThreadReplies.AddAsync(newForumThreadReplyEntity);
				await _context.SaveChangesAsync(cancellationToken);

				var forumThreadReplyModel = new ForumThreadReplyModel
				{
					AuthorId = newForumThreadReplyEntity.AuthorId,
					ReplyBody = newForumThreadReplyEntity.ReplyBody,
					ParentForumThreadId = newForumThreadReplyEntity.ParentForumThreadId,
					CreationDate = newForumThreadReplyEntity.CreationDate,
					ParentForumThreadReply = new ForumThreadReplyModel
					{
						AuthorId = parentForumThreadReply.AuthorId,
						ReplyBody = parentForumThreadReply.ReplyBody,
						ParentForumThreadId = parentForumThreadReply.ParentForumThreadId,
						CreationDate = parentForumThreadReply.CreationDate
					}
				};

				return forumThreadReplyModel;
			}
		}
	}
}
