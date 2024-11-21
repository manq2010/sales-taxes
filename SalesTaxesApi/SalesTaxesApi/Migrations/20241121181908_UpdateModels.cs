using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesTaxesApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isdeleted",
                table: "Product",
                newName: "isDeleted");

            migrationBuilder.AddColumn<int>(
                name: "productId",
                table: "ProductType",
                type: "int",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "isDeleted",
                table: "Product",
                newName: "isdeleted");
        }
    }
}
