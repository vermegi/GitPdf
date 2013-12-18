using System.IO;
using GitPdf.Core;
using GitPdf.Tests.Utilities;
using Moq;
using Xunit;

namespace GitPdf.Tests.Given_a_pdf_creation_endpoint
{
    public class When_I_give_it_plain_HTML : AAATest
    {
        private PdfCreationEndpoint _sut;
        private string _htmlString;
        private Mock<ICreatePdfFiles> _pdfCreatorMock;
        private Stream _result;
        private Stream _expectedResult;

        protected override void Arrange()
        {
            _htmlString = "yada dada";

            _expectedResult = new MemoryStream(new byte[]{1, 2, 3});
            _pdfCreatorMock = new Mock<ICreatePdfFiles>();
            _pdfCreatorMock.Setup(pdf => pdf.CreatePdf(It.IsAny<string>()))
                .Returns(_expectedResult);

            _sut = new PdfCreationEndpoint(_pdfCreatorMock.Object);
        }

        protected override void Act()
        {
            _result = _sut.CreatePdf(_htmlString);
        }

        [Fact]
        public void It_tells_the_pdf_creator_to_create_this_pdf()
        {
            _pdfCreatorMock.Verify(pdf => pdf.CreatePdf(_htmlString));
        }

        [Fact]
        public void It_returns_the_result_of_the_pdf_creator()
        {
            Assert.Equal(_expectedResult, _result);
        }
    }
}