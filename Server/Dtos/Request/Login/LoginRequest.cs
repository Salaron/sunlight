using System.ComponentModel.DataAnnotations;

namespace SunLight.Dtos.Request.Login;

public class LoginRequest
{
    [Required]
    public string LoginKey { get; init; }
    
    [Required]
    public string LoginPasswd { get; init; }
}