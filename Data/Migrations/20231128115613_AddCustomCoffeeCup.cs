using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomCoffeeCup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "size",
                table: "CoffeeCups",
                newName: "Size");

            migrationBuilder.AddColumn<bool>(
                name: "IsOnMenu",
                table: "Item",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomCoffeeCups");

            migrationBuilder.DropColumn(
                name: "IsOnMenu",
                table: "Item");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "CoffeeCups",
                newName: "size");
        }
    }
}
