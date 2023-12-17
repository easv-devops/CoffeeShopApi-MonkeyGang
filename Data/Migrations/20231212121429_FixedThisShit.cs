using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class FixedThisShit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_CoffeeCups_CoffeeCupItemId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_CoffeeCupItemId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "CoffeeCupItemId",
                table: "Ingredients");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CoffeeCupItemId",
                table: "Ingredients",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_CoffeeCupItemId",
                table: "Ingredients",
                column: "CoffeeCupItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_CoffeeCups_CoffeeCupItemId",
                table: "Ingredients",
                column: "CoffeeCupItemId",
                principalTable: "CoffeeCups",
                principalColumn: "ItemId");
        }
    }
}
