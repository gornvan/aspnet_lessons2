using lesson11_FabricMarket_DomainModel.Models.Identity;

namespace FabricMarket_TestWebApi.DataTransferObjects.Identity
{
	public class UserSearchDTO
	{
		public string? searchString { get; set; } = default;
		public UserRoleEnum? role {get; set;} = null;
		public int skip {get; set;} = 0;
		public int take { get; set; }  = 10;
	}
}
