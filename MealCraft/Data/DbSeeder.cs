using MealCraft.Models;
using Microsoft.EntityFrameworkCore;

namespace MealCraft.Data;

public static class DbSeeder
{
    public const string DemoName = "DemoUser";
    public const string DemoEmail = "demo@mealcraft.local";

    public static async Task SeedAsync(
        MealCraftDbContext context,
        CancellationToken cancellationToken = default)
    {
        if (context.Database.IsRelational())
        {
            await context.Database.MigrateAsync(cancellationToken);
        }

        if (await context.Users.AnyAsync(cancellationToken)
            || await context.Recipes.AnyAsync(cancellationToken)
            || await context.RecipeTags.AnyAsync(cancellationToken)
            || await context.RecipeIngredients.AnyAsync(cancellationToken)
            || await context.MealPlans.AnyAsync(cancellationToken)
            || await context.PlannedMeals.AnyAsync(cancellationToken)
            || await context.GroceryListItems.AnyAsync(cancellationToken)
            || await context.GroceryItemSources.AnyAsync(cancellationToken))
        {
            return;
        }

        var user = new ApplicationUser
        {
            UserName = DemoName,
            NormalizedUserName = DemoName.ToUpperInvariant(),
            Email = DemoEmail,
            NormalizedEmail = DemoEmail.ToUpperInvariant(),
            EmailConfirmed = true
        };

        var recipe = new Recipe
        {
            Title = "Tomato Basil Pasta",
            Description = "A quick pasta with cherry tomatoes and fresh basil.",
            PrepMinutes = 10,
            CookMinutes = 20,
            Servings = 4,
            RecipeInstructions = "Cook the pasta.\nSaute the tomatoes in olive oil until softened.\nToss with the pasta and finish with fresh basil.",
            User = user,
            RecipeTags =
            [
                new RecipeTag { TagName = "Dinner" },
                new RecipeTag { TagName = "Vegetarian" }
            ],
            Ingredients =
            [
                new Ingredient { Name = "Pasta", Quantity = 400, Unit = "g", DisplayOrder = 1 },
                new Ingredient { Name = "Cherry tomatoes", Quantity = 250, Unit = "g", DisplayOrder = 2 },
                new Ingredient { Name = "Olive oil", Quantity = 2, Unit = "tbsp", DisplayOrder = 3 },
                new Ingredient { Name = "Fresh basil", Quantity = 10, Unit = "leaves", DisplayOrder = 4 }
            ]
        };

        var today = DateTime.UtcNow.Date;
        var weekStart = today.AddDays(-(((int)today.DayOfWeek + 6) % 7));
        var plannedMeal = new PlannedMeal
        {
            Recipe = recipe,
            MealDate = weekStart,
            MealType = "Dinner"
        };
        var mealPlan = new MealPlan
        {
            User = user,
            WeekStartDate = weekStart,
            IsActive = true,
            PlannedMeals = [plannedMeal]
        };

        foreach (var ingredient in recipe.Ingredients)
        {
            var groceryItem = new GroceryListItem
            {
                MealPlan = mealPlan,
                CreatedAt = DateTime.UtcNow,
                Name = ingredient.Name,
                Quantity = ingredient.Quantity,
                Unit = ingredient.Unit,
                SourceType = "MealPlan",
                IsPurchased = false
            };

            groceryItem.Sources.Add(new GroceryItemSource
            {
                GroceryListItem = groceryItem,
                PlannedMeal = plannedMeal,
                RecipeIngredient = ingredient,
                Quantity = ingredient.Quantity,
                Unit = ingredient.Unit
            });

            mealPlan.GroceryListItems.Add(groceryItem);
        }

        user.Recipes.Add(recipe);
        user.MealPlans.Add(mealPlan);

        context.Users.Add(user);
        await context.SaveChangesAsync(cancellationToken);
    }
}
