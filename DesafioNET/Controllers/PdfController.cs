using Microsoft.AspNetCore.Mvc;
using DesafioNET.Models;
using Application.Interfaz;

namespace DesafioNET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PdfController : Controller
    {
        private readonly IPdfService _pdfService;

        public PdfController(IPdfService pdfService)
        {
            _pdfService = pdfService;
        }

        [HttpPost("upload-pdf")]
        public async Task<IActionResult> UploadPdf(UploadPdfRequest request)
        {

            var Response = new UploadPdfResponse();
            if (request.File == null || request.File.Length == 0 || request.File.ContentType != "application/pdf")
            {
                return BadRequest("No se proporcionó un archivo válido.");
            }

            var memoryStream = new MemoryStream();

            await request.File.CopyToAsync(memoryStream);

            memoryStream.Position = 0;
            Response.Content = await _pdfService.GetTextString(memoryStream);
                return Ok(Response );
            
        }
    }
}
