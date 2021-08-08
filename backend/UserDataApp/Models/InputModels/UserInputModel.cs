using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserDataApp.Models
{
    public class UserInputModel
    {
        public UserInputModel()
        {
            Games = new HashSet<GameInfo>();
        }

        [Required]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "First Name length must be at least 3 and up to a maximum of 10 characters long.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Last Name length must be at least 3 and up to a maximum of 10 characters long.")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression(@"^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Email Format")]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password length must be at least 8 characters long.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Role { get; set; }
        public ICollection<GameInfo> Games { get; set; }

    }
}