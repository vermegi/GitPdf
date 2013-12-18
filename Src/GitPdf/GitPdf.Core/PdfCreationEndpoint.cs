using System.IO;

namespace GitPdf.Core
{
    public class PdfCreationEndpoint
    {
        private readonly ICreatePdfFiles _pdfCreator;

        public PdfCreationEndpoint(ICreatePdfFiles pdfCreator)
        {
            _pdfCreator = pdfCreator;
        }

        public Stream CreatePdf(string htmlString)
        {
            return _pdfCreator.CreatePdf(htmlString);
        }
    }
}