using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Server.Common;
using Server.Common.Config;
using Server.Common.Crypto;
using Server.Common.Login;

namespace Server.Endpoints.Handlers.Login;

internal record AuthKeyRequest(string DummyToken, string AuthData);

internal record AuthKeyResponse(string AuthorizeToken, string DummyToken);

[Endpoint("login/authKey", xCodeCheck: XCodeCheck.Disabled, ignoreVersion: true, requireAuthorization: false)]
internal class AuthKeyEndpoint(
    ICryptoService cryptoService,
    IAuthKeyRepository authKeyRepository,
    IOptionsSnapshot<ServerConfig> serverConfig,
    XCodeVerifier xCodeVerifier,
    IActionContext actionContext) : Action<AuthKeyRequest, AuthKeyResponse>
{
    private const int KeySize = 32;

    public override Task<AuthKeyResponse> ExecuteAsync([FromBody] AuthKeyRequest request)
    {
        var clientKey = cryptoService.DecryptRsa(request.DummyToken);
        var serverKey = RandomNumberGenerator.GetBytes(KeySize);
        var sessionKey = Xor(clientKey, serverKey);

        var isCodeCorrect = ValidateXCode(clientKey);

        var authKey = new AuthKey
        {
            AuthorizeToken = Guid.NewGuid().ToString(),
            SessionKey = Convert.ToBase64String(sessionKey),
            ServerKey = Convert.ToBase64String(serverKey),
            Expires = DateTime.UtcNow.AddMinutes(5)
        };

        if (isCodeCorrect)
            authKeyRepository.Add(authKey);

        var response = new AuthKeyResponse(authKey.AuthorizeToken, authKey.ServerKey);
        return Task.FromResult(response);
    }

    private bool ValidateXCode(byte[] clientKey)
    {
        var xorpadBytes = Encoding.Default.GetBytes(serverConfig.Value.Xorpad);
        var appKeyBytes = Encoding.Default.GetBytes(serverConfig.Value.ApplicationKey);
        var serverBase = Xor(xorpadBytes, appKeyBytes);
        var signKey = Xor(serverBase, clientKey);

        var clientCode = actionContext.XMessageCode;
        if (clientCode is null)
            return false;

        var requestData = actionContext.RawRequestBody;

        return xCodeVerifier.Verify(clientCode, requestData, signKey);
    }

    private byte[] Xor(byte[] a, byte[] b)
    {
        var result = new byte[KeySize];
        for (var i = 0; i < KeySize; i++)
        {
            result[i] = (byte)(a[i] ^ b[i]);
        }

        return result;
    }
}
