

using Application.Services;

namespace TestProject
{
    public class PdfServiceTest
    {
        private const string Base = @"C:/Users/Alex/Source/Repos/DesafioNET/TestProject/PdfTest/";

        private const string V = @"Challenge.pdf";

        private const string V1 = @"gmail-cheat-sheet.pdf";


        [Theory]
        [InlineDataAttribute(V)]
        [InlineDataAttribute(V1)]
        async public void pdfTest(string path)
        {
            // Construir la ruta al archivo dentro del proyecto

            string fullPath = Path.Combine(Base, path);
            if (File.Exists(fullPath))
            {
                var memoryStream = new MemoryStream(File.ReadAllBytes(fullPath));

                // Posicionar el stream al inicio
                memoryStream.Position = 0;
             

                var controller = new PdfService();

                // Act: Llamamos al método que queremos probar
                var result = await controller.GetTextString(memoryStream);

                // Assert: Verificamos que el resultado sea correcto
               Assert.IsType<string>(result);
            }
            else
            {
                Assert.Fail("La ruta no partenece a ningun archivo");
            }
        }
    }
}
