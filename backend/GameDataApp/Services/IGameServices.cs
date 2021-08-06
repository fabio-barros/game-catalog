using System.Collections.Generic;
using System.Threading.Tasks;
using GameDataApp.Models;

namespace GameDataApp.Services
{
    public interface IGameServices
    {
        Task<List<GameModel>> GetGames();
        Task<GameModel> GetGame(string id);
        Task<GameModel> AddGame(GameInputModel gameInput);
        Task UpdateGame(string id, GameModel gameInput);
        // Task UpdatePrice(int id, decimal price);
        Task DeleteGame(string gameId);
    }
}