using lesson11_FabricMarket_DomainModel.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FabricMarket_DAL.DbEntityConfigurations.Identity
{
    internal class UserDBConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //builder.ToTable(nameof(UserSettings));

            //builder.HasOne<UserSettings>()
            //    .WithOne(userSettings => userSettings.User)
            //    .HasForeignKey<User>(user => user.Id);
        }
    }
}
