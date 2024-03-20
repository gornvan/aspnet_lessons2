using lesson11_FabricMarket_DomainModel.Models.FabricProduction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FabricMarket_DAL.DbEntityConfigurations.Identity
{
    internal class FabricTypeDBConfiguration : IEntityTypeConfiguration<FabricType>
    {
        public void Configure(EntityTypeBuilder<FabricType> builder)
        {
            
        }
    }
}
