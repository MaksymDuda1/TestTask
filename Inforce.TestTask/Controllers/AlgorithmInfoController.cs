using Inforce.TestTask.Abstractions.Services;
using Inforce.TestTask.Dtos;
using Inforce.TestTask.Models;
using Inforce.TestTask.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Inforce.TestTask.Controllers;

[ApiController]
[Route("api/algorithInfo")]
public class AlgorithmInfoController : ControllerBase
{
    private readonly IAlgorithmInfoService algorithmInfoService;

    public AlgorithmInfoController(IAlgorithmInfoService algorithmInfoService)
    {
        this.algorithmInfoService = algorithmInfoService;
    }

    [HttpGet]
    public async Task<ActionResult<AlgorithmInfoModel>> GetAlgorithmInfo()
    {
        try
        {
            return Ok(await algorithmInfoService.GetAlgorithmInfo());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPut]
    public async Task<ActionResult<AlgorithmInfoModel>> UpdateAlgorithmInfo(AlgorithmInfoDto request)
    {
        try
        {
            return Ok(await algorithmInfoService.UpdateAlgorithmInfo(request));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}