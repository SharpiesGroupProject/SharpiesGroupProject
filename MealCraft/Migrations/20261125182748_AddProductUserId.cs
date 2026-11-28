using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealCraft.Migrations
{
    /// <inheritdoc />
    public partial class AddProductUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            // The catalog used to be shared, so give every existing user their own copy of
            // each product, repoint their ingredients and grocery items, then drop the shared rows.
            migrationBuilder.Sql("""
                INSERT INTO Products (Name, DefaultUnit, Category, UserId)
                SELECT p.Name, p.DefaultUnit, p.Category, u.Id
                FROM Products p
                CROSS JOIN Users u
                WHERE p.UserId = '';
                """);

            migrationBuilder.Sql("""
                UPDATE RecipeIngredient
                SET ProductId = (
                    SELECT np.Id
                    FROM Products np
                    JOIN Products op ON op.Name = np.Name
                    JOIN Recipes r ON r.UserId = np.UserId
                    WHERE op.Id = RecipeIngredient.ProductId
                    AND r.Id = RecipeIngredient.RecipeId
                    ORDER BY np.Id
                    LIMIT 1
                )
                WHERE ProductId IN (SELECT Id FROM Products WHERE UserId = '');
                """);

            migrationBuilder.Sql("""
                UPDATE GroceryListItems
                SET ProductId = (
                    SELECT np.Id
                    FROM Products np
                    JOIN Products op ON op.Name = np.Name
                    JOIN MealPlans mp ON mp.UserId = np.UserId
                    WHERE op.Id = GroceryListItems.ProductId
                    AND mp.Id = GroceryListItems.MealPlanId
                    ORDER BY np.Id
                    LIMIT 1
                )
                WHERE ProductId IN (SELECT Id FROM Products WHERE UserId = '');
                """);

            migrationBuilder.Sql("DELETE FROM Products WHERE UserId = '';");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserId",
                table: "Products",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_UserId",
                table: "Products",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_UserId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_UserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Products");
        }
    }
}
