
using System.ComponentModel.DataAnnotations;

namespace lesson11_FabricMarket_DomainModel.Models.Identity
{
    public class User : Entity<long>
    {
        [MaxLength(100)]
        public required string FirstName { get; set; }
        [MaxLength(100)]
        public string? LastName { get; set; }
        [MaxLength(200)]
        public required string Email { get; set; }
        public required UserRoleEnum Role { get; set; }

        [MaxLength(100)]
        public required string PasswordHash { get; set; }
        [MaxLength(100)]
        public required string PasswordSalt { get; set; }

        public required UserSettings UserSettings { get; set; }

        public string FullName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(LastName))
                {
                    return FirstName;
                }
                return $"{FirstName} {LastName}";
            }
        }
    }
}
