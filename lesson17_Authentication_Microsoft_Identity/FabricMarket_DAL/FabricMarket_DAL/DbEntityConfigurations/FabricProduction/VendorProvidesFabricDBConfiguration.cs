using lesson11_FabricMarket_DomainModel.Models.FabricProduction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FabricMarket_DAL.DbEntityConfigurations.FabricProduction
{
    internal class VendorProvidesFabricDBConfiguration : IEntityTypeConfiguration<VendorProvidesFabric>
    {
        public void Configure(EntityTypeBuilder<VendorProvidesFabric> builder)
        {
            builder.HasKey(vpf => new { vpf.VendorId, vpf.FabricVariantId });

            builder.HasOne(vpf => vpf.Vendor)
                .WithMany(v => v.Provides)
                .HasForeignKey(vpf => vpf.VendorId);

            builder.HasOne(vpf => vpf.FabricVariant)
                .WithMany(fv => fv.Sources)
                .HasForeignKey(vpf => vpf.FabricVariantId);
        }
    }
}
