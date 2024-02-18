using Inforce.TestTask.Abstractions.Services;
using Inforce.TestTask.Dtos;
using Inforce.TestTask.Dtos.auth;
using Microsoft.AspNetCore.Mvc;

namespace Inforce.TestTask.Controllers;

[ApiController]
[Route("api/register")]
public class RegisterController : ControllerBase
{
    private readonly IAuthService authService;

    public RegisterController(IAuthService authService)
    {
        this.authService = authService;
    }

    [HttpPost]
    public async Task<ActionResult<string>> RegisterUser([FromBody] RegisterDto request)
    {
        try
        {
            var result = await authService.RegisterUser(request);

            return result;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}