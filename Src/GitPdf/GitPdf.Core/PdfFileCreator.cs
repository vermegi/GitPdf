using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

namespace GitPdf.Core
{
    public class PdfFileCreator : ICreatePdfFiles
    {
        public Stream CreatePdf(string htmlString)
        {
            var outputStream = new MemoryStream();
            var input = new StringReader(htmlString);

            using (var doc = new Document())
            {
                var pdfWriter = PdfWriter.GetInstance(doc, outputStream);
                pdfWriter.CloseStream = false;
                doc.Open();

                XMLWorkerHelper.GetInstance().ParseXHtml(pdfWriter, doc, input);

                doc.Close();
                pdfWriter.Close();
            }

            outputStream.Position = 0;
            return outputStream;
        }
    }
}