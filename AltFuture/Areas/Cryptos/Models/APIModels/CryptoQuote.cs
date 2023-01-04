using Newtonsoft.Json;

namespace AltFuture.Areas.Cryptos.Models.APIModels
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    public class Crypto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public string slug { get; set; }
        public int num_market_pairs { get; set; }
        public DateTime date_added { get; set; }

        [JsonIgnore]
        public List<Tag> tags { get; set; }
        public long? max_supply { get; set; } = 0;
        public long? circulating_supply { get; set; } = 0;
        public long? total_supply { get; set; } = 0;
        public int? is_active { get; set; }
        public object? platform { get; set; }
        public int? cmc_rank { get; set; }
        public int? is_fiat { get; set; }
        public object self_reported_circulating_supply { get; set; }
        public object self_reported_market_cap { get; set; }
        public object tvl_ratio { get; set; }
        public DateTime last_updated { get; set; }
        public Quote quote { get; set; }
    }


    public class Quote
    {
        public USD USD { get; set; }
    }



    public class Status
    {
        public DateTime timestamp { get; set; }
        public int error_code { get; set; }
        public object error_message { get; set; }
        public int elapsed { get; set; }
        public int credit_count { get; set; }
        public object notice { get; set; }
    }

    public class Tag
    {
        public string slug { get; set; }
        public string name { get; set; }
        public string category { get; set; }
    }

    public class USD
    {
        public decimal? price { get; set; } = 0.00M;
        public decimal? volume_24h { get; set; } = 0.00M;
        public decimal? volume_change_24h { get; set; } = 0.00M;
        public decimal? percent_change_1h { get; set; } = 0.00M;
        public decimal? percent_change_24h { get; set; } = 0.00M;
        public decimal? percent_change_7d { get; set; } = 0.00M;
        public decimal? percent_change_30d { get; set; } = 0.00M;
        public decimal? percent_change_60d { get; set; } = 0.00M;
        public decimal? percent_change_90d { get; set; } = 0.00M;
        public decimal? market_cap { get; set; } = 0.00M;
        public decimal? market_cap_dominance { get; set; } = 0.00M;
        public decimal? fully_diluted_market_cap { get; set; } = 0.00M;
        public object tvl { get; set; }
        public DateTime last_updated { get; set; }
    }


}
