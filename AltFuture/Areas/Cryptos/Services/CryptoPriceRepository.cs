using AltFuture.Areas.Cryptos.Models;
using System.ComponentModel.DataAnnotations;

namespace AltFutureWeb.Areas.Cryptos.Services
{
    public class CryptoPriceRepository : ICryptoPriceRepository
    {
        private readonly SQLService _db;
        public CryptoPriceRepository(ISQLService sqlService)
        {
            _db = (SQLService)sqlService;
        }

        public Crypto_Price CryptoPriceGetCurrent(int lk_crypto_key)
        {
            DataTable dt = _db.GetDT("usp_Crypto_Price_Get_Current", new List<object> { lk_crypto_key });

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                LK_Crypto lk_crypto = new LK_Crypto
                {
                    lk_crypto_key = (int)dr["lk_crypto_key"],
                    crypto_name = (string)dr["crypto_name"],
                    ticker_symbol = (string)dr["ticker_symbol"]
                };

                Crypto_Price crypto_price = new Crypto_Price
                {
                    crypto_price_key = (int)dr["crypto_price_key"],
                    lk_crypto = lk_crypto,
                    date_updated = (DateTime)dr["date_updated"],
                    crypto_price = (decimal)dr["crypto_price"]
                };


                return crypto_price;
            }

            return new Crypto_Price();
        }

        public List<Crypto_Price> CryptoPriceGetListCurrent()
        {
            DataTable dt = _db.GetDT("usp_Crypto_Price_Get_List_Current");
            List<Crypto_Price> crypto_prices = new List<Crypto_Price>();

            foreach (DataRow dr in dt.Rows)
            {
                LK_Crypto lk_crypto = new LK_Crypto
                {
                    lk_crypto_key = (int)dr["lk_crypto_key"],
                    crypto_name = (string)dr["crypto_name"],
                    ticker_symbol = (string)dr["ticker_symbol"]
                };

                Crypto_Price crypto_price = new Crypto_Price
                {
                    crypto_price_key = (int)dr["crypto_price_key"],
                    lk_crypto = lk_crypto,
                    date_updated = (DateTime)dr["date_updated"],
                    crypto_price = (decimal)dr["crypto_price"]
                };


                crypto_prices.Add(crypto_price);
            }

            return crypto_prices;
        }

        public int CryptoPriceAdd(string ticker_symbol, decimal? crypto_price)
        {
            int crypto_price_key = _db.GetRetVal("usp_Crypto_Price_Add", new List<object> { ticker_symbol, crypto_price });
            return crypto_price_key;

        }


        public void Dispose()
        {
            GC.Collect();
            System.Diagnostics.Debug.WriteLine("Disposing!!");
        }
    }
}
