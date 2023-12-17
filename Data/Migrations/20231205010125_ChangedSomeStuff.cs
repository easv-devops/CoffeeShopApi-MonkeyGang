using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedSomeStuff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cakes_Item_ItemId",
                table: "Cakes");

            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeBeans_Item_ItemId",
                table: "CoffeeBeans");

            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeCups_Item_ItemId",
                table: "CoffeeCups");

            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeCups_Stores_StoreId",
                table: "CoffeeCups");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Item_ItemId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Item_ItemId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_CoffeeCups_StoreId",
                table: "CoffeeCups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "CoffeeCups");

            migrationBuilder.RenameTable(
                name: "Item",
                newName: "Items");

            migrationBuilder.AddColumn<Guid>(
                name: "StoreId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_StoreId",
                table: "Items",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cakes_Items_ItemId",
                table: "Cakes",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeBeans_Items_ItemId",
                table: "CoffeeBeans",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeCups_Items_ItemId",
                table: "CoffeeCups",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Stores_StoreId",
                table: "Items",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Items_ItemId",
                table: "OrderDetails",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Items_ItemId",
                table: "Posts",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cakes_Items_ItemId",
                table: "Cakes");

            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeBeans_Items_ItemId",
                table: "CoffeeBeans");

            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeCups_Items_ItemId",
                table: "CoffeeCups");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Stores_StoreId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Items_ItemId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Items_ItemId",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_StoreId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Items");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "Item");

            migrationBuilder.AddColumn<Guid>(
                name: "StoreId",
                table: "CoffeeCups",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeCups_StoreId",
                table: "CoffeeCups",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cakes_Item_ItemId",
                table: "Cakes",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeBeans_Item_ItemId",
                table: "CoffeeBeans",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeCups_Item_ItemId",
                table: "CoffeeCups",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoffeeCups_Stores_StoreId",
                table: "CoffeeCups",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Item_ItemId",
                table: "OrderDetails",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Item_ItemId",
                table: "Posts",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
