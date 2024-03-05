namespace Server.Endpoints;

internal interface IAction
{
    Task<object> ExecuteAsync(object requestBody);
}

internal interface IAction<in TRequest, TResponse> : IAction
{
    Task<TResponse> ExecuteAsync(TRequest requestBody);
}

internal abstract class Action<TRequest, TResponse> : IAction<TRequest, TResponse> where TRequest : class
{
    public abstract Task<TResponse> ExecuteAsync(TRequest requestBody);

    async Task<object> IAction.ExecuteAsync(object requestBody)
    {
        return await ExecuteAsync(requestBody as TRequest);
    }
}

