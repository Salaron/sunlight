namespace SunLight.Controllers;

[AttributeUsage(AttributeTargets.Method)]
public class ApiCallAttribute : Attribute
{
    public string Module { get; }
    public string Action { get; }

    public ApiCallAttribute(string module, string action)
    {
        Module = module;
        Action = action;
    }
}