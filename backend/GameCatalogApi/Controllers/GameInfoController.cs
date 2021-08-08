using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserDataApp.Models;
using UserDataApp.Models.InputModels;
using UserDataApp.Services;
using UserDataApp.Services.GameServices;

namespace GameCatalogApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GameInfoController : ControllerBase
    {
        private readonly IGameInfoService _gameService;

        public GameInfoController(IGameInfoService gameService)
        {
            _gameService = gameService;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetUserGames([FromQuery] Guid userId)
        {
            var userGames = await _gameService.GetUserGames(userId);

            if (userGames.Count == 0)
            {
                return NoContent();
            }

            return Ok(userGames);
        }

        [HttpGet("{userId:guid}", Name = "GetUserGame")]
        public async Task<ActionResult<User>> GetUserGame([FromRoute] Guid userId, [FromQuery] string gameFromMongoId)
        {
            var userGameFromDb = await _gameService.Get(userId, gameFromMongoId);

            if (userGameFromDb == null)
            {
                return NotFound();
            }

            return Ok(userGameFromDb);
        }

        // [HttpPost("{userId:guid}")]
        // public async Task<ActionResult<User>> AddUserGameInfo([FromRoute] Guid userId, [FromBody] GameInfoInputModel gameInfoInputModelEntity)
        // {

        //     if (gameInfoInputModelEntity is null)
        //         return BadRequest(new ArgumentNullException());

        //     try
        //     {
        //         var gameEntity = await _gameService.Add(gameInfoInputModelEntity);

        //         return Created(nameof(GetUserGame), gameEntity);

        //     }
        //     //UserAlreadyExistsException
        //     catch (Exception e)
        //     {
        //         return UnprocessableEntity(e.Message);
        //     }
        // }


        // [HttpPut("{userId:guid}")]
        // public async Task<IActionResult> UpdateUserGameInfo([FromRoute] Guid userId, [FromBody] GameInfoInputModel gameInfoInputModelEntity)
        // {
        //     try
        //     {
        //         await _gameService.Update(userId, gameInfoInputModelEntity);
        //         return NoContent();

        //     }
        //     //BookDoesNotExistException
        //     catch (Exception e)
        //     {
        //         return NotFound(e);
        //     }
        // }

        // [HttpPatch("{userId:guid}")]
        // public async Task<IActionResult> AddGames([FromRoute] Guid userId, [FromBody] Game userInputModelEntity)
        // {
        //     try
        //     {
        //         await _userService.Update(userId, userInputModelEntity);
        //         return NoContent();

        //     }
        //     //UserDoesNotExistException
        //     catch (Exception e)
        //     {
        //         return NotFound(e);
        //     }
        // }

        // DELETE: api/Book/5
        // [HttpDelete("{userId:guid}")]
        // public async Task<IActionResult> DeleteUserGameInfo([FromRoute] Guid id, [FromBody] string gameFromMongoId)
        // {
        //     try
        //     {
        //         await _gameService.Delete(id, gameFromMongoId);
        //         return NoContent();
        //     }

        //     //GameDoesNotExist
        //     catch (Exception e)
        //     {
        //         return NotFound(e);
        //     };

        // }

    }
}