using AltFuture.Areas.CelebrityDeathPool.Models;
using System.ComponentModel.DataAnnotations;

namespace AltFuture.Areas.CelebrityDeathPool.Services
{
    public class LKCelebrityTypeRepository : ILKCelebrityTypeRepository
    {
        private readonly SQLService _db;
        public LKCelebrityTypeRepository(ISQLService sqlService)
        {
            _db = (SQLService)sqlService;
        }

        public LK_Celebrity_Type LKCelebrityTypeGet(int lk_celebrity_type_key)
        {
            DataTable dt = _db.GetDT("cdp.usp_LK_Celebrity_Type_Get", new() { lk_celebrity_type_key });

            return new LK_Celebrity_Type
            {
                lk_celebrity_type_key = (int)dt.Rows[0]["lk_celebrity_type_key"],
                celebrity_type = (string)dt.Rows[0]["celebrity_type"]
            };

        }

        public List<LK_Celebrity_Type> LKCelebrityTypeGetList()
        {
            DataTable dt = _db.GetDT("cdp.usp_LK_Celebrity_Type_Get_List");
            List<LK_Celebrity_Type> lk_celebrity_types = new List<LK_Celebrity_Type>();

            foreach (DataRow dr in dt.Rows)
            {
                LK_Celebrity_Type lk_celebrity_type = new LK_Celebrity_Type
                {
                    lk_celebrity_type_key = (int)dr["lk_celebrity_type_key"],
                    celebrity_type = (string)dr["celebrity_type"]
                };

                lk_celebrity_types.Add(lk_celebrity_type);
            }

            return lk_celebrity_types;
        }

        public int LKCelebrityTypeAdd(LK_Celebrity_Type lk_celebry_type)
        {
            return _db.GetRetVal("cdp.usp_lk_Celebrity_Type_Add", new() { lk_celebry_type.celebrity_type });
        }

        public void LKCelebrityTypeUpd(LK_Celebrity_Type lk_celebry_type)
        {
            _db.GetRetVal("cdp.usp_lk_Celebrity_Type_Upd", new() { lk_celebry_type.lk_celebrity_type_key, lk_celebry_type.celebrity_type });
        }

        public int LKCelebrityTypeDel(int lk_celebry_type_key)
        {
            return _db.GetRetVal("cdp.usp_lk_Celebrity_Type_Del", new() { lk_celebry_type_key });
        }

        public void Dispose()
        {
            GC.Collect();
            System.Diagnostics.Debug.WriteLine("Disposing!!");
        }
    }
}
