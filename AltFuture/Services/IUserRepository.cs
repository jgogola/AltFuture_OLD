using AltFuture.Models;


namespace AltFuture.Services
{
    public interface IUserRepository : IDisposable
    {
      
        User UserGet(int user_key);

        User? UserGetByCredentials(string user_name, string password);

        List<User> UserGetList(int is_active_user = -1);

        List<User> UserGetListByUserName(string user_name);

      

     

    }
}
