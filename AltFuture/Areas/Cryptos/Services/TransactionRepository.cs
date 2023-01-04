using AltFuture.Areas.Cryptos.Models;
using System.ComponentModel.DataAnnotations;

namespace AltFutureWeb.Areas.Cryptos.Services
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly SQLService _db;
        public TransactionRepository(ISQLService sqlService)
        {
            _db = (SQLService)sqlService;
        }

        public Transaction TransactionGet(int transaction_key)
        {
            DataTable dt = _db.GetDT("usp_Transaction_Get", new List<object> { transaction_key });

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                LK_Crypto lk_crypto = new LK_Crypto
                {
                    lk_crypto_key = (int)dr["lk_crypto_key"],
                    crypto_name = (string)dr["crypto_name"],
                    ticker_symbol = (string)dr["ticker_symbol"]
                };

                LK_Action lk_action = new LK_Action
                {
                    lk_action_key = (int)dr["lk_action_key"],
                    action_name = (string)dr["action_name"]
                };

                LK_Exchange lk_exchange_from = new LK_Exchange
                {
                    lk_exchange_key = (int)dr["lk_exchange_key"],
                    exchange_name = (string)dr["exchange_name"]
                };

                LK_Exchange lk_exchange_to = new LK_Exchange
                {
                    lk_exchange_key = (int)dr["lk_exchange_key"],
                    exchange_name = (string)dr["exchange_name"]
                };

                Transaction transaction = new Transaction
                {
                    transaction_key = (int)dr["transaction_key"],
                    lk_crypto = lk_crypto,
                    lk_action = lk_action,
                    lk_exchange_from = lk_exchange_from,
                    lk_exchange_to = lk_exchange_to,
                    trade_id = (int)dr["trade_id"],
                    price = (decimal)dr["price"],
                    quantity = (decimal)dr["quantity"],
                    transaction_total = (decimal)dr["transaction_total"],
                    fee = (decimal)dr["fee"],
                    transaction_date = (DateTime)dr["transaction_date"],
                    notes = (string)dr["notes"],
                    portfolio = (string)dr["portfolio"],
                    add_by = (int)dr["add_by"],
                    imported_date = (DateTime)dr["imported_date"],
                    transaction_hash = (string)dr["transaction_hash"]
                };

                return transaction;
            }

            return new Transaction();
        }

        public List<Transaction> TransactionGetList()
        {
            DataTable dt = _db.GetDT("usp_Transaction_Get_List");
            List<Transaction> transactions = new List<Transaction>();

            foreach (DataRow dr in dt.Rows)
            {
                LK_Crypto lk_crypto = new LK_Crypto
                {
                    lk_crypto_key = (int)dr["lk_crypto_key"],
                    crypto_name = (string)dr["crypto_name"],
                    ticker_symbol = (string)dr["ticker_symbol"]
                };

                LK_Action lk_action = new LK_Action
                {
                    lk_action_key = (int)dr["lk_action_key"],
                    action_name = (string)dr["action_name"]
                };

                LK_Exchange lk_exchange_from = new LK_Exchange
                {
                    lk_exchange_key = (int)dr["lk_exchange_key"],
                    exchange_name = (string)dr["exchange_name"]
                };

                LK_Exchange lk_exchange_to = new LK_Exchange
                {
                    lk_exchange_key = (int)dr["lk_exchange_key"],
                    exchange_name = (string)dr["exchange_name"]
                };

                Transaction transaction = new Transaction
                {
                    transaction_key = (int)dr["transaction_key"],
                    lk_crypto = lk_crypto,
                    lk_action = lk_action,
                    lk_exchange_from = lk_exchange_from,
                    lk_exchange_to = lk_exchange_to,
                    trade_id = (int)dr["trade_id"],
                    price = (decimal)dr["price"],
                    quantity = (decimal)dr["quantity"],
                    transaction_total = (decimal)dr["transaction_total"],
                    fee = (decimal)dr["fee"],
                    transaction_date = (DateTime)dr["transaction_date"],
                    notes = (string)dr["notes"],
                    portfolio = (string)dr["portfolio"],
                    add_by = (int)dr["add_by"],
                    imported_date = (DateTime)dr["imported_date"],
                    transaction_hash = (string)dr["transaction_hash"]
                };

                transactions.Add(transaction);
            }

            return transactions;
        }

        public void Dispose()
        {
            GC.Collect();
            System.Diagnostics.Debug.WriteLine("Disposing!!");
        }
    }
}
