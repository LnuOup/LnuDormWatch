using LDW.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LDW.WebAPI.Controllers.v1.Base
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiVersion("1.0")]
    public class BaseV1Controller : BaseApiController
    {

        protected BadRequestObjectResult BadRequest(string message, string details = null, Exception ex = null)
        {
            var request = new BadRequest
            {
                Message = message,
                Details = details,
                Exception = ex
            };

            return base.BadRequest(request);
        }
    }
}
