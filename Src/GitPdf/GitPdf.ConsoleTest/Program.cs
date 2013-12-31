using System.IO;
using GitPdf.Core;
using GitPdf.Razor;

namespace GitPdf.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            WritePdfWithSimpleHtml();

            WritePdfWithTemplatedHtml();
        }

        private static void WritePdfWithTemplatedHtml()
        {
            var pdfEndpoint = new PdfCreationEndpoint(new PdfFileCreator(), new RazorTransformer());

            var pdf = pdfEndpoint.CreatePdf(@"<html xmlns='http://www.w3.org/1999/xhtml' xml:lang='en' lang='en'>
<head>
<title> Strict DTD XHTML Example </title>
<style type='text/css'>
	body{
		background-color:black;
		color:white;
		width:100%;
		height:100%;
        font-family:'Times New Roman', Times, serif
	}
</style>
</head>
<body >
<div id='content'>
<ul>
   <li><p>@Model.FirstSentence</p></li>
   <li><p>Aliquam tincidunt mauris eu risus.</p></li>
   <li><a href='@Model.Url'>Test</a></li>
    <li><a href='Download/test.html'>Test 2</a></li>
</ul>
<br/>
<p>Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Vestibulum tortor quam, feugiat vitae, ultricies eget, tempor sit amet, ante. Donec eu libero sit amet quam egestas semper. Aenean ultricies mi vitae est. Mauris placerat eleifend leo.</p>
</div>
</body>
</html>", new{FirstSentence = "yabbedabbedoe", Url = "http://proq.blogspot.com"});

            using (var file = new FileStream("./test2.pdf", FileMode.Create, FileAccess.Write))
            {
                var bytes = new byte[pdf.Length];
                pdf.Read(bytes, 0, (int)pdf.Length);
                file.Write(bytes, 0, bytes.Length);
                pdf.Close();
            }
        }

        private static void WritePdfWithSimpleHtml()
        {
            var pdfEndpoint = new PdfCreationEndpoint(new PdfFileCreator(), null);

            var pdf = pdfEndpoint.CreatePdf(@"<html xmlns='http://www.w3.org/1999/xhtml' xml:lang='en' lang='en'>
<head>
<title> Strict DTD XHTML Example </title>
<style type='text/css'>
	body{
		background-color:black;
		color:white;
		width:100%;
		height:100%;
        font-family:'Times New Roman', Times, serif
	}
</style>
</head>
<body >
<div id='content'>
<ul>
   <li><p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit.</p></li>
   <li><p>Aliquam tincidunt mauris eu risus.</p></li>
   <li><a href='http:\\www.google.com'>Test</a></li>
    <li><a href='Download/test.html'>Test 2</a></li>
</ul>
<br/>
<p>Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Vestibulum tortor quam, feugiat vitae, ultricies eget, tempor sit amet, ante. Donec eu libero sit amet quam egestas semper. Aenean ultricies mi vitae est. Mauris placerat eleifend leo.</p>
</div>
</body>
</html>");

            using (var file = new FileStream("./test.pdf", FileMode.Create, FileAccess.Write))
            {
                var bytes = new byte[pdf.Length];
                pdf.Read(bytes, 0, (int) pdf.Length);
                file.Write(bytes, 0, bytes.Length);
                pdf.Close();
            }
        }
    }
}

