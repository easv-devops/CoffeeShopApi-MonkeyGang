using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class CoffeeCupStoreMtM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoffeeCupStores",
                columns: table => new
                {
                    CoffeeCupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoffeeCupStoreCoffeeCupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CoffeeCupStoreStoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeeCupStores", x => new { x.CoffeeCupId, x.StoreId });
                    table.ForeignKey(
                        name: "FK_CoffeeCupStores_CoffeeCupStores_CoffeeCupStoreCoffeeCupId_CoffeeCupStoreStoreId",
                        columns: x => new { x.CoffeeCupStoreCoffeeCupId, x.CoffeeCupStoreStoreId },
                        principalTable: "CoffeeCupStores",
                        principalColumns: new[] { "CoffeeCupId", "StoreId" });
                    table.ForeignKey(
                        name: "FK_CoffeeCupStores_CoffeeCups_CoffeeCupId",
                        column: x => x.CoffeeCupId,
                        principalTable: "CoffeeCups",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoffeeCupStores_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeCupStores_CoffeeCupStoreCoffeeCupId_CoffeeCupStoreStoreId",
                table: "CoffeeCupStores",
                columns: new[] { "CoffeeCupStoreCoffeeCupId", "CoffeeCupStoreStoreId" });

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeCupStores_StoreId",
                table: "CoffeeCupStores",
                column: "StoreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoffeeCupStores");
        }
    }
}
