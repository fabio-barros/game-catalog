using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameDataApp.Exceptions;
using GameDataApp.Models;
using GameDataApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GameCatalogApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameServices _gameServices;
        public GameController(IGameServices gameServices)
        {
            _gameServices = gameServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<GameModel>>> GetGames()
        {
            var games = await _gameServices.GetGames();
            Response.Headers.Add("Content-Range", $"games 0-5/{games.Count}");
            return Ok(games);
        }

        // [Authorize]
        [HttpGet("{gameId}", Name = "GetGame")]
        public async Task<ActionResult<GameModel>> GetGame([FromRoute] string gameId)
        {
            var res = await _gameServices.GetGame(gameId);

            if (res == null)
            {
                return NoContent();
            }
            return Ok(res);
        }


        // [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult<GameModel>> InsertGame([FromBody] GameInputModel gameInput)
        {

            if (gameInput is null)
                return BadRequest(new ArgumentNullException());

            try
            {
                var game = await _gameServices.AddGame(gameInput);
                return CreatedAtAction(nameof(GetGame), new { gameId = game.Id }, game);

            }
            catch (GameAlreadyExistException e)
            {

                return UnprocessableEntity(e.Message);
            }

        }

        // [Authorize(Roles = "admin")]
        [HttpPut("{gameId}")]
        public async Task<IActionResult> UpdateGame([FromRoute] string gameId, [FromBody] GameModel gameInput)
        {
            try
            {
                await _gameServices.UpdateGame(gameId, gameInput);
                return Ok();

            }
            //GameDoesNotExistException
            catch (GameDoesNotExistException e)
            {
                return NotFound(e.Message);
            }
        }

        // [Authorize(Roles = "admin")]
        [HttpDelete("{gameId}")]
        public async Task<IActionResult> DeleteGame([FromRoute] string gameId)
        {
            try
            {
                await _gameServices.DeleteGame(gameId);
                return NoContent();
            }
            catch (GameDoesNotExistException e)
            {
                return NotFound(e.Message);
            };
        }


    }
}

