using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UserDataApp.Models
{
    [Index(nameof(GameFromMongoId), IsUnique = true)]
    public class GameInfo
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("Game Id")]
        public string GameFromMongoId { get; set; }

        // // [Required]
        // // [ForeignKey("User")]
        // // [Column("User Id")]
        // [ForeignKey("Id")]

        public virtual User UserIdNavigation { get; set; }

    }
}