using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserDataApp.Database;
using UserDataApp.Exceptions;
using UserDataApp.Models;

namespace UserDataApp.Services.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly UserAppDbContext _Context;
        public LoginService(UserAppDbContext context)
        {
            _Context = context;
        }

        public async Task<UserViewModel> Login(LoginInfo login)
        {
            var user = await _Context.Users.Include(e => e.Games).FirstOrDefaultAsync(user => user.Email.Equals(login.Email));
            if (user == null)
            {
                throw new UserDoesNotExistException();
            }
            else if (!user.Password.Equals(login.Password))
            {
                throw new WrongPasswordException();
            }

            return new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role,
                Games = user.Games.Select(game => new GameInfoViewModel { Id = game.Id, GameFromMongoId = game.GameFromMongoId }).ToList()
            };

        }

        public void Dispose()
        {
            _Context?.Dispose();
        }

    }
}