using System.Threading.Tasks;
using CurrencyConverter.Domain;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace CurrencyConverter.Infrastructure
{
    public partial class Rates : IRates
    {
        public async Task<Rate> GetRateOf(Currency currency)
        {
            string connectionString = @"DefaultEndpointsProtocol=https;AccountName=currencyreference;AccountKey=aVwBrqSvyOGRXVVrCH4NDjI3dQSSqKy9IxOgaAGSxh/CbF18QuuWGgF0VBiRc0RQL/Kc1i9majun1+r2c1fhvQ==;EndpointSuffix=core.windows.net";
            var storageAccount = CloudStorageAccount.Parse(connectionString);
            var tableClient = storageAccount.CreateCloudTableClient();

            string currencyTableName = "currency";
            var currencyTable = tableClient.GetTableReference(currencyTableName);

            var euro = "EUR";
            var usd = "USD";

            CreateData(euro, usd, currencyTable);

            var currencyRate = await GetCurrencyRate(euro, usd, currencyTable);

            var rate = (decimal)currencyRate.Rate;
            return new Rate(rate);
        }

        private static async Task<CurrencyRate> GetCurrencyRate(string euro, string usd, CloudTable currencyTable)
        {
            TableOperation retOp = TableOperation.Retrieve<CurrencyRate>(euro, usd);
            TableResult tr = await currencyTable.ExecuteAsync(retOp);
            var currencyRate = tr.Result as CurrencyRate;
            return currencyRate;
        }

        private static void CreateData(string euro, string usd, CloudTable currencyTable)
        {
            var currencyRate = new CurrencyRate(euro, usd, 2);
            TableOperation insertOp = TableOperation.Insert(currencyRate);
            var tr = currencyTable.ExecuteAsync(insertOp);
        }
    }
}
