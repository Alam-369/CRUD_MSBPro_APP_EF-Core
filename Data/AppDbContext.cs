using Microsoft.EntityFrameworkCore;
using MSBProCrudApp.Models;

public class AppDbContext : DbContext
{
    public DbSet<Todos> Todos { get; set; }
    public DbSet<User> User { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
}