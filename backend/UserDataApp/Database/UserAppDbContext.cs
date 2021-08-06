using Microsoft.EntityFrameworkCore;

namespace UserDataApp.Database
{
    public class UserAppDbContext : DbContext
    {
        public UserAppDbContext(DbContextOptions<UserAppDbContext> options)
          : base(options)
        {
        }

    }
}