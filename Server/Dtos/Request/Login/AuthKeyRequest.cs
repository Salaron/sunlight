using System.ComponentModel.DataAnnotations;

namespace SunLight.Dtos.Request.Login;

[Serializable]
public class AuthKeyRequest
{
    [Required]
    public string DummyToken { get; set; }

    [Required]
    public string AuthData { get; set; }
}