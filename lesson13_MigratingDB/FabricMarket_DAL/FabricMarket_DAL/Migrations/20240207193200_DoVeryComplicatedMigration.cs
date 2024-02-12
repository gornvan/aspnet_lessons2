using Microsoft.EntityFrameworkCore.Migrations;

namespace FabricMarket_DAL.Migrations
{
    internal class DoVeryComplicatedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // aim: change id type

            // rename original table into temp_<OriginalName>

            // create <OriginalName> table with required types

            // copy temp_<OriginalName> table into the <OriginalName> new table
        }
    }
}
