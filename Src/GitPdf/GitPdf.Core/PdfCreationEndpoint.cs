using System.IO;

namespace GitPdf.Core
{
    public class PdfCreationEndpoint
    {
        private readonly ICreatePdfFiles _pdfCreator;
        private readonly ITransform _transformer;

        public PdfCreationEndpoint(ICreatePdfFiles pdfCreator, ITransform transformer)
        {
            _pdfCreator = pdfCreator;
            _transformer = transformer;
        }

        public Stream CreatePdf(string htmlString)
        {
            return _pdfCreator.CreatePdf(htmlString);
        }

        public Stream CreatePdf(string htmlString, object anObject)
        {
            var result = _transformer.Transform(htmlString, anObject);
            return CreatePdf(result);
        }
    }
}