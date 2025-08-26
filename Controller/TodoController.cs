
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MSBProCrudApp.Helper;
using MSBProCrudApp.Models;
using MSBProCrudApp.Repository;

namespace MSBProCrudApp.Crontroller;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class TodoController(ITodoRepository _repo, IMapper _mapper) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Todos>>> GetAllTodos([FromQuery] int uid)
    {
        var todos = await _repo.GetAllAsync(uid);

        if (!todos.Any())
        {
            return StatusCode(400, new { nsg = "No todo for user" });
        }
        else
        {
            var result = todos.Select(t => new
            {
                Details = t.Details,
                Createdon = t.CreatedAt
            });
            return StatusCode(200,
                    new
                    {
                        todos = result
                    });

        }
    }

    [HttpGet]
    public async Task<ActionResult<Todos>> GetTodo([FromRoute] int id)
    {
        var todo = await _repo.GetByIdAsync(id);

        if (todo is null)
        {
            return NotFound();
        }
        else
        {
            return StatusCode(200,
                new
                {
                    Details = todo.Details,
                    Createdon = todo.CreatedAt
                });
        }
    }

    [HttpPost]
    public async Task<ActionResult<Todos>> CreateTodo([FromBody]TodoRequest req)
    {
        try
        {
            var todo = _mapper.Map<Todos>(req);
            await _repo.AddAsync(todo);
            return StatusCode(200, new { msg = "Todo is successfully created" });
        }
        catch (DbUpdateException ex)
        {
            return BadRequest(new
            {
                message = "Internal error occurred while creating todo",
                isSuccess = false

            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Internal Server Error" });
        }
    }

    [HttpPut]
    public async Task<ActionResult> Updatetodo([FromBody] TodoRequest req)
    {
        var result = await _repo.GetByIdAsync(req.Id);

        if (result is null)
        {
            return NotFound();
        }
        try
        {
            _mapper.Map(req, result);
            _repo.Update(result);
            await _repo.SaveChangesAsync();
            return StatusCode(200, new { msg = "Todo is successfully updated" });
        }
        catch (DbUpdateException ex)
        {
            return BadRequest(new
            {
                message = "Internal error occurred while updating todo",
                isSuccess = false

            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Internal Server Error" });
        }
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteTodo([FromRoute] int id)
    {
        var result = await _repo.GetByIdAsync(id);

        if (result is null)
        {
            return NotFound();
        }

        try
        {
             _repo.Delete(result);
            await _repo.SaveChangesAsync();
            return StatusCode(200, new { message = "The todo is deleted successfully" });
        }
        catch (DbUpdateException ex)
        {
            return BadRequest(new
            {
                message = "Internal error occurred while deleting todo",
                isSuccess = false

            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Internal Server Error" });
        }
    }
}