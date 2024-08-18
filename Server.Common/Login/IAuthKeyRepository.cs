namespace Server.Common.Login;

public interface IAuthKeyRepository
{
    public void Add(AuthKey authKey);
    public AuthKey? Get(string token);
    
    public void Delete(string token);
}