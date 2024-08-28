using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Server.Common.Config;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Server.Swagger;

internal class AuthorizationHeaderOperationFilter(IOptions<ServerConfig> config) : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        operation.Security ??= new List<OpenApiSecurityRequirement>();

        var authorize = new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Authorize" } };
        operation.Security.Add(new OpenApiSecurityRequirement
        {
            [authorize] = new List<string>(),
        });
        
        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "bundle-version",
            In = ParameterLocation.Header,
            Description = "Client application version",
            Required = true,
            Schema = new OpenApiSchema
            {
                Type = "string",
                Default = new OpenApiString(config.Value.ClientAppVersion)
            }
        });
    }
}