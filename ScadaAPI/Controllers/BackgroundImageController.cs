using ScadaBLL.Interfaces;
using ScadaBLL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ScadaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BackgroundImageController : ControllerBase
    {
        private readonly IBackgroundImageService _service;

        public BackgroundImageController(IBackgroundImageService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetBackGroundImage(int id)
        {
            var image = await _service.GetBackgroundImageAsync(id);

            return File(image.Bytes, "image/jpeg");
        }

        [HttpGet]
        public async Task<ActionResult> GetBackGroundImages()
        {
            var images = await _service.GetBackgroundImagesAsync();

            return Ok(images);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBackGroundImage(int id)
        {
            await _service.DeleteBackGroundImage(id);

            return NoContent();
        }

        [HttpPost("upload-image")]
        public async Task<ActionResult> UploadImageAsync(IFormFile image)
        {
            var memoryStream = new MemoryStream();
            image.CopyTo(memoryStream);
            await _service.UploadImageAsync(memoryStream);

            return NoContent();
        }
    }
}
