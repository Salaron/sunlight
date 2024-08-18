namespace Server.Common.Login;

public interface ICredentialsHelper
{
    (string login, string password) DecryptCredentials(AuthKey authKey, string encryptedLogin, string encryptedPassword);
    string AddSalt(string password);
}