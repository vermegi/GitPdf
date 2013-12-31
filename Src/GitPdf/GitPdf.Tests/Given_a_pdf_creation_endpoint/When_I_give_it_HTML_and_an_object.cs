using System.IO;
using GitPdf.Core;
using GitPdf.Tests.Utilities;
using Moq;
using Xunit;

namespace GitPdf.Tests.Given_a_pdf_creation_endpoint
{
    public class When_I_give_it_HTML_and_an_object : AAATest
    {
        private Mock<ICreatePdfFiles> _mockPdfCreator;
        private PdfCreationEndpoint _sut;
        private string _htmlString;
        private object _anObject;
        private Mock<ITransform> _transformer;
        private string _resultFromTransformer;
        private Stream _result;
        private Stream _expectedResult;

        protected override void Arrange()
        {
            _htmlString = "yada dada";

            _resultFromTransformer = "some other yada dada";
            _transformer = new Mock<ITransform>();
            _transformer.Setup(trans => trans.Transform(It.IsAny<string>(), It.IsAny<object>()))
                .Returns(_resultFromTransformer);

            _expectedResult = new MemoryStream(new byte[] { 1, 2, 3 });
            _mockPdfCreator = new Mock<ICreatePdfFiles>();
            _mockPdfCreator.Setup(pdf => pdf.CreatePdf(It.IsAny<string>()))
                .Returns(_expectedResult);

            _sut = new PdfCreationEndpoint(_mockPdfCreator.Object, _transformer.Object);
        }

        protected override void Act()
        {
            _result = _sut.CreatePdf(_htmlString, _anObject);
        }

        [Fact]
        public void It_asks_the_transformer_to_transform_the_html_with_the_object()
        {
            _transformer.Verify(t => t.Transform(_htmlString, _anObject));
        }

        [Fact]
        public void It_tells_the_pdf_creator_to_create_a_pdf_based_on_the_output_of_the_transformer()
        {
            _mockPdfCreator.Verify(pdf => pdf.CreatePdf(_resultFromTransformer));
        }

        [Fact]
        public void It_returns_the_result_of_the_pdf_creator()
        {
            Assert.Equal(_expectedResult, _result);
        }
    }
}