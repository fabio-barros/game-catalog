using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserDataApp.Models;
using UserDataApp.Services;
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

        // GET: api/Book
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userService.GetAll();

            if (users.Count == 0)
            {
                return NoContent();
            }

            return Ok(users);
        }

        // GET: api/Book/5
        [HttpGet("{id}", Name = "GetUser")]
        public async Task<ActionResult<User>> GetUser([FromRoute] Guid id)
        {
            var user = await _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST: api/Book
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User user)
        {

            if (user is null)
                return BadRequest(new ArgumentNullException());

            try
            {
                var userEntity = await _userService.Add(user);

                return Created(nameof(GetUser), userEntity);

            }
            //BookAlreadyExistsException
            catch (Exception e)
            {

                return UnprocessableEntity(e.Message);
            }
        }


        // PUT: api/Book/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, User user)
        {
            try
            {
                await _userService.Update(id, user);
                return NoContent();

            }
            //BookDoesNotExistException
            catch (Exception e)
            {
                return NotFound(e);
            }
        }



        // DELETE: api/Book/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                await _userService.Delete(id);
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