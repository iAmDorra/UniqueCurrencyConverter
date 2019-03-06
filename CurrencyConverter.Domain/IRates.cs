using System.Threading.Tasks;

namespace CurrencyConverter.Domain
{
    public interface IRates
    {
        Task<Rate> GetRateOf(Currency currency);
    }
}