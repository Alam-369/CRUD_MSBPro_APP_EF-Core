using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MSBProCrudApp.Infrasturcture;

namespace MSBProCrudApp.Helper;

public interface IJWTTokenHelper
{
    Task<string> GenerateToken(string email, string username);
}

public class JWTTokenHelper : IJWTTokenHelper
{
    public Configuration _config;
    public JWTTokenHelper(IOptions<Configuration> options)
    {
        _config = options.Value;
    }
    public async Task<string> GenerateToken(string email, string username)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, email),
            new(JwtRegisteredClaimNames.UniqueName, username),
            new(ClaimTypes.NameIdentifier, email)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.JWTOptions.Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _config.JWTOptions.Issuer,
            audience: _config.JWTOptions.Audience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddMinutes(_config.JWTOptions.ExpiresMinutes),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
