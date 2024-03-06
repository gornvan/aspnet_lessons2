using FabricMarket_BLL.Contracts.Identity;
using FabricMarket_DAL;
using lesson11_FabricMarket_DomainModel.Models.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FabricMarket_BLL.Services.Identity
{
    internal class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> CreateUser(UserBriefModel user)
        {
            var repo = _unitOfWork.GetRepository<User>();

            var newDbUser = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role,
            };

            User trackedUser = repo.Create(newDbUser);

            await _unitOfWork.SaveChangesAsync();

            return trackedUser;
        }

        public Task<List<UserBriefModel>> FetchUsers(long skip = 0, long take = 20, string? searchString = null, UserRoleEnum? role = null)
        {
            var repo = _unitOfWork.GetRepository<User>();

            var query = repo.AsReadOnlyQueryable();


            if (!string.IsNullOrEmpty(searchString))
            {
                var searchStrings = searchString.Split(' ');

                query = from user in query
                        where searchStrings.All(str =>
                            user.FirstName.Contains(str, StringComparison.CurrentCultureIgnoreCase)
                            ||
                            user.LastName.Contains(str, StringComparison.CurrentCultureIgnoreCase)
                            ||
                            user.Email.Contains(str, StringComparison.CurrentCultureIgnoreCase)
                        )
                        select user;
            }

            if(role != null)
            {
                query = from user in query
                        where user.Role == role
                        select user;
            }

            var projectedQuery = from user in query
                                 select new UserBriefModel
                                 {
                                     Email = user.Email,
                                     FirstName = user.FirstName,
                                     LastName = user.LastName,
                                     Role = user.Role,
                                 };

            return projectedQuery.Skip((int)skip).Take((int)take).ToListAsync();
        }

        public Task<User> DeleteUser(long userId)
        {
            throw new NotImplementedException();
        }


        public Task<User> SetUserRole(long userId, UserRoleEnum newRole)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdatePassword(long userId, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUserContactData(User user)
        {
            throw new NotImplementedException();
        }
    }
}
