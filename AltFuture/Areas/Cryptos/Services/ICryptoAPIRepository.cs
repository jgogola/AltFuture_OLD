using AltFuture.Areas.Cryptos.Models.APIModels;

namespace AltFutureWeb.Areas.Cryptos.Services
{
    public interface ICryptoAPIRepository : IDisposable
    {

        List<Crypto> APICoinMarketCapQuotesGetList(List<string> ticker_symbols);

    }
}
