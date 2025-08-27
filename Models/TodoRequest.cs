using System.Text.Json.Serialization;

namespace MSBProCrudApp.Models;
public class TodoRequest
{
    [JsonPropertyName("uid")]
    public int UId { get; set; }
   [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("details")]
    public string Details { get; set; }
}