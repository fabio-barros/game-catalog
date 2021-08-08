using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameDataApp.Mongo;
using Microsoft.EntityFrameworkCore;
using UserDataApp.Database;
using UserDataApp.Models;

namespace UserDataApp.Services.GameServices
{
    public class GameInfoService : IGameInfoService
    {
        private readonly UserAppDbContext _Context;

        public GameInfoService(UserAppDbContext context, IDbClient dbClient)
        {
            _Context = context;

        }

        public async Task<List<GameInfoViewModel>> GetUserGames(Guid userId)
        {

            System.Console.WriteLine(userId);
            var games = await _Context.GameInfo.Where(g => g.UserIdNavigation.Id.Equals(userId)).Include(g => g.UserIdNavigation).ToListAsync();

            /*Creating ViewModel List *Replaced by method using Select* */
            // var userGames = new List<GameInfoViewModel>();
            // foreach (var game in games)
            // {
            //     var userInfo = game.UserIdNavigation;
            //     userGames.Add(new GameInfoViewModel { Id = game.Id, GameFromMongoId = game.GameFromMongoId, User = new UserViewModel { Id = userInfo.Id, FirstName = userInfo.FirstName, LastName = userInfo.LastName, Email = userInfo.Email, Role = userInfo.Role } });
            // }

            return games.Select(game => new GameInfoViewModel
            {
                Id = game.Id,
                GameFromMongoId = game.GameFromMongoId,
                // User = new UserViewModel { Id = game.UserIdNavigation.Id, FirstName = game.UserIdNavigation.FirstName, LastName = game.UserIdNavigation.LastName, Email = game.UserIdNavigation.Email, Role = game.UserIdNavigation.Role }
            }).ToList();

        }

        public async Task<GameInfo> Get(Guid id, string gameFromMongoId)
        {
            return await _Context.GameInfo.FirstOrDefaultAsync(g => g.UserIdNavigation.Id.Equals(id) && g.GameFromMongoId.Equals(gameFromMongoId));
        }

        // public async Task<User> Add(UserInputModel userEntity)
        // {
        //     var entity = await _userContext.Users.AnyAsync(user => user.Email.Equals(userEntity.Email));

        //     if (entity)
        //     {
        //         throw new Exception("Email já cadastrado");
        //     }

        //     var newUser = new User { FirstName = userEntity.FirstName, LastName = userEntity.LastName, Email = userEntity.Email, Password = userEntity.Password, Role = userEntity.Role, Games = userEntity.Games };

        //     _userContext.Users.Add(newUser);

        //     await _userContext.SaveChangesAsync();

        //     return await _userContext.Users.FirstOrDefaultAsync(x => x.Email == userEntity.Email);
        // }

        // public async Task Update(Guid id, UserInputModel userEntity)
        // {
        //     var entity = await Get(id);//_userContext.Users.FindAsync(id); //_userContext.Users.Where(e => e.Id.Equals(id)).Include(e => e.Games).FirstOrDefaultAsync(); 
        //     if (entity == null)
        //     {
        //         throw new Exception("Employee does not exist");
        //     }

        //     var newUser = new User { FirstName = userEntity.FirstName, LastName = userEntity.LastName, Email = userEntity.Email, Password = userEntity.Password, Role = userEntity.Role, Games = userEntity.Games };
        //     _userContext.Entry(entity).CurrentValues.SetValues(userEntity);

        //     try
        //     {
        //         await _userContext.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         throw;
        //     }
        // }

        // public async Task Delete(Guid id)
        // {
        //     var entity = await _userContext.Users.FindAsync(id);

        //     if (entity == null)
        //     {
        //         throw new Exception("User Doesn't Exist");
        //     }

        //     _userContext.Remove(entity);
        //     await _userContext.SaveChangesAsync();

        // }

        public void Dispose()
        {
            _Context?.Dispose();
        }

    }
}