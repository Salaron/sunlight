using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using Server.Common;
using Server.Common.Config;
using Server.Common.Crypto;

namespace Server.Endpoints;

internal class XCodeVerifier
{
    private readonly ICryptoService _cryptoService;
    private readonly IOptions<ServerConfig> _serverConfig;
    private readonly Lazy<byte[]> _specialKey;

    public XCodeVerifier(ICryptoService cryptoService, IOptions<ServerConfig> serverConfig)
    {
        _cryptoService = cryptoService;
        _serverConfig = serverConfig;
        _specialKey = new Lazy<byte[]>(GenerateSpecialKey);
    }

    public bool Verify(string clientCode, string requestData, byte[] key, XCodeCheck xCodeCheck)
    {
        if (!_serverConfig.Value.CheckXMessageCode || xCodeCheck == XCodeCheck.Disabled)
            return true;

        if (xCodeCheck == XCodeCheck.Special)
            return Verify(clientCode, requestData, _specialKey.Value);

        return Verify(clientCode, requestData, key);
    }

    public bool Verify(string clientCode, string requestData, byte[] key)
    {
        if (!_serverConfig.Value.CheckXMessageCode)
            return true;

        var actualXCode = _cryptoService.HmacSha1(Encoding.UTF8.GetBytes(requestData), key);
        var isCodesMatch = clientCode == actualXCode;

        return isCodesMatch;
    }

    private byte[] GenerateSpecialKey()
    {
        var serverConfig = _serverConfig.Value;
        var key = new byte[32];
        for (var i = 0; i < 16; i++)
        {
            key[i] = (byte)(serverConfig.ApplicationKey[i] ^ serverConfig.Xorpad[16 + i]);
        }

        for (var i = 16; i < 32; i++)
        {
            key[i] = (byte)(serverConfig.ApplicationKey[i] ^ serverConfig.Xorpad[i - 16]);
        }

        return key;
    }
}