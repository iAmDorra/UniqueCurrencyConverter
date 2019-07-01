using Microsoft.WindowsAzure.Storage.Table;

namespace CurrencyConverter.Infrastructure
{
    public partial class Rates
    {
        public class CurrencyRate : TableEntity
        {
            public CurrencyRate()
            {
            }

            public CurrencyRate(string currencySource, string currency, double rate)
                : base(currencySource, currency)
            {
                Rate = rate;
            }
            
            public double Rate { get; set; }
        }
    }
}
