using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesTaxesApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateReceiptColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "receiptName",
                table: "Receipt",
                newName: "clientName");

            migrationBuilder.RenameColumn(
                name: "aspUserId",
                table: "Receipt",
                newName: "clientEmail");

            migrationBuilder.UpdateData(
                table: "Receipt",
                keyColumn: "receiptId",
                keyValue: 1,
                columns: new[] { "clientEmail", "clientName" },
                values: new object[] { "willing@trader.com", "Willing Trader" });

            migrationBuilder.UpdateData(
                table: "Receipt",
                keyColumn: "receiptId",
                keyValue: 2,
                columns: new[] { "clientEmail", "clientName" },
                values: new object[] { "test@driving.com", "Test Driving" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "clientName",
                table: "Receipt",
                newName: "receiptName");

            migrationBuilder.RenameColumn(
                name: "clientEmail",
                table: "Receipt",
                newName: "aspUserId");

            migrationBuilder.UpdateData(
                table: "Receipt",
                keyColumn: "receiptId",
                keyValue: 1,
                columns: new[] { "aspUserId", "receiptName" },
                values: new object[] { "", "Local Only Shopping" });

            migrationBuilder.UpdateData(
                table: "Receipt",
                keyColumn: "receiptId",
                keyValue: 2,
                columns: new[] { "aspUserId", "receiptName" },
                values: new object[] { "", "LocaL and International Shopping" });
        }
    }
}
