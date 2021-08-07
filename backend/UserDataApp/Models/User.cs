using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserDataApp.Models
{
    public class User
    {
        public User()
        {
            Games = new HashSet<Game>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "First Name length must be at least 3 and up to a maximum of 10 characters long.")]
        [Column("First Name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Last Name length must be at least 3 and up to a maximum of 10 characters long.")]
        [Column("Last Name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Column("Email")]
        [RegularExpression(@"^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Email Format")]
        public string Email { get; set; }

        [Required]
        [Column("Password")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Last Name length must be at least 3 and up to a maximum of 10 characters long.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Column("Role")]
        public string Role { get; set; }

        public virtual ICollection<Game> Games { get; set; }



    }
}