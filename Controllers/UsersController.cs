using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using KalanchoeAI_Backend.Authorization;
using KalanchoeAI_Backend.Helpers;
using KalanchoeAI_Backend.Models.Users;
using KalanchoeAI_Backend.Services;
using KalanchoeAI_Backend.Models;
using Microsoft.AspNetCore.Http;

namespace KalanchoeAI_Backend.Controllers
{
    [Authorization.Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public UsersController(
            IUserService userService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            //HttpContext.Response.Cookies.Append("token", response.Token,
            //    new Microsoft.AspNetCore.Http.CookieOptions { Expires = DateTime.Now.AddMinutes(120) });

            //HttpContext.Response.Cookies.Append("user", response.UserId.ToString());    

            var cookieOptions = new CookieOptions
            {
                // Set the secure flag, which Chrome's changes will require for SameSite none.
                // Note this will also require you to be running on HTTPS.
                Secure = true,

                // Set the cookie to HTTP only which is good practice unless you really do need
                // to access it client side in scripts.
                HttpOnly = true,

                // Add the SameSite attribute, this will emit the attribute with a value of none.
                SameSite = SameSiteMode.None

                // The client should follow its default cookie policy.
                // SameSite = SameSiteMode.Unspecified
            };

            // Add the cookie to the response cookie collection
            Response.Cookies.Append("MyCookie", "cookieValue", cookieOptions);
        

        cookieOptions.Expires = DateTime.Now.AddDays(1);

            cookieOptions.Path = "/";

            Response.Cookies.Append("token", response.Token, cookieOptions);

            Response.Cookies.Append("user", response.UserId.ToString(), cookieOptions);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequest model)
        {
            _userService.Register(model);

            AuthenticateRequest authenticateModel = new AuthenticateRequest();

            authenticateModel.Username = model.Username;
            authenticateModel.Password = model.Password;

            Authenticate(authenticateModel);
            return Ok(new { message = "Registration successful" });
        }

        [AllowAnonymous]
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            var token = HttpContext.Request.Cookies["token"];

            var user = HttpContext.Request.Cookies["user"];

            if (token != null && user != null)
            {
                HttpContext.Response.Cookies.Delete("token");
                HttpContext.Response.Cookies.Delete("user");
            }

            return Ok(new { message = "Logout successful" });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("data")]
        public IActionResult GetById()
        {
            var user = HttpContext.Items["User"];
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateRequest model)
        {
            _userService.Update(id, model);
            return Ok(new { message = "User updated successfully" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok(new { message = "User deleted successfully" });
        }
    }
}