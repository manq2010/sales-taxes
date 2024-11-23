using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesTaxesApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateReceiptItemColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "productTypeId",
                table: "ReceiptItem",
                newName: "productTypeName");

            migrationBuilder.RenameColumn(
                name: "itemId",
                table: "ReceiptItem",
                newName: "itemName");

            migrationBuilder.AddColumn<bool>(
                name: "isExempted",
                table: "ReceiptItem",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isImported",
                table: "ReceiptItem",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isExempted",
                table: "ReceiptItem");

            migrationBuilder.DropColumn(
                name: "isImported",
                table: "ReceiptItem");

            migrationBuilder.RenameColumn(
                name: "productTypeName",
                table: "ReceiptItem",
                newName: "productTypeId");

            migrationBuilder.RenameColumn(
                name: "itemName",
                table: "ReceiptItem",
                newName: "itemId");
        }
    }
}
