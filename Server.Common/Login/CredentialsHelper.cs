using System.Text;
using Server.Common.Crypto;

namespace Server.Common.Login;

internal class CredentialsHelper(ICryptoService cryptoService) : ICredentialsHelper
{
    public (string login, string password) DecryptCredentials(AuthKey authKey, string encryptedLogin, string encryptedPassword)
    {
        if (authKey == null)
            throw new AuthKeyNotFoundException();

        var loginBytes = Convert.FromBase64String(encryptedLogin);
        var passwordBytes = Convert.FromBase64String(encryptedPassword);
        var sessionKeyBytes = Convert.FromBase64String(authKey.SessionKey);

        var key = new byte[16];
        Array.Copy(sessionKeyBytes, 0, key, 0, 16);

        var decryptedLogin = Encoding.UTF8.GetString(cryptoService.DecryptAes(key, loginBytes));
        var decryptedPassword = Encoding.UTF8.GetString(cryptoService.DecryptAes(key, passwordBytes));

        return (decryptedLogin, decryptedPassword);
    }

    public string AddSalt(string password)
    {
        throw new NotImplementedException();
    }
}
