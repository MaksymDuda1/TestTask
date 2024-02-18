using Inforce.TestTask.Abstractions.Services;
using Inforce.TestTask.Data;
using Inforce.TestTask.Dtos;
using Inforce.TestTask.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Inforce.TestTask.Controllers;

[ApiController]
[Route("api/urls")]
public class ShortUrlController : ControllerBase
{
    private readonly IUrlShorteningService shorteningService;

    public ShortUrlController(IUrlShorteningService shorteningService)
    {
        this.shorteningService = shorteningService;
    }

    [HttpGet("{id:guid}")]
    [Authorize]
    public async Task<ActionResult<ShortenerUrl>> GetById(Guid id)
    {
        try
        {
            var urls = await shorteningService.GetUrlById(id);

            return Ok(urls);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<ShortenerUrl>>> GetAllUrls()
    {
        try
        {
            var urls = await shorteningService.GetAllUrls();

            return Ok(urls);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<string>> GenerateShortUrl([FromBody] UrlDto request)
    {
        try
        {
            var result = await shorteningService.CreateShortenerUrl(request);

            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id:guid}")]
    [Authorize]
    public async Task<ActionResult> DeleteUrlById(Guid id)
    {
        try
        {
            await shorteningService.DeleteUrlById(id);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("creator/{id}")]
    public async Task<ActionResult<string>> GetCreatorId(Guid id)
    {
        try
        {
            return await shorteningService.GetCreatorId(id);
        }

        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}