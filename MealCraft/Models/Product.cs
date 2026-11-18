using System.ComponentModel.DataAnnotations;

namespace MealCraft.Models;

public class Product
{
    public int Id { get; set; }

    [Required, StringLength(120)]
    public string Name { get; set; } = string.Empty;

    [StringLength(50)]
    public string? DefaultUnit { get; set; }

    [StringLength(50)]
    public string? Category { get; set; }

    public List<Ingredient> RecipeIngredients { get; set; } = new();
    public List<GroceryListItem> GroceryListItems { get; set; } = new();
}
