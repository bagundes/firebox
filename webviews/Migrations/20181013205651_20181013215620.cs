using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webviews.Migrations
{
    public partial class _20181013215620 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CityShort",
                table: "CITIS0",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateTable(
                name: "ADDRS0",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FatherId = table.Column<int>(nullable: false),
                    UUID = table.Column<Guid>(nullable: false),
                    Code = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Actived = table.Column<bool>(nullable: false),
                    Blocked = table.Column<bool>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ValidUntil = table.Column<DateTime>(nullable: true),
                    VisOrder = table.Column<int>(nullable: false),
                    UserIdProper = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UserIdUpdate = table.Column<int>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Address1 = table.Column<string>(nullable: false),
                    Address2 = table.Column<string>(nullable: true),
                    Block = table.Column<string>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    ZipCode = table.Column<string>(nullable: true),
                    GoogleCode = table.Column<string>(nullable: true),
                    Geolocation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADDRS0", x => new { x.Id, x.FatherId });
                });

            migrationBuilder.CreateTable(
                name: "BPART0",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FatherId = table.Column<int>(nullable: false),
                    UUID = table.Column<Guid>(nullable: false),
                    Code = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Actived = table.Column<bool>(nullable: false),
                    Blocked = table.Column<bool>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ValidUntil = table.Column<DateTime>(nullable: true),
                    VisOrder = table.Column<int>(nullable: false),
                    UserIdProper = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UserIdUpdate = table.Column<int>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    InterCode = table.Column<int>(nullable: false),
                    CardCode = table.Column<string>(nullable: false),
                    CompanyName = table.Column<string>(nullable: false),
                    TradingName = table.Column<string>(nullable: true),
                    TaxId1 = table.Column<string>(nullable: false),
                    TaxId2 = table.Column<string>(nullable: true),
                    TaxId3 = table.Column<string>(nullable: true),
                    AddressShipId = table.Column<int>(nullable: false),
                    AddressBillId = table.Column<int>(nullable: false),
                    Salesman = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BPART0", x => new { x.Id, x.FatherId });
                });

            migrationBuilder.CreateIndex(
                name: "IX_ADDRS0_UUID",
                table: "ADDRS0",
                column: "UUID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BPART0_CardCode",
                table: "BPART0",
                column: "CardCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BPART0_Code",
                table: "BPART0",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BPART0_UUID",
                table: "BPART0",
                column: "UUID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ADDRS0");

            migrationBuilder.DropTable(
                name: "BPART0");

            migrationBuilder.AlterColumn<string>(
                name: "CityShort",
                table: "CITIS0",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
