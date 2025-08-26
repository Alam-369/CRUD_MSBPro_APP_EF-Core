using System.ComponentModel.DataAnnotations;

namespace MSBProCrudApp.Models;
public class Todos
{
    public int UId { get; set; }
    [Key]
    public int Id { get; set; }
    public string Details { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}