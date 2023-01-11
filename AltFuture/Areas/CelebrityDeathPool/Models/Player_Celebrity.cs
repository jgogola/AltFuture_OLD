using AltFuture.Areas.Competitions.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace AltFuture.Areas.CelebrityDeathPool.Models
{
    public class Player_Celebrity
    {
        public int player_celebrity_key { get; set; } = 0;

        [Required]
        [Display(Name = "Competition")]
        public int competition_key { get; set; } = 0;

        [Required]
        [Display(Name = "Player")]
        public int competition_player_key { get; set; } = 0;

        [Required]
        [Display(Name = "Celebrity")]
        public int celebrity_key { get; set; } = 0;

        public bool is_winner { get; set; } = false;

        [ValidateNever]
        public Competition_Player competition_player { get; set; } = new Competition_Player();

        [ValidateNever]
        public Celebrity celebrity { get; set; } = new Celebrity();


    }
}
