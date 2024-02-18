using Inforce.TestTask.Abstractions.Services;
using Inforce.TestTask.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Inforce.TestTask.Controllers;

[ApiController]
[Route("api/login")]
public class LoginController : ControllerBase
{
    private readonly IAuthService authService;

    public LoginController(IAuthService authService)
    {
        this.authService = authService;
    }

    [HttpPost]
    public async Task<ActionResult<string>> LoginUser([FromBody] LoginDto request)
    {
        try
        {
            var result = await authService.LoginUser(request);

            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}