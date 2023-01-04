using System.ComponentModel.DataAnnotations;
using AltFuture.Areas.Cryptos.Models;

namespace AltFutureWeb.Areas.Cryptos.Services
{
    public class CryptoPortfolioRepository : ICryptoPortfolioRepository
    {
        private readonly SQLService _db;
        public CryptoPortfolioRepository(ISQLService sqlService)
        {
            _db = (SQLService)sqlService;
        }

        public Crypto_Portfolio CryptoPortfolioGet(int lk_crypto_key)
        {
            DataTable dt = _db.GetDT("usp_Crypto_Portfolio_Get", new List<object> { lk_crypto_key });

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


                Crypto_Portfolio crypto_portfolio = new Crypto_Portfolio
                {
                    crypto_price = crypto_price,
                    number_of_orders = (int)dr["number_of_orders"],
                    quantity = (int)dr["quantity"],
                    average_buy_price = (decimal)dr["average_buy_price"],
                    total_invested = (decimal)dr["total_invested"],
                    unrealized_profit = (decimal)dr["unrealized_profit"],
                    current_worth = (decimal)dr["current_worth"]
                };

                return crypto_portfolio;
            }

            return new Crypto_Portfolio();
        }

        public List<Crypto_Portfolio> CryptoPortfolioGetList()
        {
            DataTable dt = _db.GetDT("usp_Crypto_Portfolio_Get_List");
            List<Crypto_Portfolio> crypto_portfolios = new List<Crypto_Portfolio>();

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
                    date_updated = Convert.IsDBNull(dr["date_updated"]) ? null : (DateTime)dr["date_updated"],
                    crypto_price = (decimal)dr["crypto_price"]
                };


                Crypto_Portfolio crypto_portfolio = new Crypto_Portfolio
                {
                    crypto_price = crypto_price,
                    number_of_orders = (int)dr["number_of_orders"],
                    quantity = (decimal)dr["quantity"],
                    average_buy_price = (decimal)dr["average_buy_price"],
                    total_invested = (decimal)dr["total_invested"],
                    unrealized_profit = (decimal)dr["unrealized_profit"],
                    current_worth = (decimal)dr["current_worth"]
                };

                crypto_portfolios.Add(crypto_portfolio);
            }

            return crypto_portfolios;
        }


        public void Dispose()
        {
            GC.Collect();
            System.Diagnostics.Debug.WriteLine("Disposing!!");
        }
    }
}
