namespace AltFuture.Areas.Competitions.Models
{
    public class Celebrity
    {

        public int celebrity_key { get; set; } = 0;

        public string celebrity_name { get; set; } = "";

        public DateTime? birth_date { get; set; }

        public DateTime? death_date { get; set; }

        public Boolean is_dead { get; set; } = false;

        public int age { get; set; } = 0;

        public int points { get; set; } = 0;

        public LK_Celebrity_Type lk_celebrity_type { get; set; } = new LK_Celebrity_Type();
  

    }
}
