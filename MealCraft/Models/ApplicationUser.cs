using Microsoft.AspNetCore.Identity;

namespace MealCraft.Models;

public class ApplicationUser : IdentityUser
{
    public List<Recipe> Recipes { get; set; } = new();
    public List<MealPlan> MealPlans { get; set; } = new();
}
