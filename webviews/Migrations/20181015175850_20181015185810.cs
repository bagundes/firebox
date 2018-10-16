using Microsoft.EntityFrameworkCore.Migrations;

namespace webviews.Migrations
{
    public partial class _20181015185810 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VendorModel",
                table: "VendorModel");

            migrationBuilder.RenameTable(
                name: "VendorModel",
                newName: "VENDR0");

            migrationBuilder.RenameIndex(
                name: "IX_VendorModel_UUID",
                table: "VENDR0",
                newName: "IX_VENDR0_UUID");

            migrationBuilder.RenameIndex(
                name: "IX_VendorModel_Code",
                table: "VENDR0",
                newName: "IX_VENDR0_Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VENDR0",
                table: "VENDR0",
                columns: new[] { "Id", "FatherId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VENDR0",
                table: "VENDR0");

            migrationBuilder.RenameTable(
                name: "VENDR0",
                newName: "VendorModel");

            migrationBuilder.RenameIndex(
                name: "IX_VENDR0_UUID",
                table: "VendorModel",
                newName: "IX_VendorModel_UUID");

            migrationBuilder.RenameIndex(
                name: "IX_VENDR0_Code",
                table: "VendorModel",
                newName: "IX_VendorModel_Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VendorModel",
                table: "VendorModel",
                columns: new[] { "Id", "FatherId" });
        }
    }
}
