using System.Text.Json.Serialization;

namespace MSBProCrudApp.Models;
public class TodoRequest
{
   [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("details")]
    public string Details { get; set; }
}