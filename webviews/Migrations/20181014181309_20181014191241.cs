using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webviews.Migrations
{
    public partial class _20181014191241 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ITEMS0",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FatherId = table.Column<int>(nullable: false),
                    UUID = table.Column<Guid>(nullable: false),
                    Code = table.Column<int>(nullable: true),
                    Actived = table.Column<bool>(nullable: false),
                    Blocked = table.Column<bool>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ValidUntil = table.Column<DateTime>(nullable: true),
                    VisOrder = table.Column<int>(nullable: false),
                    UserIdProper = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UserIdUpdate = table.Column<int>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    SimpleName = table.Column<string>(nullable: false),
                    Unit = table.Column<string>(nullable: false),
                    Barcode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITEMS0", x => new { x.Id, x.FatherId });
                });

            migrationBuilder.CreateIndex(
                name: "IX_ITEMS0_Code",
                table: "ITEMS0",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ITEMS0_UUID",
                table: "ITEMS0",
                column: "UUID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ITEMS0");
        }
    }
}
