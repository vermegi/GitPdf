using System.IO;

namespace GitPdf.Core
{
    public interface ICreatePdfFiles
    {
        Stream CreatePdf(string htmlString);
    }
}