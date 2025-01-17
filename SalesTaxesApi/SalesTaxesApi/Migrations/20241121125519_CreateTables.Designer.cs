﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SalesTaxesApi.DbContexts;

#nullable disable

namespace SalesTaxesApi.Migrations
{
    [DbContext(typeof(SalesTaxesDBContext))]
    [Migration("20241121125519_CreateTables")]
    partial class CreateTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("SalesTaxesApi.Models.MyUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAdminUser")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("SalesTaxesApi.Models.Product", b =>
                {
                    b.Property<int>("productId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("productId"));

                    b.Property<DateTime?>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("deleted_at")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isImported")
                        .HasColumnType("bit");

                    b.Property<bool?>("isdeleted")
                        .HasColumnType("bit");

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("productTypeId")
                        .HasColumnType("int");

                    b.Property<decimal>("quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("unitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("productId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("SalesTaxesApi.Models.ProductType", b =>
                {
                    b.Property<int>("productTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("productTypeId"));

                    b.Property<DateTime?>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("deleted_at")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<bool?>("isExempt")
                        .HasColumnType("bit");

                    b.Property<string>("productTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("productTypeId");

                    b.ToTable("ProductType");
                });

            modelBuilder.Entity("SalesTaxesApi.Models.Receipt", b =>
                {
                    b.Property<int>("receiptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("receiptId"));

                    b.Property<DateTime?>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("deleted_at")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("totalCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("totalTaxes")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("receiptId");

                    b.ToTable("Receipt");
                });

            modelBuilder.Entity("SalesTaxesApi.Models.ReceiptItem", b =>
                {
                    b.Property<int>("receiptItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("receiptItemId"));

                    b.Property<DateTime?>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("deleted_at")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("itemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("itemPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("priceIncludingTax")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("receiptId")
                        .HasColumnType("int");

                    b.Property<decimal>("taxAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("receiptItemId");

                    b.HasIndex("receiptId");

                    b.ToTable("ReceiptItem");
                });

            modelBuilder.Entity("SalesTaxesApi.Models.TaxType", b =>
                {
                    b.Property<int>("taxTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("taxTypeId"));

                    b.Property<DateTime?>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("deleted_at")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("taxName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("taxTypeId");

                    b.ToTable("TaxType");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SalesTaxesApi.Models.MyUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SalesTaxesApi.Models.MyUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SalesTaxesApi.Models.MyUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SalesTaxesApi.Models.MyUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SalesTaxesApi.Models.ReceiptItem", b =>
                {
                    b.HasOne("SalesTaxesApi.Models.Receipt", null)
                        .WithMany("ReceiptItems")
                        .HasForeignKey("receiptId");
                });

            modelBuilder.Entity("SalesTaxesApi.Models.Receipt", b =>
                {
                    b.Navigation("ReceiptItems");
                });
#pragma warning restore 612, 618
        }
    }
}
