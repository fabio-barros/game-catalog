using System;
using System.Threading.Tasks;
using GameCatalogApi.Models;
using GameCatalogApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserDataApp.Models;

namespace GameCatalogApi.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        public HomeController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        // POST: api/Login
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
        {

            var user = UserRepository.GetUser(model.Email, model.Password);

            if (user is null)
                return BadRequest(new ArgumentNullException());

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