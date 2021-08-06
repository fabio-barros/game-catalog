using System.Collections.Generic;
using GameDataApp.Models;
using MongoDB.Driver;

namespace GameDataApp.Mongo
{
    public interface IDbClient
    {
        IMongoCollection<GameModel> GetGamesCollection();
    }
}