using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesTaxesApi.Migrations
{
    /// <inheritdoc />
    public partial class UddColumnProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isExempt",
                table: "Product",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "productId",
                keyValue: 1,
                column: "isExempt",
                value: true);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "productId",
                keyValue: 2,
                column: "isExempt",
                value: false);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "productId",
                keyValue: 3,
                column: "isExempt",
                value: true);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "productId",
                keyValue: 4,
                column: "isExempt",
                value: true);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "productId",
                keyValue: 5,
                column: "isExempt",
                value: false);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "productId",
                keyValue: 6,
                column: "isExempt",
                value: false);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "productId",
                keyValue: 7,
                column: "isExempt",
                value: false);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "productId",
                keyValue: 8,
                column: "isExempt",
                value: true);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "productId",
                keyValue: 9,
                column: "isExempt",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isExempt",
                table: "Product");
        }
    }
}
