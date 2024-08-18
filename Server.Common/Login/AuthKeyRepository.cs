using System.Collections.Concurrent;
using Microsoft.Extensions.Hosting;

namespace Server.Common.Login;

internal class AuthKeyRepository : BackgroundService, IAuthKeyRepository
{
    private readonly ConcurrentDictionary<string, AuthKey> _authKeys = new();

    public void Add(AuthKey authKey)
    {
        _authKeys.AddOrUpdate(authKey.AuthorizeToken, authKey, (_, _) => authKey);
    }

    public AuthKey? Get(string token)
    {
        if (_authKeys.TryGetValue(token, out var authKey))
        {
            var isExpired = authKey.Expires.CompareTo(DateTime.UtcNow) > 0;
            if (isExpired)
                return null;
        }

        return authKey;
    }

    public void Delete(string token)
    {
        _authKeys.TryRemove(token, out _);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var timer = new PeriodicTimer(TimeSpan.FromMinutes(1));
        while (await timer.WaitForNextTickAsync(stoppingToken))
        {
            foreach (var authKey in _authKeys.Values)
            {
                if (authKey.Expires.CompareTo(DateTime.UtcNow) > 0)
                    _authKeys.TryRemove(authKey.AuthorizeToken, out _);
            }
        }
    }
}