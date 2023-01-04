
using System.Security.Claims;

namespace AltFuture.Models.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static bool IsAuthenticated(this ClaimsPrincipal User)
        {
            return User.Identity.IsAuthenticated;
        }

        public static int UserKey(this ClaimsPrincipal User)
        {
            return (from u in User.Claims where u.Type == "UserKey" select Convert.ToInt32(u.Value)).FirstOrDefault();
        }

        public static string UserName(this ClaimsPrincipal User)
        {
            return User.Identity.Name;
        }

        public static string FirstName(this ClaimsPrincipal User)
        {
            return (from u in User.Claims where u.Type == "FirstName" select u.Value).FirstOrDefault();
        }

        public static string LastName(this ClaimsPrincipal User)
        {
            return (from u in User.Claims where u.Type == "LastName" select u.Value).FirstOrDefault();
        }

        public static string NickName(this ClaimsPrincipal User)
        {
            return (from u in User.Claims where u.Type == "NickName" select u.Value).FirstOrDefault();
        }


        public static string Email(this ClaimsPrincipal User)
        {
            return (from u in User.Claims where u.Type == ClaimTypes.Email select u.Value).FirstOrDefault();
        }


        public static User_Roles UserRole(this ClaimsPrincipal User)
        {
            return (from u in User.Claims where u.Type == ClaimTypes.Role select (User_Roles)Convert.ToInt32(u.Value)).FirstOrDefault();
        }

        public static string UserRoleName(this ClaimsPrincipal User)
        {
            return (from u in User.Claims where u.Type == ClaimTypes.Role select ((User_Roles)Convert.ToInt32(u.Value)).ToString().Replace("_", " ")).FirstOrDefault();
        }


    }
}

