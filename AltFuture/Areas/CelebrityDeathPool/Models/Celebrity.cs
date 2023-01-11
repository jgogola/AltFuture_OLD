using AltFuture.CustomValidation;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AltFuture.Areas.CelebrityDeathPool.Models
{
    public class Celebrity
    {

        public int celebrity_key { get; set; } = 0;

        [Display(Name = "Celebrity Name")]
        [Required(ErrorMessage = "Celebrity Name is required.")]
        public string celebrity_name { get; set; } = "";

        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date)]
        public DateTime birth_date { get; set; }

        [Display(Name = "Date of Death")]
        [DataType(DataType.Date)]
        public DateTime? death_date { get; set; }

        [Display(Name = "Is Dead")]
        public bool is_dead { get; set; } = false;

        [Display(Name = "Age")]
        public int age { get; set; } = 0;

        [Display(Name = "Points")]
        public int points { get; set; } = 0;

        [CustomIsInitialValue("0", ErrorMessage = "A Celebrity Type must be selected from the list.")]
        [Display(Name = "Celebrity Type")]
        public int lk_celebrity_type_key { get; set; }

        [ValidateNever]
        public LK_Celebrity_Type lk_celebrity_type { get; set; } = new LK_Celebrity_Type();


    }
}
