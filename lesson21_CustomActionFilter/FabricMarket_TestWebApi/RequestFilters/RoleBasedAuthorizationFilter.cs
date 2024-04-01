using FabricMarket_BLL.Contracts.Identity;
using lesson11_FabricMarket_DomainModel.Models.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace FabricMarket_TestWebApi.RequestFilters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class RoleBasedAuthorizationFilterAttribute : Attribute, IAsyncAuthorizationFilter
    {
        public UserRoleEnum Role { get; set; }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var currentUser = context.HttpContext.User;

            if (currentUser == null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var userIdClaim = currentUser.Claims.FirstOrDefault(cl => cl.Type == ClaimTypes.NameIdentifier);

            if(userIdClaim == null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
            var actualRole = await userService.GetUserRole(userIdClaim.Value);

            if (actualRole == null) {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (actualRole != Role)
            {
                context.Result = new UnauthorizedResult();
            }
        }

    }
}
