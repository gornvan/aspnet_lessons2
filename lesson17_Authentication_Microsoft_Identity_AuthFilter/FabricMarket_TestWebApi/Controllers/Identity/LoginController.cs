using FabricMarket_TestWebApi.DataTransferObjects.Identity;
using lesson11_FabricMarket_DomainModel.Models.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;

namespace FabricMarket_TestWebApi.Controllers.Identity
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger _logger;
        public LoginController(
            SignInManager<User> signInManager,
            ILogger logger)
        {
            _logger = logger;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginData)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _signInManager.PasswordSignInAsync(loginData.Email, loginData.Password, false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                _logger.Information($@"User {loginData.Email} has logged in.");
                return Ok();
            }

            if (result.IsLockedOut)
            {
                return Unauthorized("The user has been locked out, please contact Your administrator");
            }
            
            if (result.IsNotAllowed)
            {
                return Unauthorized("The user is not allowed to log in at the moment");
            }

            return Unauthorized("Email or/and Password are incorrect, please try again");
        }
    }
}
