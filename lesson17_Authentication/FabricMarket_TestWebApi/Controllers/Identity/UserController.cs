using FabricMarket_BLL.Contracts.Identity;
using FabricMarket_TestWebApi.DataTransferObjects.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FabricMarket_TestWebApi.Controllers.Identity
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody]UserBriefDTO user)
        {
            var newUserModel = new UserCreateModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role,
                Password = user.Password
            };

            var newUserId = await _userService.CreateUser(newUserModel);

            return Ok(newUserId);
        }


        [HttpGet]
        public IActionResult SearchForUsers([FromQuery] string query)
        {
            return Ok();
        }
    }
}
