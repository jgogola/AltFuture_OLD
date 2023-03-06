using AltFuture.Areas.Competitions.Models;

namespace AltFuture.Areas.Competitions.Services
{
    public interface ICompetitionRepository : IDisposable
    {
        Competition CompetitionGet(int compitition_key);

        List<Competition> CompetitionGetList(int is_active_competition = -1, int user_key = 0);

     
    }
}
