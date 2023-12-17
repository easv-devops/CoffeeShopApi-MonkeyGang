using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCoffeeCupStoreSelfReference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeCupStores_CoffeeCupStores_CoffeeCupStoreCoffeeCupId_CoffeeCupStoreStoreId",
                table: "CoffeeCupStores");

            migrationBuilder.DropIndex(
                name: "IX_CoffeeCupStores_CoffeeCupStoreCoffeeCupId_CoffeeCupStoreStoreId",
                table: "CoffeeCupStores");

            migrationBuilder.DropColumn(
                name: "CoffeeCupStoreCoffeeCupId",
                table: "CoffeeCupStores");

            migrationBuilder.DropColumn(
                name: "CoffeeCupStoreStoreId",
                table: "CoffeeCupStores");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CoffeeCupStoreCoffeeCupId",
                table: "CoffeeCupStores",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CoffeeCupStoreStoreId",
                table: "CoffeeCupStores",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeCupStores_CoffeeCupStoreCoffeeCupId_CoffeeCupStoreStoreId",
                table: "CoffeeCupStores",
                columns: new[] { "CoffeeCupStoreCoffeeCupId", "CoffeeCupStoreStoreId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeCupStores_CoffeeCupStores_CoffeeCupStoreCoffeeCupId_CoffeeCupStoreStoreId",
                table: "CoffeeCupStores",
                columns: new[] { "CoffeeCupStoreCoffeeCupId", "CoffeeCupStoreStoreId" },
                principalTable: "CoffeeCupStores",
                principalColumns: new[] { "CoffeeCupId", "StoreId" });
        }
    }
}
