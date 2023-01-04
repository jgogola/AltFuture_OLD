using AltFuture.Areas.Competitions.Models;

namespace AltFuture.Areas.Competitions.Services
{
    public interface ILKCompetitionTypeRepository : IDisposable
    {
        LK_Competition_Type LKCompetitionTypeGet(int lk_compitition_type_key);

        List<LK_Competition_Type> LKCompetitionTypeGetList();

     
    }
}
