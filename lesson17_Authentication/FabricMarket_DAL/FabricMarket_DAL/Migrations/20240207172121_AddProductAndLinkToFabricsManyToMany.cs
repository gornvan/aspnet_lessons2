using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FabricMarket_DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddProductAndLinkToFabricsManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    PicturePath = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductRequiresFabric",
                columns: table => new
                {
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    FabricVariantId = table.Column<long>(type: "bigint", nullable: false),
                    AreaOfFabric = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRequiresFabric", x => new { x.FabricVariantId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductRequiresFabric_FabricVariant_FabricVariantId",
                        column: x => x.FabricVariantId,
                        principalTable: "FabricVariant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductRequiresFabric_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductRequiresFabric_ProductId",
                table: "ProductRequiresFabric",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductRequiresFabric");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
