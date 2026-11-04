using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealCraft.Models;

[Table("RecipeIngredient")]
public class Ingredient
{
    public int Id { get; set; }
    public int RecipeId { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Range(0, double.MaxValue)]
    public decimal Quantity { get; set; }

    public string Unit { get; set; } = string.Empty;
    public int DisplayOrder { get; set; }

    public Recipe Recipe { get; set; } = null!;
    public List<GroceryItemSource> GroceryItemSources { get; set; } = new();
}
