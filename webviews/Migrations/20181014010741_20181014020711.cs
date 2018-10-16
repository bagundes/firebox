using Microsoft.EntityFrameworkCore.Migrations;

namespace webviews.Migrations
{
    public partial class _20181014020711 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "ADDRS0",
                newName: "LocationId");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "BPART0",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransporterId",
                table: "BPART0",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CITIS0_Code",
                table: "CITIS0",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CITIS0_Code",
                table: "CITIS0");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "BPART0");

            migrationBuilder.DropColumn(
                name: "TransporterId",
                table: "BPART0");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "ADDRS0",
                newName: "CityId");
        }
    }
}
