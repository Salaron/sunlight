using Server.Database.Server;

namespace Server.Middlewares;

internal class TransactionMiddleware(ServerContext serverContext) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var transaction = await serverContext.Database.BeginTransactionAsync();
        try
        {
            await next(context);
            await serverContext.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}