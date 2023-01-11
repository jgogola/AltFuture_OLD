using AltFuture.Areas.CelebrityDeathPool.Models;

namespace AltFuture.Areas.CelebrityDeathPool.Services
{
    public interface IPlayerCelebrityRepository : IDisposable
    {
        Player_Celebrity PlayerCelebrityGet(int player_celebrity_key);

        List<Player_Celebrity> PlayerCelebrityGetListByPlayer(int competition_key, int user_key);

        List<Player_Celebrity> PlayerCelebrityGetListByCompetition(int competition_key);

        int PlayerCelebrityAdd(Player_Celebrity player_celebrity);

        int PlayerCelebrityUpd(int player_celebrity_key, Boolean is_winner);

        int PlayerCelebrityDel(int player_celebrity_key);


    }
}
