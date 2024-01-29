using FabricMarket_DAL;
using lesson11_FabricMarket_DomainModel.Models.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace FabricMarket_TestWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TestController(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }

        [HttpGet(Name = "TestGet")]
        [ProducesResponseType<User>(200, contentType: "application/json")]
        public async Task<IActionResult> Get()
        {
            var userRepo = _unitOfWork.GetRepository<User>();
            var user = new User
            {
                Email = "user@example.com",
                FirstName = "Test",
                LastName = "Test",
                Role = UserRole.Administrator,
                PasswordHash = "",
                PasswordSalt = "",
            };

            userRepo.Create(user);

            await _unitOfWork.SaveChangesAsync();

            return Ok(user);
        }
    }
}
