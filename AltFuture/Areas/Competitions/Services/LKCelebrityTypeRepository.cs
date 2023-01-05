using AltFuture.Areas.Competitions.Models;
using AltFuture.Areas.Competitions.Services;
using System.ComponentModel.DataAnnotations;

namespace AltFuture.Services
{
    public class LKCelebrityTypeRepository : ILKCelebrityTypeRepository
    {
        private readonly SQLService _db;
        public LKCelebrityTypeRepository(ISQLService sqlService)
        {
            _db = (SQLService)sqlService;
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

        public void Dispose()
        {
            System.GC.Collect();
            System.Diagnostics.Debug.WriteLine("Disposing!!");
        }
    }
}
