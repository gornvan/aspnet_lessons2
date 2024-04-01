using FabricMarket_BLL.Contracts.Identity;
using lesson11_FabricMarket_DomainModel.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace FabricMarket_TestWebApi.Controllers.Identity
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfirmEmailController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public ConfirmEmailController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        const string FailureMessage = "Failed to confirm the user, wrong user id or code, please contact Your administrator";

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return BadRequest("userId and code are required fields");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return BadRequest(FailureMessage);
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));

            var result = await _userManager.ConfirmEmailAsync(user, code);

            if (result.Succeeded) {
                return Ok("Thank you for confirming your email.");
            }
            
            return BadRequest(FailureMessage);
        }
    }
}
