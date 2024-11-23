﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesTaxesApi.Migrations
{
    /// <inheritdoc />
    public partial class RemoveColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "productId",
                table: "ReceiptItem");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "productId",
                table: "ReceiptItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}