using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserDataApp.Models;
using UserDataApp.Models.InputModels;

namespace UserDataApp.Services.GameServices
{
    public interface IGameInfoService : IDisposable
    {
        Task<List<GameInfoViewModel>> GetUserGames(Guid userId);

        Task<GameInfo> Get(Guid id, string gameFromMongoId);

        Task<User> Add(GameInfoInputModel2 entity); //Guid id,

        // Task Update(Guid id, GameInfoInputModel gameEntity);
        // Task Delete(Guid id, string gameFromMongoId);

    }
}