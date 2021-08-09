using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserDataApp.Exceptions;
using UserDataApp.Models;
using UserDataApp.Services;
using UserDataApp.Services.UserServices;

namespace GameCatalogApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetUsers([FromQuery, Range(1, int.MaxValue)] int page = 1, [FromQuery, Range(1, 50)] int qty = 5)
        {
            var users = await _userService.GetAll(page, qty);

            if (users.Count == 0)
            {
                return NoContent();
            }

            return Ok(users);
        }

        [HttpGet("{userId:guid}", Name = "GetUser")]
        public async Task<ActionResult<User>> GetUser([FromRoute] Guid userId)
        {
            var userFromDb = await _userService.Get(userId);

            if (userFromDb == null)
            {
                return NotFound();
            }

            return Ok(userFromDb);
        }

        [HttpPost]
        public async Task<ActionResult<UserViewModel>> AddUser([FromBody] UserInputModel userInputModelEntity)
        {

            if (userInputModelEntity is null)
                return BadRequest(new ArgumentNullException());

            try
            {
                var userEntity = await _userService.Add(userInputModelEntity);

                return Created(nameof(GetUser), userEntity);

            }
            //UserAlreadyExistsException
            catch (UserAlredyExistException e)
            {
                return UnprocessableEntity(e.Message);
            }
        }


        [HttpPut("{userId:guid}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid userId, [FromBody] UserInputModel userInputModelEntity)
        {
            try
            {
                await _userService.Update(userId, userInputModelEntity);
                return NoContent();

            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }

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

        [HttpDelete("{userId:guid}")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            try
            {
                await _userService.Delete(userId);
                return NoContent();
            }

            //GameDoesNotExist
            catch (Exception e)
            {
                return NotFound(e);
            };

        }

    }
}