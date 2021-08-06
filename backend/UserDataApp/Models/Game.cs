using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserDataApp.Models
{
    public class Game
    {

        [Required]
        public string GameId { get; set; }
        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual User UserIdNavigation { get; set; }

    }
}