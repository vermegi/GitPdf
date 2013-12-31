namespace GitPdf.Core
{
    public interface ITransform
    {
        string Transform(string htmlString, object anObject);
    }
}