using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Inforce.TestTask.Abstractions.Services;
using Microsoft.IdentityModel.Tokens;

namespace Inforce.TestTask.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration configuration;

    public TokenService(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public string CreateToken(IList<Claim> claims)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtSecret = configuration["jwtSecret"]!;
        var key = Encoding.ASCII.GetBytes(jwtSecret);
        var identity = new ClaimsIdentity(claims);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = identity,
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
    
    public void AddRolesToClaims(List<Claim> claims, IList<string> roles)
    {
        foreach (var role in roles)
        {
            var roleClaim = new Claim(ClaimTypes.Role, role);
            claims.Add(roleClaim);
        }
    }
}