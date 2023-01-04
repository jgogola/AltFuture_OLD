
using System.ComponentModel.DataAnnotations;

namespace AltFuture.Models
{
    public class LK_User_Role
    {
        public int lk_user_role_key { get; set; } = 0;

        public string user_role { get; set; } = "";

    }

    public enum User_Roles
    {
        [Display(Name = "Site Admin")]
        Site_Admin = 1,
        [Display(Name = "Competition Admin")]
        Competition_Admin = 2,
        [Display(Name = "Competition Player")]
        Competition_Player = 3,
        [Display(Name = "Crypto Admin")]
        Crypto_Admin = 4,
        [Display(Name = "Crypto View")]
        Crypto_View = 5
    };
}
