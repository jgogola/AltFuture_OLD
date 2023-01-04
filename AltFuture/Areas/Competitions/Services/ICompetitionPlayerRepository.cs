using AltFuture.Areas.Competitions.Models;

namespace AltFuture.Areas.Competitions.Services
{
    public interface ICompetitionPlayerRepository : IDisposable
    {
        Competition_Player CompetitionPlayerGet(int compitition_player_key);

        List<Competition_Player> CompetitionPlayerGetList(int competition_key = 0, int is_active_competition = -1, int user_key = 0);

     
    }
}
