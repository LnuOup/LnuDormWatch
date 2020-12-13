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
    }
}
