using System.ComponentModel.DataAnnotations;

namespace AltFuture.Areas.Cryptos.Models
{
    public class Crypto_Price
    {
        public int crypto_price_key { get; set; } = 0;

        [Display(Name = "Crypto")]
        public LK_Crypto lk_crypto { get; set; } = new LK_Crypto();

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? date_updated { get; set; }
        public decimal crypto_price { get; set; } = 0.00M;
    }
}
