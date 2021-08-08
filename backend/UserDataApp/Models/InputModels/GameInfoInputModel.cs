using System.ComponentModel.DataAnnotations;

namespace UserDataApp.Models.InputModels
{
    public class GameInfoInputModel
    {

        [Required]
        public string GameFromMongoId { get; set; }

        public virtual User UserIdNavigation { get; set; }

    }
}