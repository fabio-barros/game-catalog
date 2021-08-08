using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UserDataApp.Models
{
    public class GameInfoViewModel
    {
        public int Id { get; set; }
        public string GameFromMongoId { get; set; }
        // public virtual UserViewModel User { get; set; }

    }
}