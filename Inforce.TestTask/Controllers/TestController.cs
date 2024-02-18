using Inforce.TestTask.Data;
using Inforce.TestTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inforce.TestTask.Controllers;

[ApiController]
public class TestController : ControllerBase
{
    private readonly ApplicationDbContext context;

    public TestController(ApplicationDbContext context)
    {
        this.context = context;
    }

    [Route("api/test")]
    public async Task<ActionResult<List<User>>> GetUsers()
    {
        return await context.Users.ToListAsync();
    }

    [HttpGet]
    [Route("api/allShorts")]
    public async Task<ActionResult<List<ShortenerUrl>>> GetAllShorts()
    {
        return await context.ShortenerUrls.ToListAsync();
    }
}