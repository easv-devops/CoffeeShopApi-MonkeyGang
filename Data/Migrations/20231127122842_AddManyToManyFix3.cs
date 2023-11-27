using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddManyToManyFix3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Items_CoffeeCupItemId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_CoffeeCupItemId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "CoffeeCupItemId",
                table: "OrderDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CoffeeCupItemId",
                table: "OrderDetails",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_CoffeeCupItemId",
                table: "OrderDetails",
                column: "CoffeeCupItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Items_CoffeeCupItemId",
                table: "OrderDetails",
                column: "CoffeeCupItemId",
                principalTable: "Items",
                principalColumn: "ItemId");
        }
    }
}
