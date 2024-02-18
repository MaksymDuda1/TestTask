using Inforce.TestTask.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace Inforce.TestTask.Controllers;

[Route("api")]
public class RedirectController: ControllerBase
{
    private readonly IUrlShorteningService shorteningService;

    public RedirectController(IUrlShorteningService shorteningService)
    {
        this.shorteningService = shorteningService;
    }
    
    [HttpGet("{code}")]
    public async Task<IActionResult> RedirectUser(string code)
    {
        try
        {
            var shortenedUrl = await shorteningService.GetShortenedUrl(code);

            return Redirect(shortenedUrl.LongUrl);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}