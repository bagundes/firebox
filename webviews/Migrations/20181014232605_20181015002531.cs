using Microsoft.EntityFrameworkCore.Migrations;

namespace webviews.Migrations
{
    public partial class _20181015002531 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PRLIST0_Code",
                table: "PRLIST0");

            migrationBuilder.AlterColumn<int>(
                name: "InternItemCode",
                table: "PRLIST0",
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "InternItemCode",
                table: "PRLIST0",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_PRLIST0_Code",
                table: "PRLIST0",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");
        }
    }
}
