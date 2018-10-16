using Microsoft.EntityFrameworkCore.Migrations;

namespace webviews.Migrations
{
    public partial class _20181013182247 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CityShort",
                table: "CITIS0",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CountryShort",
                table: "CITIS0",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StateShort",
                table: "CITIS0",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityShort",
                table: "CITIS0");

            migrationBuilder.DropColumn(
                name: "CountryShort",
                table: "CITIS0");

            migrationBuilder.DropColumn(
                name: "StateShort",
                table: "CITIS0");
        }
    }
}
