using System.Security.Claims;

namespace Inforce.TestTask.Abstractions.Services;

public interface ITokenService
{
    string CreateToken(IList<Claim> claims);
    void AddRolesToClaims(List<Claim> claims, IList<string> roles);
}