using Microsoft.AspNetCore.Mvc;
using UseCases.Tags;

namespace Web.Controllers;

[Route("api/tags")]
[ApiController]
public class TagsController : ControllerBase
{
    public TagsController(ITagsService tagsService)
    {
        _tagsService = tagsService ?? throw new ArgumentNullException(nameof(tagsService));
    }

    private readonly ITagsService _tagsService;

    private CancellationToken _cancellationToken => HttpContext.RequestAborted;

    [HttpPost]
    public async Task<IActionResult> Save(SaveTagDto saveTagDto)
    {
        return Ok(await _tagsService.SaveAsync(saveTagDto, _cancellationToken));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _tagsService.GetAllAsync(_cancellationToken));
    }
}