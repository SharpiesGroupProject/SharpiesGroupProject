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
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredient_Products_ProductId",
                table: "RecipeIngredient");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "RecipeIngredient",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
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
