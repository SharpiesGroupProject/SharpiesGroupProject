namespace MealCraft.Models;

public class StandaloneGroceryItem
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Quantity { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public bool IsPurchased { get; set; }
}
