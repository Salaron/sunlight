using System.ComponentModel.DataAnnotations;

namespace SunLight.Dtos.Request.Login;

public class AuthKeyRequest
{
    [Required] 
    public string DummyToken { get; set; }
    
    [Required] 
    public string AuthData { get; set; }
}