using Microsoft.AspNetCore.Identity;

namespace MealCraft.Models;

public class ApplicationUser : IdentityUser
{
    public List<Recipe> Recipes { get; set; } = new();
    public List<MealPlan> MealPlans { get; set; } = new();
    public List<GroceryListItem> GroceryListItems { get; set; } = new();
    public List<StandaloneGroceryItem> StandaloneGroceryItems { get; set; } = new();
    public List<Product> Products { get; set; } = new();
}
