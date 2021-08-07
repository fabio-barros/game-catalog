using Microsoft.EntityFrameworkCore;
using UserDataApp.Models;

namespace UserDataApp.Database
{
    public class UserAppDbContext : DbContext
    {
        public UserAppDbContext(DbContextOptions<UserAppDbContext> options)
          : base(options)
        {
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Game> Games { get; set; }

    }
}