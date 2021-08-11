using System;
using System.ComponentModel.DataAnnotations;

namespace UserDataApp.Models.InputModels
{
    public class GameInfoInputModel2
    {

        [Required]
        public Guid userId { get; set; }

        [Required]
        public string GameFromMongoId { get; set; }
    }
}