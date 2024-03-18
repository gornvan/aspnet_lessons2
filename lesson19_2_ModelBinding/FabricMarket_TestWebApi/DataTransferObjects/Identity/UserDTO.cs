using lesson11_FabricMarket_DomainModel.Models.FabricProduction;
using lesson11_FabricMarket_DomainModel.Models.Identity;
using Microsoft.AspNetCore.Mvc;
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

        [MinLength(10, ErrorMessage = "The password is too short!")]
        [MaxLength(50)]
        public required string Password { get; set; }
    }
}
