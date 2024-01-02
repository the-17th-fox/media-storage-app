using EntityFrameworkCore.Enums;
using Microsoft.AspNetCore.Mvc;
using UseCases.Media;
using UseCases.Media.Models;

namespace Web.Controllers
{
    [Route("api/media")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        public MediaController(IImagesService imagesService)
        {
            _imagesService = imagesService;
        }

        private readonly IImagesService _imagesService;
        
        private CancellationToken _cancellationToken => HttpContext.RequestAborted;

        [HttpPost]
        public async Task<IActionResult> Save(SaveMediaDto saveMediaDto)
        {
            MediaDto response = null!;
            
            switch (saveMediaDto.Type)
            {
                case MediaReferenceTable.Image:
                    response = await _imagesService.SaveAsync(saveMediaDto, _cancellationToken);
                    break;
                
                case MediaReferenceTable.Video:
                    break;
                case MediaReferenceTable.Gif:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _imagesService.GetAllAsync(_cancellationToken));
        }
    }
}
