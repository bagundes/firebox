using Microsoft.EntityFrameworkCore.Migrations;

namespace webviews.Migrations
{
    public partial class _20181014162817 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SYNCM0_Table",
                table: "SYNCM0");

            migrationBuilder.AlterColumn<string>(
                name: "Table",
                table: "SYNCM0",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "SYNCM0",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SYNCM0_Table",
                table: "SYNCM0",
                column: "Table",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SYNCM0_Table",
                table: "SYNCM0");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "SYNCM0");

            migrationBuilder.AlterColumn<string>(
                name: "Table",
                table: "SYNCM0",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_SYNCM0_Table",
                table: "SYNCM0",
                column: "Table",
                unique: true,
                filter: "[Table] IS NOT NULL");
        }
    }
}
