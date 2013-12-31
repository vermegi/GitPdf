using GitPdf.Core;

namespace GitPdf.Razor
{
    public class RazorTransformer : ITransform
    {
        public string Transform(string htmlString, object anObject)
        {
            return RazorEngine.Razor.Parse(htmlString, anObject);
        }
    }
}