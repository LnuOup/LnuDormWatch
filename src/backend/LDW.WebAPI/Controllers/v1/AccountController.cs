using System.Linq;
using System.Threading.Tasks;
using LDW.Application.Features.DormitoryFeatures.Commands;
using LDW.Application.Features.DormitoryFeatures.Queries;
using LDW.Application.Interfaces.Services;
using LDW.Application.Models;
using LDW.Domain.Entities.Options;
using LDW.Domain.Resources;
using LDW.WebAPI.Controllers.v1.Base;
using LDW.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace LDW.WebAPI.Controllers.v1
{ 
    public class AccountController : BaseV1Controller
    {
        private readonly IEmailService _emailService;
        private readonly SmtpOptions _smtpConfig;
        private readonly JwtOptions _jwtOptions;

        public AccountController(IEmailService emailService, IOptions<SmtpOptions> smtpConfig, 
                                 IOptions<JwtOptions> jwtOptions)
        {
            _emailService = emailService;
            _smtpConfig = smtpConfig.Value;
            _jwtOptions = jwtOptions.Value;
        }

        [HttpPost("registration")]
        [AllowAnonymous]
        public async Task<IActionResult> Registration([FromBody] RegisterUserApiModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            if (await Mediator.Send(new GetUserByEmailQuery(model.Email)) != null)
            {
                return BadRequest(message: Translations.EMAIL_ALREADY_EXIST);
            }

            var userModel = new UserModel
            {
                Email = model.Email,
                UserName = model.Email,
                EmailConfirmed = false
            };

            var result = await Mediator.Send(new CreateUserCommand(userModel, model.Password));
            var url = Url.Action(nameof(ConfirmEmail), "Account", new { email = userModel.Email, code = result }, Request.Scheme);

            //Send email verification
            await _emailService.SendVerificationEmail(userModel.UserName, url, _smtpConfig);

            var response = await Mediator.Send(new GetTokensQuery(model.Email, _jwtOptions));

            return Ok(response);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("confirm-email")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string email, string code)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await Mediator.Send(new GetUserByEmailQuery(email));

            if (user == null)
            {
                return BadRequest(message: Translations.INVALID_EMAIL);
            }

            if (user.EmailConfirmed)
            {
                return Ok(Translations.EmailConfirmed);
            }

            var result = await Mediator.Send(new ConfirmEmailCommand { Email = email, Code = code});
            if (!result.Succeeded)
            {
                return BadRequest(message: Translations.E_EmailNotConfirmed);
            }
            return Ok(Translations.VerifyEmailSuccess);
        }


        private string GetConfirmationEmailUrl(string email, string code)
        {
            var action = "confirm-email";
            var controller = "account";
            var protocol = Request.Scheme;

            return Url.Action(action, controller, new { Email = email, Code = code }, protocol);
        }
    }
}
