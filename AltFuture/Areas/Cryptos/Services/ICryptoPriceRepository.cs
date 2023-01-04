using AltFuture.Areas.Cryptos.Models;

namespace AltFutureWeb.Areas.Cryptos.Services
{
    public interface ICryptoPriceRepository : IDisposable
    {
        Crypto_Price CryptoPriceGetCurrent(int lk_crypto_key);

        List<Crypto_Price> CryptoPriceGetListCurrent();

        int CryptoPriceAdd(string ticker_symbol, decimal? crypto_price);
    }
}
