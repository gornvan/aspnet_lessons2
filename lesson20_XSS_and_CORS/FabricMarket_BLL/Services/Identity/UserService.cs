using FabricMarket_BLL.Contracts.Identity;
using FabricMarket_DAL;
using lesson11_FabricMarket_DomainModel.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.Encodings.Web;
using ILogger = Serilog.ILogger;

namespace FabricMarket_BLL.Services.Identity
{
    internal class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        private readonly IUserStore<User> _userStore;
        private readonly IUserEmailStore<User> _emailStore;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;

        public UserService(
            IUnitOfWork unitOfWork,
            UserManager<User> userManager,
            IUserStore<User> userStore,
            IEmailSender emailSender,
            ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _emailSender = emailSender;
            _logger = logger;
        }

        private IUserEmailStore<User> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<User>)_userStore;
        }


        public async Task<User> CreateUser(UserCreateModel user)
        {
            var defaultSettings = new UserSettings {
                Address = "",
                Phone = "",
                DarkThemeEnabled = false,
            };

            var newUser = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = user.Role,
                UserSettings = defaultSettings,
            };

            await _userStore.SetUserNameAsync(newUser, user.Email, CancellationToken.None);
            await _emailStore.SetEmailAsync(newUser, user.Email, CancellationToken.None);

            var result = await _userManager.CreateAsync(newUser, user.Password);

            if (result.Succeeded)
            {
                _logger.Information("User created a new account with password.");

                var userId = await _userManager.GetUserIdAsync(newUser);
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = $@"https://localhost:7183/confirm?userId={userId}&code={code}";

                var emailMessage = $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.";
                await _emailSender.SendEmailAsync(newUser.Email, "Confirm your email", emailMessage);
                
                return newUser;
            }

            throw new Exception(); // todo explain!
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
                            user.FirstName.Contains(str)
                            ||
                            user.LastName.Contains(str)
                            ||
                            user.Email.Contains(str)
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

        public Task<User> DeleteUser(string userId)
        {
            throw new NotImplementedException();
        }


        public Task<User> SetUserRole(string userId, UserRoleEnum newRole)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdatePassword(string userId, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUserContactData(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<UserRoleEnum?> GetUserRole(string userId)
        {
            var repo = _unitOfWork.GetRepository<User>();

            var user = await repo.AsReadOnlyQueryable().FirstOrDefaultAsync(u => u.Id == userId);

            return user?.Role;
        }
    }
}
