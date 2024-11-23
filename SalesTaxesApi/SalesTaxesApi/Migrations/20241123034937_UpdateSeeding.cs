using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesTaxesApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "productId",
                keyValue: 3,
                column: "productName",
                value: "Chocolate bar");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "productId",
                keyValue: 4,
                column: "productName",
                value: " Imported box of chocolates");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "productId",
                keyValue: 5,
                column: "productName",
                value: "Imported bottle of perfume");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "productId",
                keyValue: 6,
                column: "productName",
                value: "Imported bottle of perfume");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "productId",
                keyValue: 7,
                column: "productName",
                value: "Bottle of perfume");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "productId",
                keyValue: 8,
                column: "productName",
                value: "Packet of headache pills");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "productId",
                keyValue: 9,
                column: "productName",
                value: "Imported box of chocolates");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "productId",
                keyValue: 3,
                column: "productName",
                value: "Chocolate Bar");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "productId",
                keyValue: 4,
                column: "productName",
                value: "Box of Chocolates");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "productId",
                keyValue: 5,
                column: "productName",
                value: "Bottle of Perfume");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "productId",
                keyValue: 6,
                column: "productName",
                value: "Bottle of Perfume");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "productId",
                keyValue: 7,
                column: "productName",
                value: "Bottle of Perfume");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "productId",
                keyValue: 8,
                column: "productName",
                value: "Packet of paracetamol");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "productId",
                keyValue: 9,
                column: "productName",
                value: "Box of Chocolates");
        }
    }
}
