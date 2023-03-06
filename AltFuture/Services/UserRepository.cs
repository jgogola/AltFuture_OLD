using AltFuture.Models;
using System.ComponentModel.DataAnnotations;

namespace AltFuture.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly SQLService _db;
        public UserRepository(ISQLService sqlService)
        {
            _db = (SQLService)sqlService;
        }

       
        public User UserGet(int user_key)
        {
            DataTable dt = _db.GetDT("usp_User_Get", new List<Object> { user_key });

            if(dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                LK_User_Role lk_user_role = new LK_User_Role
                {
                    lk_user_role_key = (int)dr["lk_user_role_key"],
                    user_role = (string)dr["user_role"]
                };

                User user = new User
                {
                    user_key = (int)dr["user_key"],
                    user_name = (string)dr["user_name"] ?? "",
                    password = (string)dr["password"] ?? "",
                    email = (string)dr["email"] ?? "",
                    first_name = (string)dr["first_name"] ?? "",
                    last_name = (string)dr["last_name"] ?? "",
                    full_name = (string)dr["full_name"] ?? "",
                    nick_name = (string)dr["nick_name"] ?? "",
                    is_active_user = (Boolean)dr["is_active_user"],
                    created_date = Convert.IsDBNull(dr["created_date"]) ? null : (DateTime)dr["created_date"],
                    last_login_date = Convert.IsDBNull(dr["last_login_date"]) ? null : (DateTime)dr["last_login_date"],
                    lk_user_role = lk_user_role
                };

                return user;
            }

            return new User();
        }

        public User? UserGetByCredentials(string user_name, string password)
        {
            DataTable dt = _db.GetDT("usp_User_Get_By_Credentials", new List<Object> { user_name, password });

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                LK_User_Role lk_user_role = new LK_User_Role
                {
                    lk_user_role_key = (int)dr["lk_user_role_key"],
                    user_role = (string)dr["user_role"]
                };

                User user = new User
                {
                    user_key = (int)dr["user_key"],
                    user_name = (string)dr["user_name"] ?? "",
                    password = (string)dr["password"] ?? "",
                    email = (string)dr["email"] ?? "",
                    first_name = (string)dr["first_name"] ?? "",
                    last_name = (string)dr["last_name"] ?? "",
                    full_name = (string)dr["full_name"] ?? "",
                    nick_name = (string)dr["nick_name"] ?? "",
                    is_active_user = (Boolean)dr["is_active_user"],
                    created_date = Convert.IsDBNull(dr["created_date"]) ? null : (DateTime)dr["created_date"],
                    last_login_date = Convert.IsDBNull(dr["last_login_date"]) ? null : (DateTime)dr["last_login_date"],
                    lk_user_role = lk_user_role
                };

                return user;
            }

            return null;
        }

        public List<User> UserGetList(int is_active = -1)
        {
            DataTable dt = _db.GetDT("usp_User_Get_List", new List<Object>() { is_active });
            List<User> users = new List<User>();

            foreach (DataRow dr in dt.Rows)
            {

                LK_User_Role lk_user_role = new LK_User_Role
                {
                    lk_user_role_key = (int)dr["lk_user_role_key"],
                    user_role = (string)dr["user_role"]
                };

                User user = new User
                {
                    user_key = (int)dr["user_key"],
                    user_name = (string)dr["user_name"] ?? "",
                    password = (string)dr["password"] ?? "",
                    email = (string)dr["email"] ?? "",
                    first_name = (string)dr["first_name"] ?? "",
                    last_name = (string)dr["last_name"] ?? "",
                    full_name = (string)dr["full_name"] ?? "",
                    nick_name = (string)dr["nick_name"] ?? "",
                    is_active_user = (Boolean)dr["is_active_user"],
                    created_date = Convert.IsDBNull(dr["created_date"]) ? null : (DateTime)dr["created_date"],
                    last_login_date = Convert.IsDBNull(dr["last_login_date"]) ? null : (DateTime)dr["last_login_date"],
                    lk_user_role = lk_user_role
                };

                users.Add(user);
            }

            return users;
        }

        public List<User> UserGetListByUserName(string user_name)
        {
            DataTable dt = _db.GetDT("usp_User_Get_List_ByUserName", new List<Object>() { user_name });
            List<User> users = new List<User>();

            foreach (DataRow dr in dt.Rows)
            {
                LK_User_Role lk_user_role = new LK_User_Role
                {
                    lk_user_role_key = (int)dr["lk_user_role_key"],
                    user_role = (string)dr["user_role"]
                };

                User user = new User
                {
                    user_key = (int)dr["user_key"],
                    user_name = (string)dr["user_name"] ?? "",
                    password = (string)dr["password"] ?? "",
                    email = (string)dr["email"] ?? "",
                    first_name = (string)dr["first_name"] ?? "",
                    last_name = (string)dr["last_name"] ?? "",
                    full_name = (string)dr["full_name"] ?? "",
                    nick_name = (string)dr["nick_name"] ?? "",
                    is_active_user = (Boolean)dr["is_active_user"],
                    created_date = Convert.IsDBNull(dr["created_date"]) ? null : (DateTime)dr["created_date"],
                    last_login_date = Convert.IsDBNull(dr["last_login_date"]) ? null : (DateTime)dr["last_login_date"],
                    lk_user_role = lk_user_role
                };

                users.Add(user);
            }

            return users;
        }

        public void Dispose()
        {
            System.GC.Collect();
            System.Diagnostics.Debug.WriteLine("Disposing!!");
        }
    }
}
