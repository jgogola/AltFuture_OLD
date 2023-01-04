using AltFuture.Areas.Cryptos.Models;

namespace AltFutureWeb.Areas.Cryptos.Services
{
    public interface ICryptoPortfolioRepository : IDisposable
    {
        Crypto_Portfolio CryptoPortfolioGet(int lk_crypto_key);

        List<Crypto_Portfolio> CryptoPortfolioGetList();

    }
}
