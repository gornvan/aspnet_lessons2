using FabricMarket_BLL.Contracts.Identity;
using FabricMarket_TestWebApi.DataTransferObjects.Identity;
using FabricMarket_TestWebApi.RequestFilters;
using lesson11_FabricMarket_DomainModel.Models.Identity;
using Microsoft.AspNetCore.Authorization;
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
        //[Authorize] // Micorosft Identity's attribute - uses Claims and dynamic Roles, too complicated for our usecase
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

            var newUser = await _userService.CreateUser(newUserModel);

            return Ok(newUser.Id);
        }


        [HttpGet]
        [RoleBasedAuthorizationFilter(Role = UserRoleEnum.Administrator)]
        public async Task<IActionResult> SearchForUsers(
            [FromQuery] UserSearchDTO searchParams)
        {
            var users = await _userService.FetchUsers(
                searchParams.Skip,
                searchParams.Take, 
                searchParams.SearchString,
                searchParams.Role);

            if(users.Count == 0)
            {
                return NotFound();
            }

            return Ok(users);
        }
    }
}
