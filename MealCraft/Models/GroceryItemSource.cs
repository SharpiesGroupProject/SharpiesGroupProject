namespace MealCraft.Models;

public class GroceryItemSource
{
    public int Id { get; set; }
    public int GroceryListItemId { get; set; }
    public int PlannedMealId { get; set; }
    public int RecipeIngredientId { get; set; }
    public decimal Quantity { get; set; }
    public string Unit { get; set; } = string.Empty;

    public GroceryListItem GroceryListItem { get; set; } = null!;
    public PlannedMeal PlannedMeal { get; set; } = null!;
    public Ingredient RecipeIngredient { get; set; } = null!;
}
