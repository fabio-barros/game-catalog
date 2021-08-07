using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameDataApp.Models;
using GameDataApp.Mongo;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using UserDataApp.Database;
using UserDataApp.Models;

namespace UserDataApp.Services
{
    public class UserService : IUserService
    {
        private readonly UserAppDbContext _userContext;
        private readonly IMongoCollection<GameModel> _mongoGamesContext;

        public UserService(UserAppDbContext context, IDbClient dbClient)
        {
            _userContext = context;
            _mongoGamesContext = dbClient.GetGamesCollection();

        }

        public async Task<List<User>> GetAll()
        {

            return await _userContext.Users.ToListAsync();
        }

        public async Task<User> Get(Guid id)
        {
            return await _userContext.Users.FirstOrDefaultAsync(user => user.Id.Equals(id));
        }

        public async Task<User> Add(User userEntity)
        {
            var entity = await _userContext.Users.AnyAsync(user => user.Email.Equals(userEntity.Email));

            if (entity)
            {
                throw new Exception("Email já cadastrado");
            }

            _userContext.Users.Add(userEntity);

            await _userContext.SaveChangesAsync();

            return await _userContext.Users.FirstOrDefaultAsync(x => x.Email == userEntity.Email);
        }

        public async Task Update(Guid id, User userEntity)
        {
            var entity = await _userContext.Users.FindAsync(id);
            if (entity == null)
            {
                throw new Exception("Employee does not exist");
            }

            var userEntityUpdate = new User { FirstName = userEntity.FirstName, LastName = userEntity.LastName, Email = userEntity.Email, Password = userEntity.Password, Role = userEntity.Role, Games = userEntity.Games };

            _userContext.Entry(entity).CurrentValues.SetValues(userEntityUpdate);

            try
            {
                await _userContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task Delete(Guid id)
        {
            var entity = await _userContext.Users.FindAsync(id);

            if (entity == null)
            {
                throw new Exception("User Doesn't Exist");
            }

            _userContext.Remove(entity);
            await _userContext.SaveChangesAsync();

        }
    }
}
