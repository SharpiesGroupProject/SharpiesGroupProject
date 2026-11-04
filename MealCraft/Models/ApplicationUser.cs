using System.ComponentModel.DataAnnotations;

namespace MealCraft.Models;

public class ApplicationUser
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;

    public List<Recipe> Recipes { get; set; } = new();
    public List<MealPlan> MealPlans { get; set; } = new();
}
