using System.ComponentModel.DataAnnotations;

namespace AltFuture.Areas.Cryptos.Models
{
    public class Crypto_Portfolio
    {

        [Display(Name = "Crypto Price")]
        public Crypto_Price crypto_price { get; set; } = new Crypto_Price();
        public int number_of_orders { get; set; } = 0;
        public decimal quantity { get; set; } = 0.00M;
        public decimal average_buy_price { get; set; } = 0.00M;
        public decimal total_invested { get; set; } = 0.00M;
        public decimal unrealized_profit { get; set; } = 0.00M;
        public decimal current_worth { get; set; } = 0.00M;

    }
}
