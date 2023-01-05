using AltFuture.Areas.Competitions.Models;

namespace AltFuture.Areas.Competitions.Services
{
    public interface ILKCelebrityTypeRepository : IDisposable
    {
        List<LK_Celebrity_Type> LKCelebrityTypeGetList();

     
    }
}
