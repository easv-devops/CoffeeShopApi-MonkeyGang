using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPostItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Orders_OrderId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Posts",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_OrderId",
                table: "Posts",
                newName: "IX_Posts_ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Item_ItemId",
                table: "Posts",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Item_ItemId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "Posts",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_ItemId",
                table: "Posts",
                newName: "IX_Posts_OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Orders_OrderId",
                table: "Posts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
