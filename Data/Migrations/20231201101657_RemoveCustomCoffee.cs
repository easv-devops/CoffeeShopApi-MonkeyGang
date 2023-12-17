using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCustomCoffee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomCoffeeCups");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "CoffeeCups",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeCups_CustomerId",
                table: "CoffeeCups",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeCups_Customers_CustomerId",
                table: "CoffeeCups",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeCups_Customers_CustomerId",
                table: "CoffeeCups");

            migrationBuilder.DropIndex(
                name: "IX_CoffeeCups_CustomerId",
                table: "CoffeeCups");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "CoffeeCups");

            migrationBuilder.CreateTable(
                name: "CustomCoffeeCups",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomCoffeeCups", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_CustomCoffeeCups_CoffeeCups_ItemId",
                        column: x => x.ItemId,
                        principalTable: "CoffeeCups",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomCoffeeCups_Customers_UserId",
                        column: x => x.UserId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomCoffeeCups_UserId",
                table: "CustomCoffeeCups",
                column: "UserId");
        }
    }
}
