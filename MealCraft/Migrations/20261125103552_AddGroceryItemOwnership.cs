using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealCraft.Migrations
{
    /// <inheritdoc />
    public partial class AddGroceryItemOwnership : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerUserId",
                table: "StandaloneGroceryItems",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerUserId",
                table: "GroceryListItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.Sql(
                "UPDATE \"GroceryListItems\" " +
                "SET \"OwnerUserId\" = (" +
                "SELECT \"UserId\" FROM \"MealPlans\" " +
                "WHERE \"MealPlans\".\"Id\" = \"GroceryListItems\".\"MealPlanId\");");

            migrationBuilder.CreateIndex(
                name: "IX_StandaloneGroceryItems_OwnerUserId",
                table: "StandaloneGroceryItems",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GroceryListItems_OwnerUserId",
                table: "GroceryListItems",
                column: "OwnerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroceryListItems_Users_OwnerUserId",
                table: "GroceryListItems",
                column: "OwnerUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StandaloneGroceryItems_Users_OwnerUserId",
                table: "StandaloneGroceryItems",
                column: "OwnerUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroceryListItems_Users_OwnerUserId",
                table: "GroceryListItems");

            migrationBuilder.DropForeignKey(
                name: "FK_StandaloneGroceryItems_Users_OwnerUserId",
                table: "StandaloneGroceryItems");

            migrationBuilder.DropIndex(
                name: "IX_StandaloneGroceryItems_OwnerUserId",
                table: "StandaloneGroceryItems");

            migrationBuilder.DropIndex(
                name: "IX_GroceryListItems_OwnerUserId",
                table: "GroceryListItems");

            migrationBuilder.DropColumn(
                name: "OwnerUserId",
                table: "StandaloneGroceryItems");

            migrationBuilder.DropColumn(
                name: "OwnerUserId",
                table: "GroceryListItems");
        }
    }
}
