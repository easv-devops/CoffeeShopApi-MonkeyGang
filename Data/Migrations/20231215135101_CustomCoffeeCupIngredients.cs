using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class CustomCoffeeCupIngredients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomCoffeeCups",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomCoffeeCups", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_CustomCoffeeCups_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomCoffeeCupIngredients",
                columns: table => new
                {
                    CustomCoffeeCupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IngredientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomCoffeeCupIngredients", x => new { x.CustomCoffeeCupId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_CustomCoffeeCupIngredients_CustomCoffeeCups_CustomCoffeeCupId",
                        column: x => x.CustomCoffeeCupId,
                        principalTable: "CustomCoffeeCups",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomCoffeeCupIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomCoffeeCupIngredients_IngredientId",
                table: "CustomCoffeeCupIngredients",
                column: "IngredientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomCoffeeCupIngredients");

            migrationBuilder.DropTable(
                name: "CustomCoffeeCups");
        }
    }
}
