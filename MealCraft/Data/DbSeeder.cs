using MealCraft.Models;
using Microsoft.EntityFrameworkCore;

namespace MealCraft.Data;

public static class DbSeeder
{
    private const string DemoEmail = "demo@mealcraft.local";
    private const string DemoRecipeTitle = "Tomato Basil Pasta";

    public static async Task SeedAsync(
        MealCraftDbContext context,
        CancellationToken cancellationToken = default)
    {
        if (context.Database.IsRelational())
        {
            await context.Database.MigrateAsync(cancellationToken);
        }

        var user = await context.Users
            .SingleOrDefaultAsync(candidate => candidate.Email == DemoEmail, cancellationToken);

        if (user is null)
        {
            user = new ApplicationUser { Email = DemoEmail };
            context.Users.Add(user);
            await context.SaveChangesAsync(cancellationToken);
        }

        var products = new Dictionary<string, Product>(StringComparer.OrdinalIgnoreCase);
        var productDetails = new[]
        {
            (Name: "Pasta", Unit: "g", Category: "Grains"),
            (Name: "Cherry tomatoes", Unit: "g", Category: "Produce"),
            (Name: "Olive oil", Unit: "tbsp", Category: "Pantry"),
            (Name: "Fresh basil", Unit: "leaves", Category: "Produce")
        };

        foreach (var details in productDetails)
        {
            var product = await context.Products
                .FirstOrDefaultAsync(candidate => candidate.Name == details.Name, cancellationToken);

            if (product is null)
            {
                product = new Product
                {
                    Name = details.Name,
                    DefaultUnit = details.Unit,
                    Category = details.Category
                };
                context.Products.Add(product);
            }

            products.Add(details.Name, product);
        }

        await context.SaveChangesAsync(cancellationToken);

        var recipe = await context.Recipes
            .Include(candidate => candidate.Ingredients)
            .Include(candidate => candidate.RecipeTags)
            .SingleOrDefaultAsync(
                candidate => candidate.UserId == user.Id && candidate.Title == DemoRecipeTitle,
                cancellationToken);

        if (recipe is null)
        {
            recipe = new Recipe
            {
                Title = DemoRecipeTitle,
                Description = "A quick pasta with cherry tomatoes and fresh basil.",
                PrepMinutes = 10,
                CookMinutes = 20,
                Servings = 4,
                RecipeInstructions = "Cook the pasta. Saute the tomatoes in olive oil until softened. Toss with the pasta and finish with fresh basil.",
                UserId = user.Id,
                RecipeTags =
                [
                    new RecipeTag { TagName = "Dinner" },
                    new RecipeTag { TagName = "Vegetarian" }
                ],
                Ingredients =
                [
                    new Ingredient { Name = "Pasta", Quantity = 400, Unit = "g", DisplayOrder = 1, Product = products["Pasta"] },
                    new Ingredient { Name = "Cherry tomatoes", Quantity = 250, Unit = "g", DisplayOrder = 2, Product = products["Cherry tomatoes"] },
                    new Ingredient { Name = "Olive oil", Quantity = 2, Unit = "tbsp", DisplayOrder = 3, Product = products["Olive oil"] },
                    new Ingredient { Name = "Fresh basil", Quantity = 10, Unit = "leaves", DisplayOrder = 4, Product = products["Fresh basil"] }
                ]
            };

            context.Recipes.Add(recipe);
        }
        else
        {
            var seededIngredients = new[]
            {
                (Name: "Pasta", Quantity: 400m, Unit: "g", ProductName: "Pasta", Order: 1),
                (Name: "Cherry tomatoes", Quantity: 250m, Unit: "g", ProductName: "Cherry tomatoes", Order: 2),
                (Name: "Olive oil", Quantity: 2m, Unit: "tbsp", ProductName: "Olive oil", Order: 3),
                (Name: "Fresh basil", Quantity: 10m, Unit: "leaves", ProductName: "Fresh basil", Order: 4)
            };

            foreach (var details in seededIngredients)
            {
                var ingredient = recipe.Ingredients
                    .FirstOrDefault(candidate => candidate.Name == details.Name);

                if (ingredient is null)
                {
                    recipe.Ingredients.Add(new Ingredient
                    {
                        Name = details.Name,
                        Quantity = details.Quantity,
                        Unit = details.Unit,
                        DisplayOrder = details.Order,
                        Product = products[details.ProductName]
                    });
                }
                else if (ingredient.ProductId is null)
                {
                    ingredient.Product = products[details.ProductName];
                }
            }

            foreach (var tagName in new[] { "Dinner", "Vegetarian" })
            {
                if (!recipe.RecipeTags.Any(tag => tag.TagName == tagName))
                {
                    recipe.RecipeTags.Add(new RecipeTag { TagName = tagName });
                }
            }
        }

        await context.SaveChangesAsync(cancellationToken);

        var today = DateTime.UtcNow.Date;
        var weekStart = today.AddDays(-(((int)today.DayOfWeek + 6) % 7));
        var mealPlan = await context.MealPlans
            .SingleOrDefaultAsync(
                plan => plan.UserId == user.Id && plan.WeekStartDate == weekStart,
                cancellationToken);

        if (mealPlan is null)
        {
            mealPlan = new MealPlan
            {
                UserId = user.Id,
                WeekStartDate = weekStart,
                IsActive = true
            };
            context.MealPlans.Add(mealPlan);
            await context.SaveChangesAsync(cancellationToken);
        }

        var plannedMeal = await context.PlannedMeals
            .SingleOrDefaultAsync(
                meal => meal.MealPlanId == mealPlan.Id
                    && meal.RecipeId == recipe.Id
                    && meal.MealDate == weekStart
                    && meal.MealType == "Dinner",
                cancellationToken);

        if (plannedMeal is null)
        {
            plannedMeal = new PlannedMeal
            {
                MealPlanId = mealPlan.Id,
                RecipeId = recipe.Id,
                MealDate = weekStart,
                MealType = "Dinner"
            };
            context.PlannedMeals.Add(plannedMeal);
            await context.SaveChangesAsync(cancellationToken);
        }

        foreach (var ingredient in recipe.Ingredients)
        {
            var groceryItem = await context.GroceryListItems
                .Include(item => item.Sources)
                .FirstOrDefaultAsync(
                    item => item.MealPlanId == mealPlan.Id
                        && item.Name == ingredient.Name
                        && item.Unit == ingredient.Unit
                        && item.ProductId == ingredient.ProductId,
                    cancellationToken);

            if (groceryItem is null)
            {
                groceryItem = new GroceryListItem
                {
                    MealPlanId = mealPlan.Id,
                    ProductId = ingredient.ProductId,
                    CreatedAt = DateTime.UtcNow,
                    Name = ingredient.Name,
                    Quantity = ingredient.Quantity,
                    Unit = ingredient.Unit,
                    SourceType = "MealPlan",
                    IsPurchased = false
                };
                context.GroceryListItems.Add(groceryItem);
            }

            if (!groceryItem.Sources.Any(source =>
                    source.PlannedMealId == plannedMeal.Id
                    && source.RecipeIngredientId == ingredient.Id))
            {
                context.GroceryItemSources.Add(new GroceryItemSource
                {
                    GroceryListItem = groceryItem,
                    PlannedMealId = plannedMeal.Id,
                    RecipeIngredientId = ingredient.Id,
                    Quantity = ingredient.Quantity,
                    Unit = ingredient.Unit
                });
            }
        }

        await context.SaveChangesAsync(cancellationToken);
    }
}
