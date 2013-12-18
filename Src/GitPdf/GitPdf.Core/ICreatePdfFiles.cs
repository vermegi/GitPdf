using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

namespace GitPdf.Core
{
    public interface ICreatePdfFiles
    {
        Stream CreatePdf(string htmlString);
    }

    internal class PdfFileCreator : ICreatePdfFiles
    {
        public Stream CreatePdf(string htmlString)
        {
            var doc = new Document();
            var memoryStream = new MemoryStream();
            var pdfWriter = PdfWriter.GetInstance(doc, memoryStream);
            doc.Open();
            pdfWriter.CloseStream = false;

            XMLWorkerHelper.GetInstance().ParseXHtml(pdfWriter, doc, new StringReader(htmlString));

            doc.Close();
            pdfWriter.Close();

            return memoryStream;
        }
    }
}