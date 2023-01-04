using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace PA_Indicator14.Models.Extensions
{
    public static class EnumExtensions
    {
        public static string GetFormStatusDisplayName(this Form_Statuses enumValue)
        {
            return GetDisplayName(enumValue);
        }

        public static string GetUserRoleDisplayName(this User_Roles enumValue)
        {
            return GetDisplayName(enumValue);
        }

        public static string GetStateDisplayName(this States enumValue)
        {
            return GetDisplayName(enumValue);
        }

        private static string GetDisplayName(Enum enumType)
        {
            return enumType.GetType().GetMember(enumType.ToString()).First().Name.Replace("_", " ");
        }

        public static string GetDisplayNameAttribute(this Enum enumValue)
        {
            return enumValue.GetType()?
                            .GetMember(enumValue.ToString()).First()?
                            .GetCustomAttribute<DisplayAttribute>()?
                            .Name!;
        }
    }
}
