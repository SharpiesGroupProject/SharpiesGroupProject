namespace MealCraft.Models;

public class MealPlan
{
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;
    public DateTime WeekStartDate { get; set; }
    public bool IsActive { get; set; }

    public ApplicationUser User { get; set; } = null!;
    public List<PlannedMeal> PlannedMeals { get; set; } = new();
    public List<GroceryListItem> GroceryListItems { get; set; } = new();
}
