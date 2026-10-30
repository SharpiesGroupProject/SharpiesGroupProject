using System.ComponentModel.DataAnnotations;

namespace MealCraft.Models;

// Plain POCOs so they can be mapped by EF Core later.
public class Recipe
{
    public int Id { get; set; }

    [Required, StringLength(100)]
    public string Title { get; set; } = string.Empty;

    [StringLength(500)]
    public string Description { get; set; } = string.Empty;

    public List<string> Tags { get; set; } = new();

    [Range(0, 1440)]
    public int PrepTimeMinutes { get; set; }

    [Range(0, 1440)]
    public int CookTimeMinutes { get; set; }

    [Range(1, 100)]
    public int Servings { get; set; } = 1;

    public List<Ingredient> Ingredients { get; set; } = new();

    [Required]
    public string Instructions { get; set; } = string.Empty;
}

public class Ingredient
{
    public int Id { get; set; }
    public decimal Quantity { get; set; }
    public string Unit { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}
