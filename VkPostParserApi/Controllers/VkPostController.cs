using Microsoft.AspNetCore.Mvc;
using VkPostParserApi.Infrastructure.Services;

namespace VkPostParserApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VkPostParserController : BaseController
{
    private readonly ILogger<VkPostParserController> _logger;
    private readonly IVkPostsParserService _service;

    public VkPostParserController(ILogger<VkPostParserController> logger, IVkPostsParserService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet("get-occurrence-letters")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetOccurrenceLetter()
    {
        var result = await _service.GetParsedPostsAsync();

        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }

        return BadRequest(result.Errors);
    }

    [HttpGet("gel-all")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();

        if (result.IsSuccess)
        {
            return Ok(new JsonResult(result.Value));
        }

        return BadRequest(result.Errors);
    }
    
}