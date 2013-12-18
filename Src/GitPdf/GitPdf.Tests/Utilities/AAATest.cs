using Xunit;

namespace GitPdf.Tests.Utilities
{
    public abstract class AAATest : IUseFixture<SetItUp>
    {
        public void SetFixture(SetItUp data)
        {
            Arrange();
            Act();
        }

        protected abstract void Arrange();
        protected abstract void Act();
    }
}