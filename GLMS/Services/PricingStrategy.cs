namespace GLMS.Services
{
    public interface IPricingStrategy
    {
        double Calculate(double amount, double rate);
    }

    public class CurrencyPricingStrategy : IPricingStrategy
    {
        public double Calculate(double amount, double rate)
        {
            return amount * rate;
        }
    }
}
