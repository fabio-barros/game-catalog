using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models.ViewModel;
using GameCatalogApi.Exceptions;
using GameCatalogApi.Models;
using MongoDB.Driver;

namespace GameCatalogApi.Services
{
    public class GameServices : IGameServices
    {
        private readonly IMongoCollection<GameModel> _games;
        public GameServices(IDbClient dbClient)
        {
            _games = dbClient.GetGamesCollection();

        }

        public async Task<List<GameModel>> GetGames()
        {
            return await _games.Find(game => true).ToListAsync();
        }

        public async Task<GameModel> GetGame(string gameId)
        {
            var gamefromDb = await _games.Find(game => game.Id == gameId).FirstOrDefaultAsync();

            if (gamefromDb == null)
            {
                return null;
            }

            return gamefromDb;

        }
        public async Task<GameModel> GetGameByModel(GameModel gameModel)
        {
            var gamefromDb = await _games.Find(game => game.Title == gameModel.Title && game.Publisher == gameModel.Publisher && game.ReleaseDate == gameModel.ReleaseDate).FirstOrDefaultAsync();

            if (gamefromDb == null)
            {
                throw new GameDoesNotExistException();
            }

            return gamefromDb;

        }


        public async Task<GameModel> AddGame(GameInputModel gameInput)
        {
            var gamefromDb = await _games.Find(game => game.Title == gameInput.Title && game.Publisher == gameInput.Publisher && game.ReleaseDate == gameInput.ReleaseDate).AnyAsync();

            if (gamefromDb)
            {
                throw new GameAlreadyExistException();
            }

            var newInsert = new GameModel
            {
                Title = gameInput.Title,
                Developer = gameInput.Developer,
                Publisher = gameInput.Publisher,
                ReleaseDate = gameInput.ReleaseDate,
                CoverArtUrl = gameInput.CoverArtUrl,
                Price = gameInput.Price

            };

            await _games.InsertOneAsync(newInsert);

            return await GetGameByModel(newInsert);

        }

        public async Task UpdateGame(string gameId, GameModel gameInput)
        {
            var gameFromDb = GetGame(gameId); //await _games.Find(game => game.Id == gameId).FirstAsync()

            await _games.ReplaceOneAsync(game => game.Id == gameId, gameInput);
        }

        public async Task DeleteGame(string gameId)
        {
            var gamefromDB = GetGame(gameId);//await _games.Find(game => game.Id == gameId).FirstAsync()

            await _games.DeleteOneAsync(game => game.Id == gameId);

        }



    }
}