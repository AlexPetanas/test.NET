
using Application.Interfaz;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf;
using iText.Forms.Form.Element;
using Microsoft.AspNetCore.Http;

namespace Application.Services
{
    public class PdfService : IPdfService
    {

        async public Task<string> GetTextString(MemoryStream File)
        {
            var Response = new string("");
            try
            {


                PdfReader pdfReader = new PdfReader(File);

                PdfDocument pdfDocument = new PdfDocument(pdfReader);



                for (int i = 1; i <= pdfDocument.GetNumberOfPages(); i++)
                {

                    ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                    string pageContent = PdfTextExtractor.GetTextFromPage(pdfDocument.GetPage(i), strategy);
                    Response += $"--- Página {i} ---\n{pageContent}\n";



                }
                pdfDocument.Close();
                pdfReader.Close();

                return Response;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo procesar el archivo");
            }
        }  
    }
}
