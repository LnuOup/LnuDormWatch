using LDW.Application.Features.DormitoryFeatures.Commands;
using LDW.Application.Features.DormitoryFeatures.Queries;
using LDW.WebAPI.Controllers.v1.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LDW.WebAPI.Controllers.v1
{
	public class DormitoryController : BaseV1Controller
	{
		#region Dormitory

		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> GetAll()
		{
			var dormitoryList = await Mediator.Send(new GetAllDormitoriesQuery());
			return Ok(dormitoryList);
		}

		[HttpGet("{id}")]
		[AllowAnonymous]
		public async Task<IActionResult> GetById(int id)
		{
			var dormitory = await Mediator.Send(new GetDormitoryByIdQuery(id));

			if (dormitory == null)
			{
				return NotFound();
			}

			return Ok(dormitory);
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateDormitoryCommand command)
		{
			var createdDormitoryId = await Mediator.Send(command);
			return Ok(createdDormitoryId);
		}

		[HttpPut]
		public async Task<IActionResult> Update(UpdateDormitoryCommand command)
		{
			var updatedDormitoryId = await Mediator.Send(command);
			return Ok(updatedDormitoryId);
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(DeleteDormitoryByIdCommand command)
		{
			var deletedDormitoryId = await Mediator.Send(command);
			return Ok(deletedDormitoryId);
		}

		#endregion

		#region Dormitory Picture

		[HttpGet]
		[AllowAnonymous]
		[Route("pictures")]
		public async Task<IActionResult> GetDormitoryPicturesByDormitoryIdAsync([FromQuery] int dormitoryId)
		{
			var dormitoryPictures = await Mediator.Send(new GetDormitoryPicturesByDormitoryIdQuery(dormitoryId));
			return Ok(dormitoryPictures);
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		[Route("pictures")]
		public async Task<IActionResult> UploadDormitoryPictureAsync(UploadDormitoryPictureCommand uploadDormitoryPictureCommand)
		{
			var newDormitoryPicture = await Mediator.Send(uploadDormitoryPictureCommand);
			return Ok(newDormitoryPicture);
		}

		[HttpDelete]
		[Authorize(Roles = "Admin")]
		[Route("pictures/{id}")]
		public async Task<IActionResult> DeleteDormitoryPictureAsync(int id)
		{
			await Mediator.Send(new DeleteDormitoryPictureByIdCommand(id));
			return NoContent();
		}

		#endregion
	}
}
