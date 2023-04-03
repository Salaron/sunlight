namespace SunLight.Controllers;

[AttributeUsage(AttributeTargets.Method)]
public class BatchApiCallAttribute : Attribute
{
    public string Module { get; }
    public string Action { get; }

    public BatchApiCallAttribute(string module, string action)
    {
        Module = module;
        Action = action;
    }
}