using AltFuture.Areas.Cryptos.Models;

namespace AltFutureWeb.Areas.Cryptos.Services
{
    public interface ILKCryptoRepository : IDisposable
    {
        LK_Crypto LKCryptoGet(int lk_crypto_key);

        List<LK_Crypto> LKCryptoGetList();


    }
}
