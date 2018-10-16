﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webviews;

namespace webviews.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20181015184806_20181015194734")]
    partial class _20181015194734
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("webviews.Models.Administration.ModuleModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FatherId");

                    b.Property<string>("Action");

                    b.Property<bool>("Actived");

                    b.Property<bool>("Blocked");

                    b.Property<int?>("Code");

                    b.Property<string>("Controller");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Icon");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Nivel");

                    b.Property<string>("PrefixIcons");

                    b.Property<int>("Status");

                    b.Property<Guid>("UUID");

                    b.Property<DateTime?>("UpdateAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int>("UserIdProper");

                    b.Property<int>("UserIdUpdate");

                    b.Property<DateTime?>("ValidUntil");

                    b.Property<int>("VisOrder");

                    b.HasKey("Id", "FatherId");

                    b.HasIndex("UUID")
                        .IsUnique();

                    b.ToTable("MODLS0");
                });

            modelBuilder.Entity("webviews.Models.Administration.PerfilModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FatherId");

                    b.Property<bool>("Actived");

                    b.Property<bool>("Add");

                    b.Property<bool>("AllUsers");

                    b.Property<bool>("Blocked");

                    b.Property<int?>("Code");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Edit");

                    b.Property<int>("ModuleId");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<string>("Perfil")
                        .IsRequired();

                    b.Property<int>("PerfilId");

                    b.Property<int>("Status");

                    b.Property<Guid>("UUID");

                    b.Property<DateTime?>("UpdateAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int>("UserIdProper");

                    b.Property<int>("UserIdUpdate");

                    b.Property<DateTime?>("ValidUntil");

                    b.Property<bool>("View");

                    b.Property<int>("VisOrder");

                    b.HasKey("Id", "FatherId");

                    b.HasIndex("UUID")
                        .IsUnique();

                    b.ToTable("PERFL0");
                });

            modelBuilder.Entity("webviews.Models.Administration.SyncModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FatherId");

                    b.Property<bool>("Actived");

                    b.Property<bool>("Blocked");

                    b.Property<int?>("Code");

                    b.Property<int>("Count");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Key");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<int>("Status");

                    b.Property<string>("Table")
                        .IsRequired();

                    b.Property<Guid>("UUID");

                    b.Property<DateTime?>("UpdateAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<DateTime>("Updated");

                    b.Property<int>("UserIdProper");

                    b.Property<int>("UserIdUpdate");

                    b.Property<DateTime?>("ValidUntil");

                    b.Property<int>("VisOrder");

                    b.HasKey("Id", "FatherId");

                    b.HasIndex("Table")
                        .IsUnique();

                    b.HasIndex("UUID")
                        .IsUnique();

                    b.ToTable("SYNCM0");
                });

            modelBuilder.Entity("webviews.Models.Administration.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FatherId");

                    b.Property<bool>("Actived");

                    b.Property<bool>("Admin");

                    b.Property<string>("AutCookie");

                    b.Property<DateTime?>("AutDueDate");

                    b.Property<string>("AutToken");

                    b.Property<bool>("Blocked");

                    b.Property<int?>("Code");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ERPBranch");

                    b.Property<bool>("ERPEnabled");

                    b.Property<string>("ERPPasswd");

                    b.Property<string>("ERPUser");

                    b.Property<int>("ERPVendor");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FullName")
                        .IsRequired();

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<string>("PasswdHash")
                        .IsRequired();

                    b.Property<int>("PerfilId");

                    b.Property<bool>("Remember");

                    b.Property<int>("Status");

                    b.Property<bool>("Terms");

                    b.Property<Guid>("UUID");

                    b.Property<DateTime?>("UpdateAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int>("UserIdProper");

                    b.Property<int>("UserIdUpdate");

                    b.Property<DateTime?>("ValidUntil");

                    b.Property<int>("VisOrder");

                    b.HasKey("Id", "FatherId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.HasIndex("UUID")
                        .IsUnique();

                    b.ToTable("USERS0");
                });

            modelBuilder.Entity("webviews.Models.Documents.SalesOrder_ItemModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FatherId");

                    b.Property<bool>("Actived");

                    b.Property<bool>("Blocked");

                    b.Property<int?>("Code");

                    b.Property<double>("CommPerc");

                    b.Property<string>("Comments")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("DescPerc");

                    b.Property<double>("DescValue");

                    b.Property<int>("DocType");

                    b.Property<int>("ItemId");

                    b.Property<string>("ItemName")
                        .IsRequired();

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<double>("Price");

                    b.Property<double>("Qtty");

                    b.Property<int>("RuleId");

                    b.Property<int>("Status");

                    b.Property<Guid>("UUID");

                    b.Property<DateTime?>("UpdateAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int>("UserIdProper");

                    b.Property<int>("UserIdUpdate");

                    b.Property<DateTime?>("ValidUntil");

                    b.Property<int>("VisOrder");

                    b.HasKey("Id", "FatherId");

                    b.HasIndex("UUID")
                        .IsUnique();

                    b.ToTable("ORDER1");
                });

            modelBuilder.Entity("webviews.Models.Documents.SalesOrder_TaxModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FatherId");

                    b.Property<bool>("Actived");

                    b.Property<bool>("AddTotalLine");

                    b.Property<double>("Base");

                    b.Property<bool>("Blocked");

                    b.Property<int?>("Code");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Discont");

                    b.Property<int>("DocType");

                    b.Property<double>("Fee");

                    b.Property<int>("LineId");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<int>("Status");

                    b.Property<int>("TaxId");

                    b.Property<string>("TaxName")
                        .IsRequired();

                    b.Property<double>("TaxTotal");

                    b.Property<double>("TaxValue");

                    b.Property<Guid>("UUID");

                    b.Property<DateTime?>("UpdateAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int>("UserIdProper");

                    b.Property<int>("UserIdUpdate");

                    b.Property<DateTime?>("ValidUntil");

                    b.Property<int>("VisOrder");

                    b.HasKey("Id", "FatherId");

                    b.HasIndex("UUID")
                        .IsUnique();

                    b.ToTable("ORDER2");
                });

            modelBuilder.Entity("webviews.Models.Documents.SalesOrderModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FatherId");

                    b.Property<bool>("Actived");

                    b.Property<string>("Address");

                    b.Property<string>("Block");

                    b.Property<bool>("Blocked");

                    b.Property<string>("City");

                    b.Property<int?>("Code");

                    b.Property<string>("CommentsFooter");

                    b.Property<string>("CommentsHeader");

                    b.Property<string>("Complement");

                    b.Property<string>("Contact");

                    b.Property<string>("Country");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DocDate");

                    b.Property<int>("DocNumber");

                    b.Property<int>("DocType");

                    b.Property<DateTime?>("DueDate");

                    b.Property<string>("Email");

                    b.Property<int>("ExtNumber");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<string>("Number");

                    b.Property<int>("PartnerId");

                    b.Property<int>("PartnerName");

                    b.Property<string>("Phone");

                    b.Property<int>("Serie");

                    b.Property<int>("ShippingCompany");

                    b.Property<string>("State");

                    b.Property<int>("Status");

                    b.Property<Guid>("UUID");

                    b.Property<DateTime?>("UpdateAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int>("UserIdProper");

                    b.Property<int>("UserIdUpdate");

                    b.Property<DateTime?>("ValidUntil");

                    b.Property<int>("VisOrder");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id", "FatherId");

                    b.HasIndex("UUID")
                        .IsUnique();

                    b.ToTable("ORDER0");
                });

            modelBuilder.Entity("webviews.Models.Invariable.AddressModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FatherId");

                    b.Property<bool>("Actived");

                    b.Property<string>("Address1")
                        .IsRequired();

                    b.Property<string>("Address2");

                    b.Property<string>("Block")
                        .IsRequired();

                    b.Property<bool>("Blocked");

                    b.Property<int?>("Code");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Geolocation");

                    b.Property<string>("GoogleCode");

                    b.Property<int>("LocationId");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<int>("Status");

                    b.Property<int>("Type");

                    b.Property<Guid>("UUID");

                    b.Property<DateTime?>("UpdateAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int>("UserIdProper");

                    b.Property<int>("UserIdUpdate");

                    b.Property<DateTime?>("ValidUntil");

                    b.Property<int>("VisOrder");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id", "FatherId");

                    b.HasIndex("UUID")
                        .IsUnique();

                    b.ToTable("ADDRS0");
                });

            modelBuilder.Entity("webviews.Models.Invariable.CityModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FatherId");

                    b.Property<bool>("Actived");

                    b.Property<bool>("Blocked");

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("CityId")
                        .IsRequired();

                    b.Property<string>("CityShort");

                    b.Property<int?>("Code");

                    b.Property<string>("Country")
                        .IsRequired();

                    b.Property<int>("CountryId");

                    b.Property<string>("CountryShort")
                        .IsRequired();

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<string>("State")
                        .IsRequired();

                    b.Property<string>("StateId")
                        .IsRequired();

                    b.Property<string>("StateShort")
                        .IsRequired();

                    b.Property<int>("Status");

                    b.Property<Guid>("UUID");

                    b.Property<DateTime?>("UpdateAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int>("UserIdProper");

                    b.Property<int>("UserIdUpdate");

                    b.Property<DateTime?>("ValidUntil");

                    b.Property<int>("VisOrder");

                    b.HasKey("Id", "FatherId");

                    b.HasIndex("Code")
                        .IsUnique()
                        .HasFilter("[Code] IS NOT NULL");

                    b.HasIndex("UUID")
                        .IsUnique();

                    b.ToTable("CITIS0");
                });

            modelBuilder.Entity("webviews.Models.Invariable.ItemsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FatherId");

                    b.Property<bool>("Actived");

                    b.Property<string>("Barcode")
                        .IsRequired();

                    b.Property<bool>("Blocked");

                    b.Property<int?>("Code");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("SimpleName")
                        .IsRequired();

                    b.Property<int>("Status");

                    b.Property<Guid>("UUID");

                    b.Property<string>("Unit")
                        .IsRequired();

                    b.Property<DateTime?>("UpdateAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int>("UserIdProper");

                    b.Property<int>("UserIdUpdate");

                    b.Property<DateTime?>("ValidUntil");

                    b.Property<int>("VisOrder");

                    b.HasKey("Id", "FatherId");

                    b.HasIndex("Code")
                        .IsUnique()
                        .HasFilter("[Code] IS NOT NULL");

                    b.HasIndex("UUID")
                        .IsUnique();

                    b.ToTable("ITEMS0");
                });

            modelBuilder.Entity("webviews.Models.Invariable.PriceListModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FatherId");

                    b.Property<bool>("Actived");

                    b.Property<string>("Barcode")
                        .IsRequired();

                    b.Property<bool>("Blocked");

                    b.Property<int?>("Code");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("InternItemCode");

                    b.Property<string>("ListName")
                        .IsRequired();

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<double>("Price");

                    b.Property<int>("PriceList");

                    b.Property<int>("Status");

                    b.Property<Guid>("UUID");

                    b.Property<DateTime?>("UpdateAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int>("UserIdProper");

                    b.Property<int>("UserIdUpdate");

                    b.Property<DateTime?>("ValidUntil");

                    b.Property<int>("VisOrder");

                    b.HasKey("Id", "FatherId");

                    b.HasIndex("UUID")
                        .IsUnique();

                    b.ToTable("PRLIST0");
                });

            modelBuilder.Entity("webviews.Models.Invariable.VendorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FatherId");

                    b.Property<bool>("Actived");

                    b.Property<bool>("Blocked");

                    b.Property<int?>("Code");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<int>("Status");

                    b.Property<Guid>("UUID");

                    b.Property<DateTime?>("UpdateAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int>("UserIdProper");

                    b.Property<int>("UserIdUpdate");

                    b.Property<DateTime?>("ValidUntil");

                    b.Property<int>("VendorCode");

                    b.Property<string>("VendorName")
                        .IsRequired();

                    b.Property<int>("VisOrder");

                    b.HasKey("Id", "FatherId");

                    b.HasIndex("Code")
                        .IsUnique()
                        .HasFilter("[Code] IS NOT NULL");

                    b.HasIndex("UUID")
                        .IsUnique();

                    b.ToTable("VENDR0");
                });

            modelBuilder.Entity("webviews.Models.Partners.BusinessPartnerModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FatherId");

                    b.Property<bool>("Actived");

                    b.Property<int>("AddressBillId");

                    b.Property<int>("AddressShipId");

                    b.Property<bool>("Blocked");

                    b.Property<string>("CardCode")
                        .IsRequired();

                    b.Property<int?>("Code");

                    b.Property<string>("CompanyName")
                        .IsRequired();

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<int>("InterCode");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<int>("PriceList");

                    b.Property<int>("Salesman");

                    b.Property<int>("Status");

                    b.Property<string>("TaxId1")
                        .IsRequired();

                    b.Property<string>("TaxId2");

                    b.Property<string>("TaxId3");

                    b.Property<string>("TradingName");

                    b.Property<int>("TransporterId");

                    b.Property<int>("Type");

                    b.Property<Guid>("UUID");

                    b.Property<DateTime?>("UpdateAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int>("UserIdProper");

                    b.Property<int>("UserIdUpdate");

                    b.Property<DateTime?>("ValidUntil");

                    b.Property<int>("VisOrder");

                    b.Property<bool>("ZonaFranca");

                    b.HasKey("Id", "FatherId");

                    b.HasIndex("CardCode")
                        .IsUnique();

                    b.HasIndex("Code")
                        .IsUnique()
                        .HasFilter("[Code] IS NOT NULL");

                    b.HasIndex("UUID")
                        .IsUnique();

                    b.ToTable("BPART0");
                });
#pragma warning restore 612, 618
        }
    }
}
