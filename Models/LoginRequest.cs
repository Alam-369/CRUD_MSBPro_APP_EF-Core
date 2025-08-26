using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MSBProCrudApp.Models;

public class LoginRequest
{
    [JsonPropertyName("username")]
    public string Username { get; set; }
    [JsonPropertyName("password")]
    public string Password { get; set; }
}