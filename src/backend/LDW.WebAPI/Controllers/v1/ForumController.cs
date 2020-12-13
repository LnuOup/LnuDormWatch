using LDW.Application.Features.ForumFeatures.Commands;
using LDW.Application.Features.ForumFeatures.Queries;
using LDW.WebAPI.Controllers.v1.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
	}
}
