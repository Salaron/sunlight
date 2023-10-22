using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using SunLight.Infrastructure.Authorization;
using SunLight.Modules.Login;

namespace SunLight.Infrastructure.Authentication;

public class HeaderAuthenticationHandler : AuthenticationHandler<HeaderAuthenticationOptions>
{
    private readonly ILoginService _loginService;

    public HeaderAuthenticationHandler(
        IOptionsMonitor<HeaderAuthenticationOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock,
        ILoginService loginService)
        : base(options, logger, encoder, clock)
    {
        _loginService = loginService;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Headers.TryGetValue("Authorize", out var headerValues))
            return AuthenticateResult.NoResult();

        if (headerValues.Count != 1)
            return AuthenticateResult.Fail("Invalid Authorization header");

        var authorizeHeader = AuthorizeHeader.FromString(headerValues.First());
        if (authorizeHeader.Token == Guid.Empty)
            return AuthenticateResult.NoResult();

        var user = await _loginService.FindUserByTokenAsync(authorizeHeader.Token);

        if (user == null)
            return AuthenticateResult.Fail("Invalid token");

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString())
        };

        var identity = new ClaimsIdentity(claims, Scheme.Name);
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, Scheme.Name);

        return AuthenticateResult.Success(ticket);
    }
}