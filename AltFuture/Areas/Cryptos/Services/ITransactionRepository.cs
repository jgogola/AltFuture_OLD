using AltFuture.Areas.Cryptos.Models;

namespace AltFutureWeb.Areas.Cryptos.Services
{
    public interface ITransactionRepository : IDisposable
    {
        Transaction TransactionGet(int transation_key);

        List<Transaction> TransactionGetList();


    }
}
