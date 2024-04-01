using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FabricMarket_DAL.Migrations
{
    /// <inheritdoc />
    public partial class RemoveExcessSystemIdFieldFromSystemSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SettingId",
                table: "SystemSetting");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SettingId",
                table: "SystemSetting",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
