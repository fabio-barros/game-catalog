using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserDataApp.Models
{
    public class User
    {
        public User()
        {
            Games = new HashSet<Game>();
        }
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "First Name length must be at least 3 and up to a maximum of 10 characters long.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Last Name length must be at least 3 and up to a maximum of 10 characters long.")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }


        public virtual ICollection<Game> Games { get; set; }



    }
}