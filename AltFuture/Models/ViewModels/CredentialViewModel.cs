using System.ComponentModel.DataAnnotations;

namespace AltFuture.Models.ViewModels
{
    public class CredentialViewModel
    {
        [Required]
        [Display(Name = "User Name")]
        public string user_name { get; set; } = "";

        [Required]
        [Display(Name = "Password")]
        public string password { get; set; } = "";
    }
}
