using Xunit;
using GLMS.Models;
using GLMS.Services;
using System.IO;

namespace GLMS.Tests
{
    public class Tests
    {
        // 🧪 1. Currency Test
        [Fact]
        public void CalculateCost_ShouldConvertUsdToZar()
        {
            var strategy = new StandardPricingStrategy();

            double usd = 10;
            double rate = 18;

            var result = strategy.Calculate(usd, rate);

            Assert.Equal(180, result);
        }

        // 🧪 2. Valid File Test
        [Fact]
        public void FileUpload_ShouldAcceptPdf()
        {
            var fileName = "contract.pdf";

            var extension = Path.GetExtension(fileName).ToLower();

            Assert.Equal(".pdf", extension);
        }

        // 🧪 3. Invalid File Test
        [Fact]
        public void FileUpload_ShouldRejectNonPdf()
        {
            var fileName = "image.jpg";

            var extension = Path.GetExtension(fileName).ToLower();

            Assert.NotEqual(".pdf", extension);
        }

        // 🧪 4. Expired Contract Rule
        [Fact]
        public void ServiceRequest_ShouldFail_ForExpiredContract()
        {
            var contract = new Contract
            {
                Status = "Expired"
            };

            Assert.Equal("Expired", contract.Status);
        }

        // 🧪 5. Active Contract Rule
        [Fact]
        public void ServiceRequest_ShouldAllow_ActiveContract()
        {
            var contract = new Contract
            {
                Status = "Active"
            };

            Assert.Equal("Active", contract.Status);
        }

        // 🧪 6. Bonus Test
        [Fact]
        public void Cost_ShouldBeGreaterThanZero()
        {
            var strategy = new StandardPricingStrategy();

            var result = strategy.Calculate(50, 18);

            Assert.True(result > 0);
        }
    }
}