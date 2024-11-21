using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SalesTaxesApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductType_Product_productId",
                table: "ProductType");

            migrationBuilder.DropIndex(
                name: "IX_ProductType_productId",
                table: "ProductType");

            migrationBuilder.DropColumn(
                name: "productId",
                table: "ProductType");

            migrationBuilder.DropColumn(
                name: "isImported",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "productTypeId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "quantity",
                table: "Product");

            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "productTypeId", "created_at", "deleted_at", "isDeleted", "isExempt", "productTypeName", "updated_at" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Books", new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Food", new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Medical Products", new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Other", new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "TaxType",
                columns: new[] { "taxTypeId", "created_at", "deleted_at", "isDeleted", "rate", "taxName", "updated_at" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), false, 10m, "Basic Tax", new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), false, 5m, "Import Duty", new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "productTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "productTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "productTypeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "productTypeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TaxType",
                keyColumn: "taxTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TaxType",
                keyColumn: "taxTypeId",
                keyValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "productId",
                table: "ProductType",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isImported",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "productTypeId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "quantity",
                table: "Product",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_ProductType_productId",
                table: "ProductType",
                column: "productId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductType_Product_productId",
                table: "ProductType",
                column: "productId",
                principalTable: "Product",
                principalColumn: "productId");
        }
    }
}
