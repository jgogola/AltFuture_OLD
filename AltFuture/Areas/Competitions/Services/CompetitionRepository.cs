using AltFuture.Areas.Competitions.Models;
using AltFuture.Areas.Competitions.Services;
using System.ComponentModel.DataAnnotations;

namespace AltFuture.Services
{
    public class CompetitionRepository : ICompetitionRepository
    {
        private readonly SQLService _db;
        public CompetitionRepository(ISQLService sqlService)
        {
            _db = (SQLService)sqlService;
        }

        public Competition CompetitionGet(int competition_key)
        {
            DataTable dt = _db.GetDT("comp.usp_Competition_Get", new List<Object> { competition_key });

            if(dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                LK_Competition_Type lk_competition_type = new LK_Competition_Type
                {
                    lk_competition_type_key = (int)dr["lk_competition_type_key"],
                    competition_type = (string)dr["competition_type"]
                };

                Competition competition = new Competition
                {
                    competition_key = (int)dr["lk_copmetition_type_key"],
                    competition_title = (string)dr["competition_title"],
                    competition_desc = (string)dr["competition_desc"],
                    payout_desc = (string)dr["payout_desc"],
                    is_active = (Boolean)dr["is_active"],
                    competition_start_date = (DateTime)dr["competition_start_date"],
                    competition_end_date = (DateTime)dr["competition_end_date"],
                    lk_competition_type = lk_competition_type
                    
                };           

                return competition;
            }

            return new Competition();
        }

        public List<Competition> CompetitionGetList(int is_active = -1, int user_key = 0)
        {
            DataTable dt = _db.GetDT("comp.usp_Competition_Get_List", new List<Object> {is_active, user_key });
            List<Competition> competitions = new List<Competition>();

            foreach (DataRow dr in dt.Rows)
            {

                LK_Competition_Type lk_competition_type = new LK_Competition_Type
                {
                    lk_competition_type_key = (int)dr["lk_competition_type_key"],
                    competition_type = (string)dr["competition_type"]
                };

                Competition competition = new Competition
                {
                    competition_key = (int)dr["lk_copmetition_type_key"],
                    competition_title = (string)dr["competition_title"],
                    competition_desc = (string)dr["competition_desc"],
                    payout_desc = (string)dr["payout_desc"],
                    is_active = (Boolean)dr["is_active"],
                    competition_start_date = (DateTime)dr["competition_start_date"],
                    competition_end_date = (DateTime)dr["competition_end_date"],
                    lk_competition_type = lk_competition_type

                };

                competitions.Add(competition);
            }

            return competitions;
        }

        public void Dispose()
        {
            System.GC.Collect();
            System.Diagnostics.Debug.WriteLine("Disposing!!");
        }
    }
}
