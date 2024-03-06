using FabricMarket_BLL.Contracts.Identity;
using FabricMarket_DAL;
using FabricMarket_TestWebApi.DataTransferObjects.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FabricMarket_TestWebApi.Controllers.Identity
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async IActionResult CreateUser([FromBody]UserBriefDTO user)
        {
            var newUserModel = new UserBriefModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role,
            };

            var newUserId = _userService.CreateUser(newUserModel);

            return Ok();
        }


        [HttpGet]
        public IActionResult SearchForUsers([FromQuery] string query)
        {
            return Ok();
        }
    }
}
