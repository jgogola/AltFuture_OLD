using AltFuture.Areas.Competitions.Models;
using AltFuture.Areas.CelebrityDeathPool.Models;
using System.ComponentModel.DataAnnotations;

namespace AltFuture.Areas.CelebrityDeathPool.Services
{
    public class PlayerCelebrityRepository : IPlayerCelebrityRepository
    {
        private readonly SQLService _db;
        public PlayerCelebrityRepository(ISQLService sqlService)
        {
            _db = (SQLService)sqlService;
        }

        public Player_Celebrity PlayerCelebrityGet(int player_celebrity_key)
        {
            DataTable dt = _db.GetDT("cdp.usp_Player_Celebrity_Get", new List<object> { player_celebrity_key });

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                LK_Celebrity_Type lk_celebrity_type = new LK_Celebrity_Type
                {
                    lk_celebrity_type_key = (int)dr["lk_celebrity_type_key"],
                    celebrity_type = (string)dr["celebrity_type"]
                };

                Celebrity celebrity = new Celebrity
                {
                    celebrity_key = (int)dr["celebrity_key"],
                    celebrity_name = (string)dr["celebrity_name"],
                    birth_date = (DateTime)dr["birth_date"],
                    death_date = Convert.IsDBNull(dr["death_date"]) ? null : (DateTime?)dr["death_date"],
                    is_dead = (bool)dr["is_dead"],
                    age = (int)dr["age"],
                    points = (int)dr["points"],
                    lk_celebrity_type_key = (int)dr["lk_celebrity_type_key"],

                    lk_celebrity_type = lk_celebrity_type

                };


                User user = new User
                {
                    user_key = (int)dr["user_key"],
                    full_name = (string)dr["full_name"],
                    nick_name = (string)dr["nick_name"],
                    is_active_user = (Boolean)dr["is_active_user"]
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
                    is_active_competition = (Boolean)dr["is_active_competition"],
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

                Player_Celebrity player_celebrity = new Player_Celebrity
                {
                    player_celebrity_key = (int)dr[""],
                    competition_key = (int)dr["lk_competition_type_key"],
                    competition_player_key = (int)dr["competition_player_key"],
                    celebrity_key = (int)dr["celebrity_key"],
                    is_winner = (Boolean)dr["is_winner"],
                    competition_player = competition_player,
                    celebrity = celebrity

                };

                return player_celebrity;
            }

            return new Player_Celebrity();
        }

        public List<Player_Celebrity> PlayerCelebrityGetListByPlayer(int competition_key, int user_key)
        {
            DataTable dt = _db.GetDT("cdp.usp_Player_Celebrity_Get_List", new List<object> { competition_key, user_key });
            List<Player_Celebrity> player_celebrities = new List<Player_Celebrity>();

            foreach (DataRow dr in dt.Rows)
            {


                LK_Celebrity_Type lk_celebrity_type = new LK_Celebrity_Type
                {
                    lk_celebrity_type_key = (int)dr["lk_celebrity_type_key"],
                    celebrity_type = (string)dr["celebrity_type"]
                };

                Celebrity celebrity = new Celebrity
                {
                    celebrity_key = (int)dr["celebrity_key"],
                    celebrity_name = (string)dr["celebrity_name"],
                    birth_date = (DateTime)dr["birth_date"],
                    death_date = Convert.IsDBNull(dr["death_date"]) ? null : (DateTime?)dr["death_date"],
                    is_dead = (bool)dr["is_dead"],
                    age = (int)dr["age"],
                    points = (int)dr["points"],
                    lk_celebrity_type_key = (int)dr["lk_celebrity_type_key"],

                    lk_celebrity_type = lk_celebrity_type

                };


                User user = new User
                {
                    user_key = (int)dr["user_key"],
                    full_name = (string)dr["full_name"],
                    nick_name = (string)dr["nick_name"],
                    is_active_user = (Boolean)dr["is_active_user"]
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
                    is_active_competition = (Boolean)dr["is_active_competition"],
                    competition_start_date = (DateTime)dr["competition_start_date"],
                    competition_end_date = (DateTime)dr["competition_end_date"],
                    lk_competition_type = lk_competition_type

                };

                Competition_Player competition_player = new Competition_Player
                {
                    competition_player_key = (int)dr["competition_player_key"],
                    dues_collected = (Boolean)dr["dues_collected"],
                    last_viewed_date = Convert.IsDBNull(dr["last_viewed_date"]) ? null : (DateTime?)dr["last_viewed_date"],
                    user = user,
                    competition = competition
                };

                Player_Celebrity player_celebrity = new Player_Celebrity
                {
                    player_celebrity_key = (int)dr["player_celebrity_key"],
                    competition_key = (int)dr["lk_competition_type_key"],
                    competition_player_key = (int)dr["competition_player_key"],
                    celebrity_key = (int)dr["celebrity_key"],
                    is_winner = (Boolean)dr["is_winner"],
                    competition_player = competition_player,
                    celebrity = celebrity

                };

                player_celebrities.Add(player_celebrity);
            }

            return player_celebrities;
        }

        public List<Player_Celebrity> PlayerCelebrityGetListByCompetition(int competition_key)
        {
            DataTable dt = _db.GetDT("cdp.usp_Player_Celebrity_Get_List", new List<object> { competition_key, 0 });
            List<Player_Celebrity> player_celebrities = new List<Player_Celebrity>();

            foreach (DataRow dr in dt.Rows)
            {


                LK_Celebrity_Type lk_celebrity_type = new LK_Celebrity_Type
                {
                    lk_celebrity_type_key = (int)dr["lk_celebrity_type_key"],
                    celebrity_type = (string)dr["celebrity_type"]
                };

                Celebrity celebrity = new Celebrity
                {
                    celebrity_key = (int)dr["celebrity_key"],
                    celebrity_name = (string)dr["celebrity_name"],
                    birth_date = (DateTime)dr["birth_date"],
                    death_date = Convert.IsDBNull(dr["death_date"]) ? null : (DateTime?)dr["death_date"],
                    is_dead = (bool)dr["is_dead"],
                    age = (int)dr["age"],
                    points = (int)dr["points"],
                    lk_celebrity_type_key = (int)dr["lk_celebrity_type_key"],

                    lk_celebrity_type = lk_celebrity_type

                };


                User user = new User
                {
                    user_key = (int)dr["user_key"],
                    full_name = (string)dr["full_name"],
                    nick_name = (string)dr["nick_name"],
                    is_active_user = (Boolean)dr["is_active_user"]
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
                    is_active_competition = (Boolean)dr["is_active_competition"],
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

                Player_Celebrity player_celebrity = new Player_Celebrity
                {
                    player_celebrity_key = (int)dr[""],
                    competition_key = (int)dr["lk_competition_type_key"],
                    competition_player_key = (int)dr["competition_player_key"],
                    celebrity_key = (int)dr["celebrity_key"],
                    is_winner = (Boolean)dr["is_winner"],
                    competition_player = competition_player,
                    celebrity = celebrity

                };

                player_celebrities.Add(player_celebrity);
            }

            return player_celebrities;
        }


        public int PlayerCelebrityAdd(Player_Celebrity player_celebrity)
        {
            return _db.GetRetVal("cdp.usp_Player_Celebrity_Add",
                                    new() {
                                        player_celebrity.competition_key,
                                        player_celebrity.competition_player_key,
                                        player_celebrity.celebrity_key,
                                        player_celebrity.is_winner 
                                    }
                                );
        }

        public int PlayerCelebrityUpd(int player_celebrity_key, Boolean is_winner)
        {
            return _db.GetRetVal("cdp.usp_Player_Celebrity_Upd",
                                    new() {
                                        player_celebrity_key,
                                        is_winner
                                    }
                                );
        }

        public int PlayerCelebrityDel(int player_celebrity_key)
        {
            return _db.GetRetVal("cdp.usp_Player_Celebrity_Del",
                                    new() {
                                        player_celebrity_key
                                    }
                                );
        }

        public void Dispose()
        {
            GC.Collect();
            System.Diagnostics.Debug.WriteLine("Disposing!!");
        }
    }
}
