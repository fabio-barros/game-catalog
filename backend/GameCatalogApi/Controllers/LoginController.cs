using System;
using System.Diagnostics.Eventing.Reader;
using System.Threading.Tasks;
using GameCatalogApi.Models;
using GameCatalogApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserDataApp.Models;
using UserDataApp.Services.LoginServices;
using UserDataApp.Services.UserServices;

namespace GameCatalogApi.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService, ITokenService tokenService)
        {
            _loginService = loginService;
            _tokenService = tokenService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Login([FromBody] LoginInfo login)
        {

            if (login is null)
                return BadRequest(new ArgumentNullException());

            try
            {
                var user = await _loginService.Login(login);
                var token = _tokenService.Generatetoken(user);
                HttpContext.Response.Cookies.Append("access_token", token, new CookieOptions { Expires = DateTime.Now.AddHours(1) });

                return new
                {
                    user = user,
                    token = token,
                    auth = true
                };

            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpGet]
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