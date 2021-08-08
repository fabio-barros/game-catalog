using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameDataApp.Models;
using GameDataApp.Mongo;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using UserDataApp.Database;
using UserDataApp.Exceptions;
using UserDataApp.Models;

namespace UserDataApp.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly UserAppDbContext _Context;
        // private readonly IMongoCollection<GameModel> _mongoGamesContext;

        public UserService(UserAppDbContext context, IDbClient dbClient)
        {
            _Context = context;
            // _mongoGamesContext = dbClient.GetGamesCollection();

        }

        public async Task<List<UserViewModel>> GetAll(int page, int qty)
        {

            var users = await _Context.Users.Include(e => e.Games).Skip((page - 1) * qty).Take(qty).ToListAsync();

            return users.Select(user => new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role,
                Games = user.Games.Select(game => new GameInfoViewModel { Id = game.Id, GameFromMongoId = game.GameFromMongoId }).ToList()

            }).ToList();
        }

        public async Task<User> Get(Guid id)
        {
            return await _Context.Users.Include(e => e.Games).FirstOrDefaultAsync(user => user.Id.Equals(id));
        }

        public async Task<UserViewModel> Add(UserInputModel userEntity)
        {
            var userEntityFromDb = await _Context.Users.AnyAsync(user => user.Email.Equals(userEntity.Email));

            if (userEntityFromDb)
            {
                throw new UserAlredyExistException();
            }

            var newUser = new User { FirstName = userEntity.FirstName, LastName = userEntity.LastName, Email = userEntity.Email, Password = userEntity.Password, Role = userEntity.Role, Games = userEntity.Games };

            _Context.Users.Add(newUser);

            await _Context.SaveChangesAsync();

            var newUserFromDB = await _Context.Users.FirstOrDefaultAsync(x => x.Email == newUser.Email);

            return new UserViewModel
            {
                Id = newUserFromDB.Id,
                FirstName = newUserFromDB.FirstName,
                LastName = newUserFromDB.LastName,
                Email = newUserFromDB.Email,
                Role = newUserFromDB.Role,
                Games = newUserFromDB.Games.Select(game => new GameInfoViewModel { Id = game.Id, GameFromMongoId = game.GameFromMongoId }).ToList()
            };
        }

        public async Task Update(Guid id, UserInputModel userEntity)
        {
            var userEntityFromDb = await Get(id);//_Context.Users.FindAsync(id); //_Context.Users.Where(e => e.Id.Equals(id)).Include(e => e.Games).FirstOrDefaultAsync(); 
            if (userEntityFromDb == null)
            {
                throw new UserDoesNotExistException();
            }

            // var userEntityUpdate = new UserInputModel { FirstName = userEntity.FirstName, LastName = userEntity.LastName, Email = userEntity.Email, Password = userEntity.Password, Role = userEntity.Role, Games = userEntity.Games };
            // userEntity.Id = entity.Id;

            // userEntity.Games.Add(entity.Games.Where(g =>))

            // entity.Games.Add(userEntity.Games)

            // var updatedValues = new User
            // {
            //     FirstName = userEntity.FirstName,
            //     LastName = userEntity.LastName,
            //     Email = userEntity.Email,
            //     Password = userEntity.Password,
            //     Role = userEntity.Role
            // };

            // foreach (var game in userEntity.Games)
            // {
            //     if (!entity.Games.Contains(game))
            //         updatedValues.Games.Add(game);
            // }
            // foreach (var game in entity.Games)
            // {
            //     if (!userEntity.Games.Contains(game))
            //         userEntity.Games.Add(game);
            // }
            // // entity.Games.;
            // await _Context.SaveChangesAsync();


            // foreach (var game in userEntity.Games)
            // {
            //     if (!entity.Games.Contains(game))
            //         await _Context.Games.AddAsync(game);
            // }
            // foreach (var game in userEntity.Games)
            // {
            //     System.Console.WriteLine(game.GameFromMongoId);
            // }
            var newUser = new User { FirstName = userEntity.FirstName, LastName = userEntity.LastName, Email = userEntity.Email, Password = userEntity.Password, Role = userEntity.Role };
            _Context.Entry(userEntityFromDb).CurrentValues.SetValues(userEntity);

            try
            {
                await _Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task Delete(Guid id)
        {
            var entity = await _Context.Users.FindAsync(id);

            if (entity == null)
            {
                throw new Exception("User Doesn't Exist");
            }

            _Context.Remove(entity);
            await _Context.SaveChangesAsync();

        }

        public void Dispose()
        {
            _Context?.Dispose();
        }
    }
}
