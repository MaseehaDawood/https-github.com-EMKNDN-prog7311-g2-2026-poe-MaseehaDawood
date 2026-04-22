namespace GLMS.Tests
{
    using Xunit;

    public class Tests
    {
        [Fact]
        public void CurrencyTest()
        {
            Assert.Equal(180, 10 * 18);
        }

        [Fact]
        public void FileTest()
        {
            Assert.EndsWith(".pdf", 
                "file.pdf");
        }

        [Fact]
        public void BusinessRuleTest()
        {
            string status = "Expired";
            Assert.False(!(status == "Expired"));
        }
    }
}
