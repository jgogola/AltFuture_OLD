using AltFuture.Areas.Cryptos.Models.APIModels;
using AltFuture.Areas.Cryptos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using System.Web;
using AltFutureWeb.Areas.Cryptos.Services;

namespace AltFuture.Areas.Cryptos.Controllers
{
    [Area("Cryptos")]
    [Authorize]
    [Authorize(Policy = "CryptoViewPolicy")]
    public class HomeController : AltFuture.Controllers.BaseController
    {
        private static string API_KEY = ""; 
        private static string API_KEY_SANDBOX = "";

        public HomeController(
            // ILogger<HomeController> logger,
            IConfiguration configuration,
            ISQLService sqlService
            ) : base(configuration, sqlService)
        {
            //  _logger = logger;
            API_KEY = configuration.GetValue<string>("APIKeys:CMC_PRO");
            API_KEY_SANDBOX = configuration.GetValue<string>("APIKeys:CMC_SANDBOX");

        }

        public ActionResult Index()
        {
            ViewBag.APIData = makeCMC_API_Sandbox_Call();
            
            return View();
        }

       
        public IActionResult CryptoMarketTicker()
        {
            IList<CryptoMarketTicker> model = getCryptoAssetPrices2();
            return View(model);
        }

        #region "Coin Market CAP API Sandbox"
        
            static string makeCMC_API_Sandbox_Call()
            {
                var URL = new UriBuilder("https://sandbox-api.coinmarketcap.com/v1/cryptocurrency/listings/latest");

                var queryString = HttpUtility.ParseQueryString(string.Empty);
                queryString["start"] = "1";
                queryString["limit"] = "5000";
                queryString["convert"] = "USD";

                URL.Query = queryString.ToString();

                var client = new WebClient();
                client.Headers.Add("X-CMC_PRO_API_KEY", API_KEY_SANDBOX);
                client.Headers.Add("Accepts", "application/json");
                return client.DownloadString(URL.ToString());

            }

            static string makeCMC_API_Pro_Call()
            {
                var URL = new UriBuilder("https://pro-api.coinmarketcap.com/v2/cryptocurrency/quotes/latest");

                var queryString = HttpUtility.ParseQueryString(string.Empty);
                queryString["symbol"] = "BTC,ADA";
                queryString["convert"] = "USD,CAD";

                URL.Query = queryString.ToString();

                var client = new WebClient();
                client.Headers.Add("X-CMC_PRO_API_KEY", API_KEY);
                client.Headers.Add("Accepts", "application/json");
                return client.DownloadString(URL.ToString());

            }


            static IList<CryptoMarketTicker> getCryptoAssetPricesSandbox()
            {
                var URL = new UriBuilder("https://sandbox-api.coinmarketcap.com/v1/cryptocurrency/listings/latest");

                var queryString = HttpUtility.ParseQueryString(string.Empty);
                queryString["start"] = "1";
                queryString["limit"] = "5000";
                queryString["convert"] = "USD";

                URL.Query = queryString.ToString();

                var client = new WebClient();
                client.Headers.Add("X-CMC_PRO_API_KEY", API_KEY_SANDBOX);
                client.Headers.Add("Accepts", "application/json");
                string json = client.DownloadString(URL.ToString());


                JObject cyrptoAssets = JsonConvert.DeserializeObject<JObject>(json);
                var dataRows = (JArray)cyrptoAssets["data"];

                IList<CryptoMarketTicker> priceList = new List<CryptoMarketTicker>();
                for (var i = 0; i < dataRows.Count; i++)
                {
                    CryptoMarketTicker price = new CryptoMarketTicker();
                    price.CryptoName = dataRows[i]["name"].ToString();
                    price.TickerSymbol = dataRows[i]["symbol"].ToString();
                    price.LastUpdated = DateTime.Parse(dataRows[i]["last_updated"].ToString());
                    price.Price = Decimal.Parse(dataRows[i]["quote"]["USD"]["price"].ToString());

                    priceList.Add(price);
                }

                return priceList;


                //JObject cyrptoAssets = JObject.Parse(json);

                //IList<JToken> cryptoAssetData = cyrptoAssets["data"].Children().ToList();

                //IList<CryptoAssetPrice> priceList = new List<CryptoAssetPrice>();
                //foreach(JToken data in cryptoAssetData)
                //{
                //    CryptoAssetPrice price = new CryptoAssetPrice();
                //    price.CryptoName = data
                //}

            }


            public IActionResult Quotes()
            {
                IList<Crypto> model = getQuotes();
                return View(model);
            }
            static IList<Crypto> getQuotes()
            {
                var json = System.IO.File.ReadAllText("crypto_quotes.json");
                JObject jo = JObject.Parse(json);

                string[] tickers = { "ADA", "BTC" };

                IList<Crypto> searchResults = new List<Crypto>();
                Crypto searchResult;
                for (int i = 0; i < tickers.Length; i++)
                {
                    searchResult = jo["data"][tickers[i]][0].ToObject<Crypto>();
                    searchResults.Add(searchResult);
                }



                // get JSON result objects into a list
                // IList<JToken> results = jo["data"].Children().ToList();

                // serialize JSON results into .NET objects
                //  IList<Crypto> searchResults = new List<Crypto>();
                //foreach (JToken result in results)
                //{
                //    // JToken.ToObject is a helper method that uses JsonSerializer internally
                //    Crypto searchResult = result.ToObject<Crypto>();
                //    searchResults.Add(searchResult);
                //}

                return searchResults;
            }



            public IActionResult Status()
            {
                Status model = getAPIStatus();
                return View(model);
            }
            static Status getAPIStatus()
            {
                var json = System.IO.File.ReadAllText("crypto_quotes.json");
                JObject j = JObject.Parse(json);
                JToken so = j["status"];


                Status s = so.ToObject<Status>();
                return s;
            }

            static IList<CryptoMarketTicker> getCryptoAssetPrices2()
            {
                //var URL = new UriBuilder("https://sandbox-api.coinmarketcap.com/v2/cryptocurrency/quotes/latest");

                //var queryString = HttpUtility.ParseQueryString(string.Empty);
                //queryString["symbol"] = "BTC,ADA";

                //URL.Query = queryString.ToString();

                //var client = new WebClient();
                //client.Headers.Add("X-CMC_PRO_API_KEY", API_KEY);
                //client.Headers.Add("Accepts", "application/json");
                //string json = client.DownloadString(URL.ToString());

                var json = System.IO.File.ReadAllText("crypto_quotes.json");
                JObject cryptoAssets = JsonConvert.DeserializeObject<JObject>(json);
                IList<CryptoMarketTicker> priceList = new List<CryptoMarketTicker>();
                CryptoMarketTicker price = new CryptoMarketTicker();
                price.CryptoName = cryptoAssets["data"]["ADA"][0]["name"].ToString();
                price.TickerSymbol = cryptoAssets["data"]["ADA"][0]["symbol"].ToString();
                price.LastUpdated = DateTime.Parse(cryptoAssets["data"]["ADA"][0]["last_updated"].ToString());
                price.Price = Decimal.Parse(cryptoAssets["data"]["ADA"][0]["quote"]["USD"]["price"].ToString());

                priceList.Add(price);
                return priceList;
                //JObject cryptoAssets = JsonConvert.DeserializeObject<JObject>(json);
                //JObject o = JsonConvert.PopulateObject(cryptoAssets);
                //var dataRows = (JArray)cyrptoAssets;

                //IList<CryptoMarketTicker> priceList = new List<CryptoMarketTicker>();
                //for (var i = 0; i < dataRows.Count; i++)
                //{
                //    CryptoMarketTicker price = new CryptoMarketTicker();
                //    price.CryptoName = dataRows[i]["name"].ToString();
                //    price.TickerSymbol = dataRows[i]["symbol"].ToString();
                //    price.LastUpdated = DateTime.Parse(dataRows[i]["last_updated"].ToString());
                //    price.Price = Decimal.Parse(dataRows[i]["quote"]["USD"]["price"].ToString());

                //    priceList.Add(price);
                //}

                //return priceList;


                //JObject cyrptoAssets = JObject.Parse(json);

                //IList<JToken> cryptoAssetData = cyrptoAssets["data"].Children().ToList();

                //IList<CryptoAssetPrice> priceList = new List<CryptoAssetPrice>();
                //foreach(JToken data in cryptoAssetData)
                //{
                //    CryptoAssetPrice price = new CryptoAssetPrice();
                //    price.CryptoName = data
                //}

            }

        #endregion
    }
}
