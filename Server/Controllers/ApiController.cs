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
    private readonly ILogger _logger;

    public ApiController(IServiceProvider serviceProvider, ILogger logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;

        var methods = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(x => x.IsClass)
            .SelectMany(x => x.GetMethods())
            .Where(x => x.GetCustomAttributes(typeof(BatchApiCallAttribute), false).FirstOrDefault() != null);

        foreach (var method in methods)
        {
            var attribute = (BatchApiCallAttribute)Attribute.GetCustomAttribute(method, typeof(BatchApiCallAttribute))!;
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
            var moduleAction = $"{module.Module}/{module.Action}";
            var actionMethodExists = _apiMethods.TryGetValue(moduleAction, out var actionMethod);

            if (!actionMethodExists)
            {
                _logger.LogWarning($"Method for {moduleAction} not exist");
                response.Add(new ApiResponse(new ErrorResponse(1234), 600));
                continue;
            }

            var controllerInstance = ActivatorUtilities.CreateInstance(_serviceProvider, actionMethod.DeclaringType);
            var result = actionMethod.Invoke(controllerInstance, null);

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