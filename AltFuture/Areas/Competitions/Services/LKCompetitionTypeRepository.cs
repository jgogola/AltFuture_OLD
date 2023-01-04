using AltFuture.Areas.Competitions.Models;
using AltFuture.Areas.Competitions.Services;
using System.ComponentModel.DataAnnotations;

namespace AltFuture.Services
{
    public class LKCompetitionTypeRepository : ILKCompetitionTypeRepository
    {
        private readonly SQLService _db;
        public LKCompetitionTypeRepository(ISQLService sqlService)
        {
            _db = (SQLService)sqlService;
        }

        public LK_Competition_Type LKCompetitionTypeGet(int lk_competition_type_key)
        {
            DataTable dt = _db.GetDT("comp.usp_LK_Competition_Type_Get", new List<Object> { lk_competition_type_key });

            if(dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                LK_Competition_Type lk_competition_type = new LK_Competition_Type
                {
                    lk_competition_type_key = (int)dr["lk_copmetition_type_key"],
                    competition_type = (string)dr["competition_type"]
                };           

                return lk_competition_type;
            }

            return new LK_Competition_Type();
        }

        public List<LK_Competition_Type> LKCompetitionTypeGetList()
        {
            DataTable dt = _db.GetDT("comp.usp_LK_Competition_Type_Get_List");
            List<LK_Competition_Type> lk_competition_types = new List<LK_Competition_Type>();

            foreach (DataRow dr in dt.Rows)
            {
                LK_Competition_Type lk_competition_type = new LK_Competition_Type
                {
                    lk_competition_type_key = (int)dr["lk_copmetition_type_key"],
                    competition_type = (string)dr["competition_type"]
                };

                lk_competition_types.Add(lk_competition_type);
            }

            return lk_competition_types;
        }

        public void Dispose()
        {
            System.GC.Collect();
            System.Diagnostics.Debug.WriteLine("Disposing!!");
        }
    }
}
