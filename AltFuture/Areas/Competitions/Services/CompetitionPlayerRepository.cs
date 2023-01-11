using AltFuture.Areas.Competitions.Models;
using AltFuture.Areas.Competitions.Services;
using System.ComponentModel.DataAnnotations;

namespace AltFuture.Services
{
    public class CompetitionPlayerRepository : ICompetitionPlayerRepository
    {
        private readonly SQLService _db;
        public CompetitionPlayerRepository(ISQLService sqlService)
        {
            _db = (SQLService)sqlService;
        }

        public Competition_Player CompetitionPlayerGet(int competition_player_key)
        {
            DataTable dt = _db.GetDT("comp.usp_Competition_Player_Get", new List<Object> { competition_player_key });

            if(dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
               
                User user = new User
                {
                    user_key = (int)dr["user_key"],
                    full_name = (string)dr["full_name"],
                    nick_name = (string)dr["nick_name"],
                    is_active = (Boolean)dr["is_active_user"]
                };

                LK_Competition_Type lk_competition_type = new LK_Competition_Type
                {
                    lk_competition_type_key = (int)dr["lk_competition_type_key"],
                    competition_type = (string)dr["competition_type"]
                };

                Competition competition = new Competition
                {
                    competition_key = (int)dr["lk_competition_type_key"],
                    competition_title = (string)dr["competition_title"],
                    competition_desc = (string)dr["competition_desc"],
                    payout_desc = (string)dr["payout_desc"],
                    is_active = (Boolean)dr["is_active"],
                    competition_start_date = (DateTime)dr["competition_start_date"],
                    competition_end_date = (DateTime)dr["competition_end_date"],
                    lk_competition_type = lk_competition_type
                    
                };

                Competition_Player competition_player = new Competition_Player
                {
                    competition_player_key = (int)dr["competition_player_key"],
                    dues_collected = (Boolean)dr["dues_collected"],
                    last_viewed_date = (DateTime)dr["last_viewed_date"],
                    user = user,
                    competition = competition
                };

                return competition_player;
            }

            return new Competition_Player();
        }

        public List<Competition_Player> CompetitionPlayerGetList(int competition_key  = 0, int is_active_competition = -1, int user_key = 0)
        {
            DataTable dt = _db.GetDT("comp.usp_Competition_Player_Get_List", new List<Object> { competition_key, is_active_competition, user_key });
            List<Competition_Player> competition_players = new List<Competition_Player>();

            foreach (DataRow dr in dt.Rows)
            {

                User user = new User
                {
                    user_key = (int)dr["user_key"],
                    full_name = (string)dr["full_name"],
                    nick_name = (string)dr["nick_name"],
                    is_active = (Boolean)dr["is_active_user"]
                };

                LK_Competition_Type lk_competition_type = new LK_Competition_Type
                {
                    lk_competition_type_key = (int)dr["lk_competition_type_key"],
                    competition_type = (string)dr["competition_type"]
                };

                Competition competition = new Competition
                {
                    competition_key = (int)dr["competition_key"],
                    competition_title = (string)dr["competition_title"],
                    competition_desc = (string)dr["competition_desc"],
                    payout_desc = (string)dr["payout_desc"],
                    is_active = (Boolean)dr["is_active_competition"],
                    competition_start_date = (DateTime)dr["competition_start_date"],
                    competition_end_date = (DateTime)dr["competition_end_date"],
                    lk_competition_type = lk_competition_type

                };

                Competition_Player competition_player = new Competition_Player
                {
                    competition_player_key = (int)dr["competition_player_key"],
                    dues_collected = (Boolean)dr["dues_collected"],
                    last_viewed_date = Convert.IsDBNull(dr["last_viewed_date"]) ? null : (DateTime)dr["last_viewed_date"],
                    user = user,
                    competition = competition
                };

                competition_players.Add(competition_player);
            }

            return competition_players;
        }

        public void Dispose()
        {
            System.GC.Collect();
            System.Diagnostics.Debug.WriteLine("Disposing!!");
        }
    }
}
