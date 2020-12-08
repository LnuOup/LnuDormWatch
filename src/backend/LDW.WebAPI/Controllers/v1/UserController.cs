using LDW.Application.Features.UserFeatures.Queries;
using LDW.WebAPI.Controllers.v1.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LDW.WebAPI.Controllers.v1
{
    [Authorize]
    public class UserController : BaseV1Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await Mediator.Send(new GetUserByIdQuery(User.Identity.Name));

            var response = new
            {
                user.UserName,
                user.Email,
                user.EmailConfirmed,
                user.PhoneNumber,
                user.PhotoUrl
            };

            return Ok(response);
        }

    }
}
