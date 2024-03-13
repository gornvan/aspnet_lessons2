using lesson11_FabricMarket_DomainModel.Models.Identity;
using System.ComponentModel.DataAnnotations;

namespace FabricMarket_TestWebApi.DataTransferObjects.Identity
{
    public class UserBriefDTO
    {
        [MaxLength(100)]
        public required string FirstName { get; set; }
        
        [MaxLength(100)]
        public string? LastName { get; set; }

        [MaxLength(200)]
        public required string Email { get; set; }
        
        public required UserRoleEnum Role { get; set; }

        [MinLength(10)]
        [MaxLength(50)]
        public required string Password { get; set; }
    }
}
