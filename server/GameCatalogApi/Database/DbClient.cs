using API.Models.ViewModel;
using GameCatalogApi.Database;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
namespace GameCatalogApi.Services
{
    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<GameModel> _games;
        public DbClient(IOptions<GameCatalogDbConfig> gameCatalogDbConfig)
        {
            var client = new MongoClient(gameCatalogDbConfig.Value.Connection_String);
            var database = client.GetDatabase(gameCatalogDbConfig.Value.Database_Name);
            _games = database.GetCollection<GameModel>(gameCatalogDbConfig.Value.Games_Collection_Name);

        }
        public IMongoCollection<GameModel> GetGamesCollection()
        {
            return _games;
        }

    }
}