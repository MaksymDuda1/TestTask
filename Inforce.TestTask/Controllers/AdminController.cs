using Inforce.TestTask.Abstractions.Services;
using Inforce.TestTask.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inforce.TestTask.Controllers;

[ApiController]
[Authorize(Roles = "Admin")]
[Route("api/admin")]
public class AdminController : ControllerBase
{
    private readonly IUrlShorteningService urlShorteningService;

    public AdminController(IUrlShorteningService urlShorteningService)
    {
        this.urlShorteningService = urlShorteningService;
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteAllUrls()
    {
        try
        {
            await urlShorteningService.DeleteAllUrls();

            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

   
}