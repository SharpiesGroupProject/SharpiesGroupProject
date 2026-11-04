namespace MealCraft.Models;

public class GroceryListItem
{
    public int Id { get; set; }
    public int MealPlanId { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public string Unit { get; set; } = string.Empty;
    public string SourceType { get; set; } = string.Empty;
    public bool IsPurchased { get; set; }

    public MealPlan MealPlan { get; set; } = null!;
    public List<GroceryItemSource> Sources { get; set; } = new();
}
