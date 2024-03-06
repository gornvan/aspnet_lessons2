using lesson11_FabricMarket_DomainModel.Models.Identity;

namespace FabricMarket_BLL.Contracts.Identity
{
    public class UserBriefModel
    {
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public required string Email { get; set; }
        public required UserRoleEnum Role { get; set; }
    }
}
