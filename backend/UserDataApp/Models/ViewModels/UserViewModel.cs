using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserDataApp.Models
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            Games = new HashSet<GameInfoViewModel>();
        }

        public Guid Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Email { get; set; }
        public string Role { get; set; }

        public virtual ICollection<GameInfoViewModel> Games { get; set; }

    }
}