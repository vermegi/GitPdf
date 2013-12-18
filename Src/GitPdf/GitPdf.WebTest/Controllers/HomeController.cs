using System.Web.Mvc;
using GitPdf.Core;

namespace GitPdf.WebTest.Controllers
{
    public class HomeController : Controller
    {
        private const string _htmlString = @"<html xmlns='http://www.w3.org/1999/xhtml' xml:lang='en' lang='en'>
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
</html>";

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ShowPdf()
        {
            var pdfEndpoint = new PdfCreationEndpoint(new PdfFileCreator());

            var pdf = pdfEndpoint.CreatePdf(_htmlString);

            return new FileStreamResult(pdf, "application/pdf");
        }

        public ActionResult DownloadPdf()
        {
            var pdfEndpoint = new PdfCreationEndpoint(new PdfFileCreator());

            var pdf = pdfEndpoint.CreatePdf(_htmlString);

            return new FileStreamResult(pdf, "application/pdf")
            {
                FileDownloadName = "test.pdf"
            };
        }
    }
}