using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SalesTaxesApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateReceiptAddSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "aspUserId",
                table: "Receipt",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "receiptName",
                table: "Receipt",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "productId", "created_at", "deleted_at", "isDeleted", "isImport", "productName", "unitPrice", "updated_at" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Book", 12.49m, new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Music CD", 14.99m, new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Chocolate Bar", 0.85m, new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Box of Chocolates", 10.00m, new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Bottle of Perfume", 47.50m, new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Bottle of Perfume", 27.99m, new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Bottle of Perfume", 18.99m, new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Packet of paracetamol", 9.75m, new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Box of Chocolates", 11.25m, new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Receipt",
                columns: new[] { "receiptId", "aspUserId", "created_at", "deleted_at", "isDeleted", "receiptName", "totalCost", "totalTaxes", "updated_at" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), false, "Local Only Shopping", 0m, 0m, new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "", new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), false, "LocaL and International Shopping", 0m, 0m, new DateTime(2024, 11, 20, 12, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Receipt",
                keyColumn: "receiptId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Receipt",
                keyColumn: "receiptId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "aspUserId",
                table: "Receipt");

            migrationBuilder.DropColumn(
                name: "receiptName",
                table: "Receipt");
        }
    }
}
