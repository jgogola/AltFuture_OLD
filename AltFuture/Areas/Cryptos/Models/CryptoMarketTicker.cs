namespace AltFuture.Areas.Cryptos.Models
{
    public class CryptoMarketTicker
    {
        public string CryptoName { get; set; } = "";
        public string TickerSymbol { get; set; } = "";
        public DateTime LastUpdated { get; set; }
        public decimal Price { get; set; } = 0;
    }
}
