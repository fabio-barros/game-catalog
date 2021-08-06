using System;
using System.ComponentModel.DataAnnotations;

namespace GameDataApp.Models
{
    public class GameInputModel
    {
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Title length must be at least 2 and up to a maximum of 50 characters long.")]
        public string Title { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Developer length must be at least 2 and up to a maximum of 15 characters long.")]
        public string Developer { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Publisher length must be at least 2 and up to a maximum of 15 characters long.")]
        public string Publisher { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Url]
        public string CoverArtUrl { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "Price must be at least 1,00")]
        public decimal Price { get; set; }
    }
}