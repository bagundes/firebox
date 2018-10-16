using Microsoft.EntityFrameworkCore.Migrations;

namespace webviews.Migrations
{
    public partial class _20181014230415 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PriceListModel",
                table: "PriceListModel");

            migrationBuilder.RenameTable(
                name: "PriceListModel",
                newName: "PRLIST0");

            migrationBuilder.RenameIndex(
                name: "IX_PriceListModel_UUID",
                table: "PRLIST0",
                newName: "IX_PRLIST0_UUID");

            migrationBuilder.RenameIndex(
                name: "IX_PriceListModel_Code",
                table: "PRLIST0",
                newName: "IX_PRLIST0_Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PRLIST0",
                table: "PRLIST0",
                columns: new[] { "Id", "FatherId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PRLIST0",
                table: "PRLIST0");

            migrationBuilder.RenameTable(
                name: "PRLIST0",
                newName: "PriceListModel");

            migrationBuilder.RenameIndex(
                name: "IX_PRLIST0_UUID",
                table: "PriceListModel",
                newName: "IX_PriceListModel_UUID");

            migrationBuilder.RenameIndex(
                name: "IX_PRLIST0_Code",
                table: "PriceListModel",
                newName: "IX_PriceListModel_Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PriceListModel",
                table: "PriceListModel",
                columns: new[] { "Id", "FatherId" });
        }
    }
}
