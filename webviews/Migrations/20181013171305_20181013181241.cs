using Microsoft.EntityFrameworkCore.Migrations;

namespace webviews.Migrations
{
    public partial class _20181013181241 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CityModel",
                table: "CityModel");

            migrationBuilder.RenameTable(
                name: "CityModel",
                newName: "CITIS0");

            migrationBuilder.RenameIndex(
                name: "IX_CityModel_UUID",
                table: "CITIS0",
                newName: "IX_CITIS0_UUID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CITIS0",
                table: "CITIS0",
                columns: new[] { "Id", "FatherId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CITIS0",
                table: "CITIS0");

            migrationBuilder.RenameTable(
                name: "CITIS0",
                newName: "CityModel");

            migrationBuilder.RenameIndex(
                name: "IX_CITIS0_UUID",
                table: "CityModel",
                newName: "IX_CityModel_UUID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CityModel",
                table: "CityModel",
                columns: new[] { "Id", "FatherId" });
        }
    }
}
