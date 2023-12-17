using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveStoreIngredient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Stores_StoreId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_StoreId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Ingredients");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StoreId",
                table: "Ingredients",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_StoreId",
                table: "Ingredients",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Stores_StoreId",
                table: "Ingredients",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreId");
        }
    }
}
