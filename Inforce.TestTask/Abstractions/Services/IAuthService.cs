using Inforce.TestTask.Dtos.Auth;

namespace Inforce.TestTask.Abstractions.Services;

public interface IAuthService
{
    Task<string> RegisterUser(RegisterDto registerModel);
    Task<string> LoginUser(LoginDto loginModel);
}