namespace AltFuture.Areas.Competitions.Models
{
    public class Competition_Player
    {

        public int competition_player_key { get; set; } = 0;

        public Boolean dues_collected { get; set; } = false;

        public DateTime? last_viewed_date { get; set; }

        public Competition competition { get; set; } = new Competition();

        public User user { get; set; } = new User();
   

    }
}
