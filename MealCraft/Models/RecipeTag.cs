using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace MealCraft.Models;

[PrimaryKey(nameof(RecipeId), nameof(TagName))]
public class RecipeTag
{
    public int RecipeId { get; set; }

    [Required, StringLength(50)]
    public string TagName { get; set; } = string.Empty;

    public Recipe Recipe { get; set; } = null!;
}
