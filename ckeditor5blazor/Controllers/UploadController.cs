using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ckeditor5blazor.Controllers
{
    /// <summary>
    /// Sample upload endpoint for the CKEditor custom adapter in wwwroot/js/CKEditorInterop.js.
    /// The adapter POSTs multipart form field "upload" and expects JSON: { "url": "..." }.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UploadController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public UploadController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpPost]
        [RequestSizeLimit(10_000_000)]
        public async Task<IActionResult> Post(IFormFile upload)
        {
            if (upload == null || upload.Length == 0)
            {
                return BadRequest(new { error = new { message = "No file in form field 'upload'." } });
            }

            var uploadsDir = Path.Combine(_env.WebRootPath ?? "wwwroot", "uploads");
            Directory.CreateDirectory(uploadsDir);

            var safeName = Path.GetFileName(upload.FileName);
            var storedName = $"{Path.GetFileNameWithoutExtension(safeName)}_{Path.GetRandomFileName()}{Path.GetExtension(safeName)}";
            var path = Path.Combine(uploadsDir, storedName);

            await using (var stream = System.IO.File.Create(path))
            {
                await upload.CopyToAsync(stream);
            }

            var url = $"{Request.Scheme}://{Request.Host}/uploads/{storedName}";
            return Ok(new { url });
        }
    }
}
