using Application.Interfaz;
using DesafioNET.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioNET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OcrController : Controller
    {
        private readonly IOcrService _ocrService;

        public OcrController(IOcrService ocrService)
        {
            _ocrService = ocrService;
        
        }




        [HttpPost("Ocr-post")]
        public async Task<IActionResult> OcrText(OcrPostRequest request)
        {
            var response = new  OcrPostResponse();
            if (request.File == null || request.File.Length == 0 )
            {
                return BadRequest("No se proporcionó un archivo válido.");
            }

            var memoryStream = new MemoryStream();

            await request.File.CopyToAsync(memoryStream);

            memoryStream.Position = 0;

            response.Text = await _ocrService.GetTextString(memoryStream);
            return Ok(response);
        }
    }
}
