using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealCraft.Models;

public class Recipe
{
    public int Id { get; set; }

    [Required, StringLength(100)]
    public string Title { get; set; } = string.Empty;

    [StringLength(500)]
    public string Description { get; set; } = string.Empty;

    [Range(0, 1440)]
    public int PrepMinutes { get; set; }

    [Range(0, 1440)]
    public int CookMinutes { get; set; }

    [Range(1, 100)]
    public int Servings { get; set; } = 1;

    [Required]
    public string RecipeInstructions { get; set; } = string.Empty;

    public string UserId { get; set; } = string.Empty;
    public ApplicationUser User { get; set; } = null!;

    public List<Ingredient> Ingredients { get; set; } = new();
    public List<RecipeTag> RecipeTags { get; set; } = new();
    public List<PlannedMeal> PlannedMeals { get; set; } = new();

    [NotMapped]
    public List<string> Tags
    {
        get => RecipeTags.Select(tag => tag.TagName).ToList();
        set => RecipeTags = value.Select(tag => new RecipeTag { TagName = tag }).ToList();
    }

    [NotMapped]
    public string Instructions
    {
        get => RecipeInstructions;
        set => RecipeInstructions = value;
    }

    [NotMapped]
    public int PrepTimeMinutes
    {
        get => PrepMinutes;
        set => PrepMinutes = value;
    }

    [NotMapped]
    public int CookTimeMinutes
    {
        get => CookMinutes;
        set => CookMinutes = value;
    }
}
