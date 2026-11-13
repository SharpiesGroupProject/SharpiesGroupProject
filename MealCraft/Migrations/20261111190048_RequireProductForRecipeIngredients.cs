using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealCraft.Migrations
{
    /// <inheritdoc />
    public partial class RequireProductForRecipeIngredients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Create missing product records for existing recipe ingredients
            // that do not have a ProductId.
            migrationBuilder.Sql("""
                INSERT INTO Products (Name)
                SELECT DISTINCT ri.Name
                FROM RecipeIngredient ri
                WHERE ri.ProductId IS NULL
                AND NOT EXISTS (
                    SELECT 1
                    FROM Products p
                    WHERE p.Name = ri.Name
                );
                """);

            // Associate existing recipe ingredients with their products.
            migrationBuilder.Sql("""
                UPDATE RecipeIngredient
                SET ProductId = (
                    SELECT p.Id
                    FROM Products p
                    WHERE p.Name = RecipeIngredient.Name
                    ORDER BY p.Id
                    LIMIT 1
                )
                WHERE ProductId IS NULL;
                """);

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredient_Products_ProductId",
                table: "RecipeIngredient");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "RecipeIngredient",
                type: "INTEGER",
                nullable: false,              
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredient_Products_ProductId",
                table: "RecipeIngredient",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredient_Products_ProductId",
                table: "RecipeIngredient");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "RecipeIngredient",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredient_Products_ProductId",
                table: "RecipeIngredient",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
