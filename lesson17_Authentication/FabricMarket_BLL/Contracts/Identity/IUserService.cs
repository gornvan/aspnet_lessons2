using lesson11_FabricMarket_DomainModel.Models.Identity;

namespace FabricMarket_BLL.Contracts.Identity
{
    public interface IUserService : IService
    {
        Task<List<UserBriefModel>> FetchUsers(long skip = 0, long take = 20, string? searchString = null, UserRoleEnum? role = null);

        Task<User> CreateUser(UserCreateModel user);

        Task<User> DeleteUser(long userId);

        Task<User> UpdateUserContactData(User user);

        Task<User> SetUserRole(long userId, UserRoleEnum newRole);

        Task<User> UpdatePassword(long userId, string newPassword);
    }
}
