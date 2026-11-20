using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealCraft.Migrations
{
    /// <inheritdoc />
    public partial class AddGroceryListDismissal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDismissed",
                table: "GroceryListItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDismissed",
                table: "GroceryListItems");
        }
    }
}
