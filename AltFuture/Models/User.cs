using System.Security.Cryptography.X509Certificates;

namespace AltFuture.Models
{
    public class User
    {
        public int user_key { get; set; } = 0;

        public string user_name { get; set; } = "";

        public string password { get; set; } = "";

        public string email { get; set; } = "";

        public string first_name { get; set; } = "";

        public string last_name { get; set; } = "";

        public string full_name { get; set; } = "";

        public string nick_name { get; set; } = "";

        public Boolean is_active_user { get; set; } = true;

        public DateTime? created_date { get; set; }

        public DateTime? last_login_date { get; set; }     

        public LK_User_Role lk_user_role { get; set; } = new LK_User_Role();



    }
}
