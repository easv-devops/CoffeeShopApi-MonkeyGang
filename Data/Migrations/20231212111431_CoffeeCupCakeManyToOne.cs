using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class CoffeeCupCakeManyToOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CoffeeCupId",
                table: "Cakes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Cakes_CoffeeCupId",
                table: "Cakes",
                column: "CoffeeCupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cakes_CoffeeCups_CoffeeCupId",
                table: "Cakes",
                column: "CoffeeCupId",
                principalTable: "CoffeeCups",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cakes_CoffeeCups_CoffeeCupId",
                table: "Cakes");

            migrationBuilder.DropIndex(
                name: "IX_Cakes_CoffeeCupId",
                table: "Cakes");

            migrationBuilder.DropColumn(
                name: "CoffeeCupId",
                table: "Cakes");
        }
    }
}
