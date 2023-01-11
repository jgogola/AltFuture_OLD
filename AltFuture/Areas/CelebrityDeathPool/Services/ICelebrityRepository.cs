using AltFuture.Areas.CelebrityDeathPool.Models;

namespace AltFuture.Areas.CelebrityDeathPool.Services
{
    public interface ICelebrityRepository : IDisposable
    {
        Celebrity CelebrityGet(int celebrity_key);
        List<Celebrity> CelebrityGetList(string celebrity_name = "", int is_dead = -1);
        int CelebrityAdd(Celebrity celebrity);


    }
}
