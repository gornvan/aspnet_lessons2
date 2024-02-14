using lesson11_FabricMarket_DomainModel.Models.ECommerce;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FabricMarket_DAL.DbEntityConfigurations.Ecommerce
{
    internal class ProductDBConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasIndex(product => product.Name)
                .IncludeProperties(
                    nameof(Product.Id),
                    nameof(Product.Description),
                    nameof(Product.PicturePath)
                );
        }
    }
}
