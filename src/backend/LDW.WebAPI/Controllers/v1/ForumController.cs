using LDW.Application.Features.ForumFeatures.Queries;
using LDW.WebAPI.Controllers.v1.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LDW.WebAPI.Controllers.v1
{
	[Route("api/[controller]")]
	[ApiController]
	public class ForumController : BaseV1Controller
	{
		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> GetAllForumSections()
		{
			var sectionList = await Mediator.Send(new GetAllForumSectionsQuery());
			return Ok(sectionList);
		}
	}
}
