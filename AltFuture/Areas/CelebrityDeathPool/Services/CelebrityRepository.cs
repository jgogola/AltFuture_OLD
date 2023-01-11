using AltFuture.Areas.CelebrityDeathPool.Models;
using System.ComponentModel.DataAnnotations;

namespace AltFuture.Areas.CelebrityDeathPool.Services
{
    public class CelebrityRepository : ICelebrityRepository
    {
        private readonly SQLService _db;
        public CelebrityRepository(ISQLService sqlService)
        {
            _db = (SQLService)sqlService;
        }

        public Celebrity CelebrityGet(int celebrity_key)
        {
            DataTable dt = _db.GetDT("cdp.usp_Celebrity_Get", new List<object> { celebrity_key });

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

                return celebrity;
            }

            return new Celebrity();
        }

        public List<Celebrity> CelebrityGetList(string celebrity_name = "", int is_dead = -1)
        {
            DataTable dt = _db.GetDT("cdp.usp_Celebrity_Get_List", new List<object> { celebrity_name, is_dead });
            List<Celebrity> celebrities = new List<Celebrity>();

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

                celebrities.Add(celebrity);
            }

            return celebrities;
        }

        public int CelebrityAdd(Celebrity celebrity)
        {
            return _db.GetRetVal("cdp.usp_Celebrity_Add",
                                    new() {
                                        celebrity.celebrity_name,
                                        celebrity.lk_celebrity_type_key,
                                        celebrity.birth_date,
                                        celebrity.death_date ?? (object)DBNull.Value
                                    }
                                );
        }

        public int CelebrityUpd(Celebrity celebrity)
        {
            return _db.GetRetVal("cdp.usp_Celebrity_Upd",
                                    new() {
                                        celebrity.celebrity_key,
                                        celebrity.celebrity_name,
                                        celebrity.lk_celebrity_type_key,
                                        celebrity.birth_date,
                                        celebrity.death_date ?? (object)DBNull.Value
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
