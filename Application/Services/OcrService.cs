
using Application.Interfaz;
using Tesseract;
using Microsoft.Extensions.Configuration;

namespace Application.Services
{
    public class OcrService : IOcrService
    {
        private readonly string Base;
        public OcrService(IConfiguration configuration)
        {
             Base = configuration["tessdata:base"];
        }
        

        
        async public Task<string> GetTextString(MemoryStream File)
        {

            var engine = new TesseractEngine(Base, "spa", EngineMode.Default);

            var img = Pix.LoadFromMemory(File.GetBuffer());

            var page = engine.Process(img);

            string recognizedText = page.GetText();
            return  recognizedText ;
        }
    }
}
