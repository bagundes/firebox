using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webviews.Migrations
{
    public partial class _20181013180931 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CityModel",
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
                    Country = table.Column<string>(nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    StateId = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    CityId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityModel", x => new { x.Id, x.FatherId });
                });

            migrationBuilder.CreateTable(
                name: "MODLS0",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FatherId = table.Column<int>(nullable: false),
                    UUID = table.Column<Guid>(nullable: false),
                    Code = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Actived = table.Column<bool>(nullable: false),
                    Blocked = table.Column<bool>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ValidUntil = table.Column<DateTime>(nullable: true),
                    VisOrder = table.Column<int>(nullable: false),
                    UserIdProper = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UserIdUpdate = table.Column<int>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Nivel = table.Column<int>(nullable: false),
                    Controller = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    PrefixIcons = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MODLS0", x => new { x.Id, x.FatherId });
                });

            migrationBuilder.CreateTable(
                name: "ORDER0",
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
                    Serie = table.Column<int>(nullable: false),
                    ExtNumber = table.Column<int>(nullable: false),
                    DocType = table.Column<int>(nullable: false),
                    DocDate = table.Column<DateTime>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: true),
                    PartnerId = table.Column<int>(nullable: false),
                    PartnerName = table.Column<int>(nullable: false),
                    ShippingCompany = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Complement = table.Column<string>(nullable: true),
                    Block = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    CommentsHeader = table.Column<string>(nullable: true),
                    CommentsFooter = table.Column<string>(nullable: true),
                    DocNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER0", x => new { x.Id, x.FatherId });
                });

            migrationBuilder.CreateTable(
                name: "ORDER1",
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
                    DocType = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    ItemName = table.Column<string>(nullable: false),
                    Qtty = table.Column<double>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    DescPerc = table.Column<double>(nullable: false),
                    DescValue = table.Column<double>(nullable: false),
                    Comments = table.Column<string>(maxLength: 100, nullable: true),
                    RuleId = table.Column<int>(nullable: false),
                    CommPerc = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER1", x => new { x.Id, x.FatherId });
                });

            migrationBuilder.CreateTable(
                name: "ORDER2",
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
                    TaxName = table.Column<string>(nullable: false),
                    Fee = table.Column<double>(nullable: false),
                    Base = table.Column<double>(nullable: false),
                    Discont = table.Column<double>(nullable: false),
                    AddTotalLine = table.Column<bool>(nullable: false),
                    TaxId = table.Column<int>(nullable: false),
                    LineId = table.Column<int>(nullable: false),
                    DocType = table.Column<int>(nullable: false),
                    TaxValue = table.Column<double>(nullable: false),
                    TaxTotal = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER2", x => new { x.Id, x.FatherId });
                });

            migrationBuilder.CreateTable(
                name: "PERFL0",
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
                    PerfilId = table.Column<int>(nullable: false),
                    Perfil = table.Column<string>(nullable: false),
                    ModuleId = table.Column<int>(nullable: false),
                    View = table.Column<bool>(nullable: false),
                    Add = table.Column<bool>(nullable: false),
                    Edit = table.Column<bool>(nullable: false),
                    AllUsers = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERFL0", x => new { x.Id, x.FatherId });
                });

            migrationBuilder.CreateTable(
                name: "USERS0",
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
                    FullName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PerfilId = table.Column<int>(nullable: false),
                    PasswdHash = table.Column<string>(nullable: false),
                    Remember = table.Column<bool>(nullable: false),
                    Admin = table.Column<bool>(nullable: false),
                    Terms = table.Column<bool>(nullable: false),
                    AutToken = table.Column<string>(nullable: true),
                    AutCookie = table.Column<string>(nullable: true),
                    AutDueDate = table.Column<DateTime>(nullable: true),
                    ERPVendor = table.Column<int>(nullable: false),
                    ERPBranch = table.Column<string>(nullable: true),
                    ERPUser = table.Column<string>(nullable: true),
                    ERPPasswd = table.Column<string>(nullable: true),
                    ERPEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS0", x => new { x.Id, x.FatherId });
                });

            migrationBuilder.CreateIndex(
                name: "IX_CityModel_UUID",
                table: "CityModel",
                column: "UUID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MODLS0_UUID",
                table: "MODLS0",
                column: "UUID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ORDER0_UUID",
                table: "ORDER0",
                column: "UUID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ORDER1_UUID",
                table: "ORDER1",
                column: "UUID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ORDER2_UUID",
                table: "ORDER2",
                column: "UUID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PERFL0_UUID",
                table: "PERFL0",
                column: "UUID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USERS0_Email",
                table: "USERS0",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USERS0_Name",
                table: "USERS0",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_USERS0_UUID",
                table: "USERS0",
                column: "UUID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CityModel");

            migrationBuilder.DropTable(
                name: "MODLS0");

            migrationBuilder.DropTable(
                name: "ORDER0");

            migrationBuilder.DropTable(
                name: "ORDER1");

            migrationBuilder.DropTable(
                name: "ORDER2");

            migrationBuilder.DropTable(
                name: "PERFL0");

            migrationBuilder.DropTable(
                name: "USERS0");
        }
    }
}
