
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace lesson11_FabricMarket_DomainModel.Models.Identity
{
    public class User : IdentityUser, IEntity
    {
        [PersonalData]
        public override string Id { get; set; } = default!;

        [PersonalData]
        [MaxLength(100)]
        public required string FirstName { get; set; }
        
        [PersonalData]
        [MaxLength(100)]
        public string? LastName { get; set; }

        public required UserSettings UserSettings { get; set; }

        public required UserRoleEnum Role { get; set; }

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
