using MealCraft.Models;
using Microsoft.EntityFrameworkCore;

namespace MealCraft.Data;

public class MealCraftDbContext(DbContextOptions<MealCraftDbContext> options) : DbContext(options)
{
    public DbSet<ApplicationUser> Users => Set<ApplicationUser>();
    public DbSet<Recipe> Recipes => Set<Recipe>();
    public DbSet<RecipeTag> RecipeTags => Set<RecipeTag>();
    public DbSet<Ingredient> RecipeIngredients => Set<Ingredient>();
    public DbSet<MealPlan> MealPlans => Set<MealPlan>();
    public DbSet<PlannedMeal> PlannedMeals => Set<PlannedMeal>();
    public DbSet<GroceryListItem> GroceryListItems => Set<GroceryListItem>();
    public DbSet<GroceryItemSource> GroceryItemSources => Set<GroceryItemSource>();
    public DbSet<StandaloneGroceryItem> StandaloneGroceryItems => Set<StandaloneGroceryItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ApplicationUser>()
            .HasIndex(user => user.Email)
            .IsUnique();

        modelBuilder.Entity<Recipe>()
            .HasOne(recipe => recipe.User)
            .WithMany(user => user.Recipes)
            .HasForeignKey(recipe => recipe.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<RecipeTag>()
            .HasKey(tag => new { tag.RecipeId, tag.TagName });

        modelBuilder.Entity<RecipeTag>()
            .HasOne(tag => tag.Recipe)
            .WithMany(recipe => recipe.RecipeTags)
            .HasForeignKey(tag => tag.RecipeId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Ingredient>()
            .HasOne(ingredient => ingredient.Recipe)
            .WithMany(recipe => recipe.Ingredients)
            .HasForeignKey(ingredient => ingredient.RecipeId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<MealPlan>()
            .HasOne(plan => plan.User)
            .WithMany(user => user.MealPlans)
            .HasForeignKey(plan => plan.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<MealPlan>()
            .HasIndex(plan => new { plan.UserId, plan.WeekStartDate })
            .IsUnique();

        modelBuilder.Entity<PlannedMeal>()
            .HasOne(meal => meal.MealPlan)
            .WithMany(plan => plan.PlannedMeals)
            .HasForeignKey(meal => meal.MealPlanId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<PlannedMeal>()
            .HasOne(meal => meal.Recipe)
            .WithMany(recipe => recipe.PlannedMeals)
            .HasForeignKey(meal => meal.RecipeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<GroceryListItem>()
            .HasOne(item => item.MealPlan)
            .WithMany(plan => plan.GroceryListItems)
            .HasForeignKey(item => item.MealPlanId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<GroceryItemSource>()
            .HasOne(source => source.GroceryListItem)
            .WithMany(item => item.Sources)
            .HasForeignKey(source => source.GroceryListItemId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<GroceryItemSource>()
            .HasOne(source => source.PlannedMeal)
            .WithMany(meal => meal.GroceryItemSources)
            .HasForeignKey(source => source.PlannedMealId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<GroceryItemSource>()
            .HasOne(source => source.RecipeIngredient)
            .WithMany(ingredient => ingredient.GroceryItemSources)
            .HasForeignKey(source => source.RecipeIngredientId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<StandaloneGroceryItem>()
            .Property(item => item.Name)
            .HasMaxLength(80)
            .IsRequired();

        modelBuilder.Entity<StandaloneGroceryItem>()
            .Property(item => item.Quantity)
            .HasMaxLength(40)
            .IsRequired();

        modelBuilder.Entity<StandaloneGroceryItem>()
            .Property(item => item.Category)
            .HasMaxLength(40)
            .IsRequired();
    }
}