namespace AltFuture.Areas.Competitions.Models
{
    public class Player_Celebrity_Roster
    {
        public int player_celebrity_roster_key { get; set; } = 0;
        public int competition_key { get; set; } = 0;
        public int competition_player_key { get; set; } = 0;
        public int celebrity_key { get; set; } = 0;
        public Boolean is_winner { get; set; } = false;

    }
}
