using Microsoft.EntityFrameworkCore;
using MSBProCrudApp.Models;
namespace MSBProCrudApp.Repository;

public interface ITodoRepository : IRepository<Todos>
{
    Task<IEnumerable<Todos>> GetAllAsync(int uid);
    Task SaveChangesAsync();
}
public class TodoRepository : Repository<Todos>, ITodoRepository
{
    private readonly AppDbContext _context;
    public TodoRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Todos>> GetAllAsync(int uid)
    {
        return await _context.Todos.Where(p => p.UId == uid).ToListAsync();
    }
   
   public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}