using System.Text.Json;
using Server.Common.Json;

namespace Server.Endpoints;

internal interface IAction
{
    Task<object> ExecuteAsync(JsonElement requestBody);
}

internal interface IAction<in TRequest, TResponse> : IAction
{
    Task<TResponse> ExecuteAsync(TRequest requestBody);
}

internal abstract class Action<TRequest, TResponse> : IAction<TRequest, TResponse> where TRequest : class
{
    public abstract Task<TResponse> ExecuteAsync(TRequest requestBody);

    async Task<object> IAction.ExecuteAsync(JsonElement rawRequestBody)
    {
        var requestBody = rawRequestBody.Deserialize<TRequest>(JsonSerializerDefaultOptions.GetOptions());
        return await ExecuteAsync(requestBody);
    }
}

