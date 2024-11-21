using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesTaxesApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateReceiptTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptItem_Receipt_receiptId",
                table: "ReceiptItem");

            migrationBuilder.DropColumn(
                name: "itemPrice",
                table: "ReceiptItem");

            migrationBuilder.RenameColumn(
                name: "itemName",
                table: "ReceiptItem",
                newName: "productTypeId");

            migrationBuilder.AlterColumn<int>(
                name: "receiptId",
                table: "ReceiptItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "itemId",
                table: "ReceiptItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "isImport",
                table: "Product",
                type: "bit",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptItem_Receipt_receiptId",
                table: "ReceiptItem",
                column: "receiptId",
                principalTable: "Receipt",
                principalColumn: "receiptId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptItem_Receipt_receiptId",
                table: "ReceiptItem");

            migrationBuilder.DropColumn(
                name: "itemId",
                table: "ReceiptItem");

            migrationBuilder.DropColumn(
                name: "isImport",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "productTypeId",
                table: "ReceiptItem",
                newName: "itemName");

            migrationBuilder.AlterColumn<int>(
                name: "receiptId",
                table: "ReceiptItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<decimal>(
                name: "itemPrice",
                table: "ReceiptItem",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptItem_Receipt_receiptId",
                table: "ReceiptItem",
                column: "receiptId",
                principalTable: "Receipt",
                principalColumn: "receiptId");
        }
    }
}
