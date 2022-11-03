using BrightApp.Server.Services.AuthService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrightApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static UserData user = new UserData();
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<string>> Register(User request)
        {
            //_authService.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            ////Refactor this piece of code. Controller is too fat, put all the assignments into the authservice and save to database.
            ////I think you need to use the bleet context. Create a method to both create the password hash and also save it to the database.
            //user.Username = request.Username;
            //user.FirstName = request.FirstName;
            //user.LastName = request.LastName;
            //user.Email = request.Email;
            //user.PasswordHash = passwordHash;
            //user.PasswordSalt = passwordSalt;
            //user.CreatedDate = DateTime.Now;

            _authService.StorePassword(request);

            return Ok("User Created!");
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserLogin request)
        {
            var token = await _authService.AuthenticateUser(request);
            return token;
        }

    }
}
