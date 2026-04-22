namespace GLMS.Services
{
    
        public class StandardPricingStrategy : IPricingStrategy
        {
            public double Calculate(double usdAmount, double rate)
            {
                return usdAmount * rate;
            }
        }
    }

