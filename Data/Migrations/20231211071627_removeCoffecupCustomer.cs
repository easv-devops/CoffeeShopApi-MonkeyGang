using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class removeCoffecupCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoffeeCups_Customers_CustomerId",
                table: "CoffeeCups");

            migrationBuilder.DropIndex(
                name: "IX_CoffeeCups_CustomerId",
                table: "CoffeeCups");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
