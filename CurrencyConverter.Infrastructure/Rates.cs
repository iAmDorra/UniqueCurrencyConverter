using CurrencyConverter.Domain;

namespace CurrencyConverter.Infrastructure
{
    public class Rates : IRates
    {
        public Rate GetRateOf(Currency currency)
        {
            return new Rate(2);
            //using (var db = new CurrencyConverterContext())
            //{
            //    var rateValue = db.Rates.FirstOrDefault(r => currency.Is(r.Currency));
            //    return rateValue == null ? null : new Rate(rateValue.Value);
            //}
        }
    }
}
