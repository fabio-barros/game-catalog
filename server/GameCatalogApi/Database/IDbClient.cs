using System.Collections.Generic;
using API.Models.ViewModel;
using MongoDB.Driver;

namespace GameCatalogApi.Services
{
    public interface IDbClient
    {
        IMongoCollection<GameModel> GetGamesCollection();
    }
}