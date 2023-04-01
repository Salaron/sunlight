using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using SunLight.Authorization;
using SunLight.Dtos.Request;
using SunLight.Dtos.Response;

namespace SunLight.Controllers;

[ApiController]
[Route("main.php/api")]
[Produces("application/json")]
public class ApiController : LlsifController
{
    private readonly Dictionary<string, MethodInfo> _apiMethods = new();
    private readonly IServiceProvider _serviceProvider;

    public ApiController(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;

        var methods = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(x => x.IsClass)
            .SelectMany(x => x.GetMethods())
            .Where(x => x.GetCustomAttributes(typeof(ApiCallAttribute), false).FirstOrDefault() != null);

        foreach (var method in methods)
        {
            var attribute = (ApiCallAttribute)Attribute.GetCustomAttribute(method, typeof(ApiCallAttribute));
            _apiMethods.Add($"{attribute.Module}/{attribute.Action}", method);
        }
    }

    [HttpPost]
    [XMessageCodeCheck]
    public async Task<IActionResult> CallApiAsync([FromBody] IEnumerable<ApiRequest> modules)
    {
        var response = new List<ApiResponse>();
        foreach (var module in modules)
        {
            var actionMethodExists = _apiMethods.TryGetValue($"{module.Module}/{module.Action}", out var actionMethod);

            if (actionMethod == null)
                continue;
            // return Forbid();

            var instance = ActivatorUtilities.CreateInstance(_serviceProvider, actionMethod.DeclaringType);

            var result = actionMethod.Invoke(instance, null);

            if (result is Task task)
                await task;

            if (result is OkObjectResult { Value: BaseResponse resp })
            {
                var apiResponse = new ApiResponse(resp);
                response.Add(apiResponse);
            }
        }

        return SendResponse(response);
    }
}