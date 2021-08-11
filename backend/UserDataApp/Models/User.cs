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
            Games = new HashSet<GameInfo>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        [Column("First Name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Column("Last Name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Column("Email")]
        public string Email { get; set; }

        [Required]
        [Column("Password")]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [Column("Role")]
        public string Role { get; set; }

        public virtual ICollection<GameInfo> Games { get; set; }

    }
}
