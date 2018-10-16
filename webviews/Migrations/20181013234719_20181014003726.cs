using Microsoft.EntityFrameworkCore.Migrations;

namespace webviews.Migrations
{
    public partial class _20181014003726 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PriceList",
                table: "BPART0",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "BPART0",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "ZonaFranca",
                table: "BPART0",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceList",
                table: "BPART0");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "BPART0");

            migrationBuilder.DropColumn(
                name: "ZonaFranca",
                table: "BPART0");
        }
    }
}
