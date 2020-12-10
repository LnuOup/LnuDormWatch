using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace LDW.WebAPI.Filters
{
    public class SwaggerFileOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {

            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            if (operation.OperationId == "Post")
            {
                operation.Parameters = new List<OpenApiParameter>
                { new OpenApiParameter
                {
                    Name = "formFile",
                    In = ParameterLocation.Header,
                    Description = "Upload File",
                    Required = true,
                    Schema= new OpenApiSchema
                    {
                        Type="file",
                        Format="binary"
                    }
                }
                };
            }
        }
    }
}
