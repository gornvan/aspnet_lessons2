using lesson11_FabricMarket_DomainModel.Models.FabricProduction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FabricMarket_DAL.DbEntityConfigurations.FabricProduction
{
    internal class ProductRequriesFabricDBConfiguration : IEntityTypeConfiguration<ProductRequiresFabric>
    {
        public void Configure(EntityTypeBuilder<ProductRequiresFabric> builder)
        {
            builder.HasKey(prf => new { prf.FabricVariantId, prf.ProductId });

            builder.HasOne(prf => prf.Product)
                .WithMany(p => p.RequiredFabrics)
                .HasForeignKey(prf => prf.ProductId);

            builder.HasOne(vpf => vpf.FabricVariant)
                .WithMany(fv => fv.DependentProducts)
                .HasForeignKey(vpf => vpf.FabricVariantId);
        }
    }
}
