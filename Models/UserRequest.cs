using System.Text.Json.Serialization;

namespace MSBProCrudApp.Models;
public class UserRequest
{
    [JsonPropertyName("username")]
    public string Username { get; set; }
    [JsonPropertyName("email")]
    public string Email { get; set; }
    [JsonPropertyName("password")]
    public string Password { get; set; }
    [JsonPropertyName("fname")]
    public string? FirstName { get; set; }
    [JsonPropertyName("lname")]
    public string? LastName { get; set; }
}