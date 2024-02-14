using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FabricMarket_DAL.Migrations
{
    /// <inheritdoc />
    public partial class CreateProductNameIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Product_Name",
                table: "Product",
                column: "Name")
                .Annotation("Npgsql:IndexInclude", new[] { "PicturePath" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Product_Name",
                table: "Product");
        }
    }
}
