using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserDataApp.Models
{
    public class UserInputModel
    {
        public UserInputModel()
        {
            // Games = new HashSet<Game>();
        }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "First Name length must be at least 3 and up to a maximum of 10 characters long.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Last Name length must be at least 3 and up to a maximum of 10 characters long.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }
        public ICollection<Game> Games { get; set; }

    }
}