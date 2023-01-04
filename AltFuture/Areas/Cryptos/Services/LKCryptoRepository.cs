using AltFuture.Areas.Cryptos.Models;
using System.ComponentModel.DataAnnotations;

namespace AltFutureWeb.Areas.Cryptos.Services
{
    public class LKCryptoRepository : ILKCryptoRepository
    {
        private readonly SQLService _db;
        public LKCryptoRepository(ISQLService sqlService)
        {
            _db = (SQLService)sqlService;
        }

        public LK_Crypto LKCryptoGet(int lk_crypto_key)
        {
            DataTable dt = _db.GetDT("usp_LK_Crypto_Get", new List<object> { lk_crypto_key });

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                LK_Crypto lk_crypto = new LK_Crypto
                {
                    lk_crypto_key = (int)dr["lk_crypto_key"],
                    crypto_name = (string)dr["crypto_name"],
                    ticker_symbol = (string)dr["ticker_symbol"]
                };

                return lk_crypto;
            }

            return new LK_Crypto();
        }

        public List<LK_Crypto> LKCryptoGetList()
        {
            DataTable dt = _db.GetDT("usp_LK_Crypto_Get_List");
            List<LK_Crypto> lk_cryptos = new List<LK_Crypto>();

            foreach (DataRow dr in dt.Rows)
            {
                LK_Crypto lk_crypto = new LK_Crypto
                {
                    lk_crypto_key = (int)dr["lk_crypto_key"],
                    crypto_name = (string)dr["crypto_name"],
                    ticker_symbol = (string)dr["ticker_symbol"]
                };

                lk_cryptos.Add(lk_crypto);
            }

            return lk_cryptos;
        }

        public void Dispose()
        {
            GC.Collect();
            System.Diagnostics.Debug.WriteLine("Disposing!!");
        }
    }
}
