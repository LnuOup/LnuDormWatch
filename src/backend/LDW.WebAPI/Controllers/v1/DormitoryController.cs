using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LDW.Application.Features.DormitoryFeatures.Commands;
using LDW.Application.Features.DormitoryFeatures.Queries;
using LDW.WebAPI.Controllers.v1.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LDW.WebAPI.Controllers.v1
{
    public class DormitoryController : BaseV1Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dormitoryList = await Mediator.Send(new GetAllDormitoriesQuery());
            return Ok(dormitoryList);
        }

        [HttpGet("{id}")]
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
