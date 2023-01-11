using AltFuture.Areas.CelebrityDeathPool.Models;

namespace AltFuture.Areas.CelebrityDeathPool.Services
{
    public interface ILKCelebrityTypeRepository : IDisposable
    {

        LK_Celebrity_Type LKCelebrityTypeGet(int lk_celebrity_type_key);

        List<LK_Celebrity_Type> LKCelebrityTypeGetList();

        int LKCelebrityTypeAdd(LK_Celebrity_Type lk_celebry_type);

        void LKCelebrityTypeUpd(LK_Celebrity_Type lk_celebry_type);

        int LKCelebrityTypeDel(int lk_celebry_type_key);


    }
}
