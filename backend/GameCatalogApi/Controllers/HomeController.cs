using System;
using System.Threading.Tasks;
using GameCatalogApi.Models;
using GameCatalogApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserDataApp.Models;
using UserDataApp.Services.UserServices;

namespace GameCatalogApi.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        private readonly IUserService _userService;
        public HomeController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Login([FromBody] User model)
        {

            var user = await _userService.Get(model.Id);

            if (user is null)
                return BadRequest(new ArgumentNullException("vai dar não"));

            try
            {
                var token = _tokenService.Generatetoken(user);
                user.Password = "";
                return new
                {
                    user = user,
                    token = token
                };

            }
            //BookAlreadyExistsException
            catch (Exception e)
            {

                return UnprocessableEntity(e.Message);
            }
        }

        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anonymous";

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => $"Authenticated: {User.Identity.Name}";

        [HttpGet]
        [Route("user")]
        [Authorize(Roles = "admin, user")]
        public string Userr() => "User";

        [HttpGet]
        [Route("admin")]
        [Authorize(Roles = "admin")]
        public string Admin() => "Admin";

    }
}