using Microsoft.EntityFrameworkCore.Migrations;

namespace webviews.Migrations
{
    public partial class b : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PartnerName",
                table: "ORDER0",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PartnerName",
                table: "ORDER0",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
