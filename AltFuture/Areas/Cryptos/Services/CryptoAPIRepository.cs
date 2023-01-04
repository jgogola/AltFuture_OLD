using AltFuture.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Web;
using AltFuture.Areas.Cryptos.Models.APIModels;

namespace AltFutureWeb.Areas.Cryptos.Services
{
    public class CryptoAPIRepository : ICryptoAPIRepository
    {
        private SQLService _db;
        private readonly IConfiguration _configuration;
        private static string API_KEY = "";
        private static string API_KEY_SANDBOX = "";
        public CryptoAPIRepository(ISQLService sqlService, IConfiguration configuration)
        {
            _db = (SQLService)sqlService;
            _configuration = configuration;
            API_KEY = _configuration.GetValue<string>("APIKeys:CMC_PRO");
            API_KEY_SANDBOX = _configuration.GetValue<string>("APIKeys:CMC_SANDBOX");
        }

        public List<Crypto> APICoinMarketCapQuotesGetList(List<string> ticker_symbols)
        {
            var URL = new UriBuilder("https://pro-api.coinmarketcap.com/v2/cryptocurrency/quotes/latest");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["symbol"] = string.Join(",", ticker_symbols);
            queryString["convert"] = "USD";

            URL.Query = queryString.ToString();

            var client = new WebClient();
            client.Headers.Add("X-CMC_PRO_API_KEY", API_KEY);
            client.Headers.Add("Accepts", "application/json");

            string json = client.DownloadString(URL.ToString());


            JObject cyrptoAPIAssets = JObject.Parse(json);

            List<Crypto> cryptoAPIResults = new List<Crypto>();
            Crypto cryptoAPIResult;
            for (int i = 0; i < ticker_symbols.Count; i++)
            {
                cryptoAPIResult = cyrptoAPIAssets["data"][ticker_symbols[i]][0].ToObject<Crypto>();
                cryptoAPIResults.Add(cryptoAPIResult);
            }

            return cryptoAPIResults;
        }



        public void Dispose()
        {
            GC.Collect();
            System.Diagnostics.Debug.WriteLine("Disposing!!");
        }
    }
}
