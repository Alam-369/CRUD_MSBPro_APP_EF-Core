using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MSBProCrudApp.Helper;
using MSBProCrudApp.Models;

namespace MSBProCrudApp.Crontroller;

[ApiController]
[Route("api/[controller]")]
public class AuthController(
    AppDbContext _context,
    ISha256Helper _sha256Helper,
    IJWTTokenHelper _jwt,
    IMapper _mapper) : ControllerBase
{
    [HttpPost("signup")]
    public async Task<ActionResult> Signup([FromBody] UserRequest req)
    {
        try
        {
            var exists = _context.User.Where(p => p.Username == req.Username);
            if (exists.Any())
            {
                return BadRequest(new
                {
                    message = "Username already exists",
                    isSuccess = false

                });
            }
            var user = _mapper.Map<User>(req);
            var hashString = await _sha256Helper.Sha256HexAsync(user.Password);
            user.Password = string.Empty;
            user.PasswordHash = hashString;
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Signup), new { id = user.Id });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return BadRequest(new
            {
                message = "Internal error occurred while signing up",
                isSuccess = false
            });
        }
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] LoginRequest request)
    {
        try
        {
            var user = _context.User.Where(p => p.Username == request.Username).FirstOrDefault();
            var hashString = await _sha256Helper.Sha256HexAsync(request.Password);
            if (hashString == user?.PasswordHash)
            {
                var token = await _jwt.GenerateToken(user.Email, user.Username);
                return StatusCode(200, new { token });

            }
            else
            {
                return NotFound(new
                {
                    message = "User Not Found",
                    isSuccess = false

                });
            }
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                message = "Internal error occurred while signing up",
                isSuccess = false

            });

        }

    }
}