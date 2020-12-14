using LDW.Application.Features.ForumFeatures.Commands;
using LDW.Application.Features.ForumFeatures.Queries;
using LDW.WebAPI.Controllers.v1.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LDW.WebAPI.Controllers.v1
{
	[Authorize]
	public class ForumController : BaseV1Controller
	{
		#region Sections

		[HttpGet]
		[AllowAnonymous]
		[Route("sections")]
		public async Task<IActionResult> GetAllForumSectionsAsync()
		{
			var sectionModels = await Mediator.Send(new GetAllForumSectionsQuery());
			return Ok(sectionModels);
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		[Route("sections")]
		public async Task<IActionResult> CreateForumSectionAsync(CreateForumSectionCommand createForumSectionCommand)
		{
			var newSectionId = await Mediator.Send(createForumSectionCommand);
			return Ok(newSectionId);
		}

		[HttpPut]
		[Authorize(Roles = "Admin")]
		[Route("sections")]
		public async Task<IActionResult> UpdateForumSectionAsync(UpdateForumSectionCommand updateForumSectionCommand)
		{
			var updatedSectionId = await Mediator.Send(updateForumSectionCommand);
			return Ok(updatedSectionId);
		}

		[HttpDelete]
		[Authorize(Roles = "Admin")]
		[Route("sections")]
		public async Task<IActionResult> DeleteForumSectionAsync(DeleteForumSectionCommand deleteForumSectionCommand)
		{
			var deletedSectionId = await Mediator.Send(deleteForumSectionCommand);
			return Ok(deletedSectionId);
		}

		#endregion

		#region Threads

		[HttpGet]
		[AllowAnonymous]
		[Route("threads")]
		public async Task<IActionResult> GetForumThreadsByForumSectionId([FromQuery] Guid sectionId)
		{
			var threadModels = await Mediator.Send(new GetForumThreadsByForumSectionQuery(sectionId));
			return Ok(threadModels);
		}

		[HttpGet]
		[AllowAnonymous]
		[Route("threads/{id}")]
		public async Task<IActionResult> GetForumThreadByThreadId(Guid id)
		{
			var threadWithBodyModel = await Mediator.Send(new GetForumThreadWithBodyByThreadIdQuery(id));
			return Ok(threadWithBodyModel);
		}

		[HttpPost]
		[Route("threads")]
		public async Task<IActionResult> CreateForumThreadAsync(CreateForumThreadCommand createForumThreadCommand)
		{
			var createdForumThreadId = await Mediator.Send(createForumThreadCommand);
			return Ok(createdForumThreadId);
		}

		[HttpPut]
		[Route("threads")]
		public async Task<IActionResult> UpdateForumThreadAsync(UpdateForumThreadCommand updateForumThreadCommand)
		{
			var updatedForumThreadId = await Mediator.Send(updateForumThreadCommand);
			return Ok(updatedForumThreadId);
		}

		[HttpDelete]
		[Route("threads")]
		public async Task<IActionResult> DeleteForumThreadAsync(DeleteForumThreadCommand deleteForumThreadCommand)
		{
			var deletedForumThreadId = await Mediator.Send(deleteForumThreadCommand);
			return Ok(deletedForumThreadId);
		}

		#endregion
	}
}
