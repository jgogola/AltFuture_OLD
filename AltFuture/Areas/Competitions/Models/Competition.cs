namespace AltFuture.Areas.Competitions.Models
{
    public class Competition
    {
        public int competition_key { get; set; } = 0;

        public string competition_title { get; set; } = "";

        public string competition_desc { get; set; } = "";

        public string payout_desc { get; set; } = "";

        public Boolean is_active { get; set; } = true;

        public DateTime? competition_start_date { get; set; }

        public DateTime? competition_end_date { get; set; }

        public LK_Competition_Type lk_competition_type { get; set; } = new LK_Competition_Type();

    }
}
