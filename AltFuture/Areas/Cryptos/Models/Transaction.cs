using System.ComponentModel.DataAnnotations;

namespace AltFuture.Areas.Cryptos.Models
{
    public class Transaction
    {
        public int transaction_key { get; set; } = 0;

        [Display(Name = "Crypto")]
        public LK_Crypto lk_crypto { get; set; } = new LK_Crypto();

        [Display(Name = "Action")]
        public LK_Action lk_action { get; set; } = new LK_Action();

        [Display(Name = "Exchange From")]
        public LK_Exchange lk_exchange_from { get; set; } = new LK_Exchange();

        [Display(Name = "Exchange To")]
        public LK_Exchange lk_exchange_to { get; set; } = new LK_Exchange();

        public int trade_id { get; set; } = 0;
        public decimal price { get; set; } = 0.00M;
        public decimal quantity { get; set; } = 0.00M;
        public decimal transaction_total { get; set; } = 0.00M;
        public decimal fee { get; set; } = 0.00M;
        public DateTime transaction_date { get; set; }
        public string notes { get; set; } = "";
        public string portfolio { get; set; } = "";
        public int add_by { get; set; }
        public DateTime imported_date { get; set; }
        public string transaction_hash { get; set; } = "";
    }
}
