using LDW.Domain.Common.Exceptions;
using LDW.Domain.Resources;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Text;

namespace LDW.WebAPI.Filters
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
	{
        private readonly ILogger<GlobalExceptionFilter> _logger;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

		public override void OnException(ExceptionContext context)
		{
			var error = new StringBuilder(string.Format(Translations.EXCEPTION_OCCURED_WHILE_PROCESSING_REQUEST,
														context.HttpContext.Request.GetDisplayUrl()));
			error.AppendLine(string.Format(Translations.EXCEPTION_MESSAGE, context.Exception.Message));
			error.AppendLine(string.Format(Translations.STACK_TRACE, context.Exception.StackTrace));
			if (context.Exception.InnerException != null)
			{
				error.AppendLine(
					string.Format(Translations.INNER_EXCEPTION, 
					context.Exception.InnerException.Message));
			}

			_logger.LogError(error.ToString());
            context.ExceptionHandled = true;

			var statusCode = HttpStatusCode.InternalServerError;

			if (context.Exception is ArgumentNullException || context.Exception is ArgumentException)
			{
				statusCode = HttpStatusCode.PreconditionFailed;
			}
			else if (context.Exception is InvalidOperationException)
			{
				statusCode = HttpStatusCode.MethodNotAllowed;
			}
			else if (context.Exception is NotFoundException)
			{
				statusCode = HttpStatusCode.NotFound;
			}
			else if (context.Exception is UnauthorizedAccessException)
			{
				statusCode = HttpStatusCode.Unauthorized;
			}

			context.HttpContext.Response.ContentType = "application/json";
			context.HttpContext.Response.StatusCode = (int)statusCode;
			context.Result = new JsonResult(new
			{
				error = new[] { context.Exception.Message },
				stackTrace = context.Exception.StackTrace
			});
		}
	}
}

