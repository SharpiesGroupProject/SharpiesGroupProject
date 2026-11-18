using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealCraft.Migrations
{
    /// <inheritdoc />
    public partial class AddProductCatalog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroceryItemSources_PlannedMeals_PlannedMealId",
                table: "GroceryItemSources");

            migrationBuilder.DropForeignKey(
                name: "FK_GroceryItemSources_RecipeIngredient_RecipeIngredientId",
                table: "GroceryItemSources");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "RecipeIngredient",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "GroceryListItems",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RecipeIngredientId",
                table: "GroceryItemSources",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "PlannedMealId",
                table: "GroceryItemSources",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    DefaultUnit = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Category = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredient_ProductId",
                table: "RecipeIngredient",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_GroceryListItems_ProductId",
                table: "GroceryListItems",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroceryItemSources_PlannedMeals_PlannedMealId",
                table: "GroceryItemSources",
                column: "PlannedMealId",
                principalTable: "PlannedMeals",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_GroceryItemSources_RecipeIngredient_RecipeIngredientId",
                table: "GroceryItemSources",
                column: "RecipeIngredientId",
                principalTable: "RecipeIngredient",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_GroceryListItems_Products_ProductId",
                table: "GroceryListItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredient_Products_ProductId",
                table: "RecipeIngredient",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroceryItemSources_PlannedMeals_PlannedMealId",
                table: "GroceryItemSources");

            migrationBuilder.DropForeignKey(
                name: "FK_GroceryItemSources_RecipeIngredient_RecipeIngredientId",
                table: "GroceryItemSources");

            migrationBuilder.DropForeignKey(
                name: "FK_GroceryListItems_Products_ProductId",
                table: "GroceryListItems");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredient_Products_ProductId",
                table: "RecipeIngredient");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropIndex(
                name: "IX_RecipeIngredient_ProductId",
                table: "RecipeIngredient");

            migrationBuilder.DropIndex(
                name: "IX_GroceryListItems_ProductId",
                table: "GroceryListItems");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "RecipeIngredient");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "GroceryListItems");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeIngredientId",
                table: "GroceryItemSources",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlannedMealId",
                table: "GroceryItemSources",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GroceryItemSources_PlannedMeals_PlannedMealId",
                table: "GroceryItemSources",
                column: "PlannedMealId",
                principalTable: "PlannedMeals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroceryItemSources_RecipeIngredient_RecipeIngredientId",
                table: "GroceryItemSources",
                column: "RecipeIngredientId",
                principalTable: "RecipeIngredient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
