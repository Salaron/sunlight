namespace Server.Common.Login;

public interface ICredentialsHelper
{
    (string login, string password) DecryptCredentials(string authorizeToken, string encryptedLogin, string encryptedPassword);
    string AddSalt(string password);
}