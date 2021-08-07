using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserDataApp.Models
{
    public class Game
    {

        [Required]
        [Column("Game Id")]
        public string GameId { get; set; }

        // [Required]
        // [ForeignKey("User")]
        // [Column("User Id")]
        // public Guid UserRefId { get; set; }

        public virtual User User { get; set; }

    }
}