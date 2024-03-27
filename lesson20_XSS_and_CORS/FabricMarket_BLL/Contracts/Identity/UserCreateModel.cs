using lesson11_FabricMarket_DomainModel.Models.Identity;

namespace FabricMarket_BLL.Contracts.Identity
{
    public class UserCreateModel : UserBriefModel
    {
        public required string Password { get; set; }
    }
}
