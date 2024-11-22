using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesTaxesApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductTypeSeedidng : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "productTypeId",
                keyValue: 1,
                column: "isExempt",
                value: true);

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "productTypeId",
                keyValue: 2,
                column: "isExempt",
                value: true);

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "productTypeId",
                keyValue: 3,
                column: "isExempt",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "productTypeId",
                keyValue: 1,
                column: "isExempt",
                value: false);

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "productTypeId",
                keyValue: 2,
                column: "isExempt",
                value: false);

            migrationBuilder.UpdateData(
                table: "ProductType",
                keyColumn: "productTypeId",
                keyValue: 3,
                column: "isExempt",
                value: false);
        }
    }
}
