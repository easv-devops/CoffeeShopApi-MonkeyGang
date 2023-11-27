using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class RefactoredModels2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeCupIngredients_CoffeeCup_CoffeeCupId",
                table: "CoffeeCupIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoffeeCupIngredients",
                table: "CoffeeCupIngredients");

            migrationBuilder.DropIndex(
                name: "IX_CoffeeCupIngredients_CoffeeCupId",
                table: "CoffeeCupIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoffeeCup",
                table: "CoffeeCup");

            migrationBuilder.DropColumn(
                name: "CoffeeCupIngredientId",
                table: "CoffeeCupIngredients");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CoffeeCup",
                newName: "ItemId");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "CoffeeCupIngredients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "CoffeeCupId",
                table: "CoffeeCup",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "ItemType",
                table: "CoffeeCup",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "size",
                table: "CoffeeCup",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoffeeCupIngredients",
                table: "CoffeeCupIngredients",
                columns: new[] { "CoffeeCupId", "IngredientId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoffeeCup",
                table: "CoffeeCup",
                column: "CoffeeCupId");

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeCupIngredients_CoffeeCup_CoffeeCupId",
                table: "CoffeeCupIngredients",
                column: "CoffeeCupId",
                principalTable: "CoffeeCup",
                principalColumn: "CoffeeCupId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeCupIngredients_CoffeeCup_CoffeeCupId",
                table: "CoffeeCupIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoffeeCupIngredients",
                table: "CoffeeCupIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoffeeCup",
                table: "CoffeeCup");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "CoffeeCupIngredients");

            migrationBuilder.DropColumn(
                name: "CoffeeCupId",
                table: "CoffeeCup");

            migrationBuilder.DropColumn(
                name: "ItemType",
                table: "CoffeeCup");

            migrationBuilder.DropColumn(
                name: "size",
                table: "CoffeeCup");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "CoffeeCup",
                newName: "Id");

            migrationBuilder.AddColumn<Guid>(
                name: "CoffeeCupIngredientId",
                table: "CoffeeCupIngredients",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoffeeCupIngredients",
                table: "CoffeeCupIngredients",
                column: "CoffeeCupIngredientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoffeeCup",
                table: "CoffeeCup",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeCupIngredients_CoffeeCupId",
                table: "CoffeeCupIngredients",
                column: "CoffeeCupId");

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeCupIngredients_CoffeeCup_CoffeeCupId",
                table: "CoffeeCupIngredients",
                column: "CoffeeCupId",
                principalTable: "CoffeeCup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
