using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FabricMarket_DAL.Migrations
{
    /// <inheritdoc />
    public partial class FixProductNameIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Product_Name",
                table: "Product");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Name",
                table: "Product",
                column: "Name")
                .Annotation("Npgsql:IndexInclude", new[] { "Id", "Description", "PicturePath" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Product_Name",
                table: "Product");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Name",
                table: "Product",
                column: "Name")
                .Annotation("Npgsql:IndexInclude", new[] { "PicturePath" });
        }
    }
}
