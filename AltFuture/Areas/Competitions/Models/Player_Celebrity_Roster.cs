using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace AltFuture.Areas.Competitions.Models
{
    public class Player_Celebrity_Roster
    {
        public int player_celebrity_roster_key { get; set; } = 0;

        [Required]
        [Display(Name ="Player")]
        public int competition_player_key { get; set; } = 0;

        [Required]
        [Display(Name ="Celebrity")]
        public int celebrity_key { get; set; } = 0;
        public Boolean is_winner { get; set; } = false;

        [ValidateNever]
        public Competition_Player competition_Player { get; set; } = new Competition_Player();

        [ValidateNever]
        public Celebrity celebrity { get; set; }   = new Celebrity();


    }
}
