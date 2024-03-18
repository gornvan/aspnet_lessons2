using lesson11_FabricMarket_DomainModel.Models.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FabricMarket_TestWebApi.DataTransferObjects.Identity
{
	public class UserSearchDTO
	{
		[BindProperty(Name = "s")] // shorten the argument name to reduce traffic load on popular(?) endpoint
		public string? SearchString { get; set; } = default;
		public UserRoleEnum? Role {get; set;} = null;
		public int Skip {get; set;} = 0;
		public int Take { get; set; }  = 10;
	}
}
