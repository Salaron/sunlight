using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Server.Common;
using Server.Common.Crypto;

namespace Server.Endpoints.Main.Login;

internal record AuthKeyRequest(string DummyToken, string AuthData);

internal record AuthKeyResponse(string AuthorizeToken, string DummyToken);

[Endpoint("login/authKey", xCodeCheck: XCodeCheck.Disabled, ignoreVersion: true)]
internal class AuthKey(ICryptoService cryptoService) : Action<AuthKeyRequest, AuthKeyResponse>
{
    private const int KeySize = 32;

    public override Task<AuthKeyResponse> ExecuteAsync([FromBody] AuthKeyRequest request)
    {
        var clientKey = cryptoService.DecryptRsa(request.DummyToken);
        var serverKey = RandomNumberGenerator.GetBytes(KeySize);

        var sessionKey = new byte[KeySize];
        for (var i = 0; i < KeySize; i++)
        {
            sessionKey[i] = (byte)(clientKey[i] ^ serverKey[i]);
        }

        var response = new AuthKeyResponse(Guid.NewGuid().ToString(), Convert.ToBase64String(serverKey));
        return Task.FromResult(response);
    }
}