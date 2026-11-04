namespace MealCraft.Models;

public class PlannedMeal
{
    public int Id { get; set; }
    public int MealPlanId { get; set; }
    public int RecipeId { get; set; }
    public DateTime MealDate { get; set; }
    public string MealType { get; set; } = string.Empty;

    public MealPlan MealPlan { get; set; } = null!;
    public Recipe Recipe { get; set; } = null!;
    public List<GroceryItemSource> GroceryItemSources { get; set; } = new();
}
