using Inforce.TestTask.Dtos;
using Inforce.TestTask.Dtos.auth;

namespace Inforce.TestTask.Abstractions.Services;

public interface IAuthService
{
    Task<string> RegisterUser(RegisterDto registerModel);
    Task<string> LoginUser(LoginDto loginModel);
}