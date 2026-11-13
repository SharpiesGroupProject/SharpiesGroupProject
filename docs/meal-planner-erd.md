# Meal Planner ERD

```mermaid
erDiagram
    ApplicationUser ||--o{ Recipe : owns
    ApplicationUser ||--o{ MealPlan : owns
    ApplicationUser ||--o{ AspNetUserClaims : has
    ApplicationUser ||--o{ AspNetUserLogins : has
    ApplicationUser ||--o{ AspNetUserTokens : has
    ApplicationUser ||--o{ AspNetUserRoles : has
    AspNetRoles ||--o{ AspNetUserRoles : assigned_via
    AspNetRoles ||--o{ AspNetRoleClaims : has
    Recipe ||--o{ RecipeTag : tagged_with
    Recipe ||--o{ RecipeIngredient : contains
    Recipe ||--o{ PlannedMeal : selected_for
    Product ||--o{ RecipeIngredient : defines
    Product |o--o{ GroceryListItem : categorizes
    MealPlan ||--o{ PlannedMeal : schedules
    MealPlan ||--o{ GroceryListItem : has
    PlannedMeal |o--o{ GroceryItemSource : contributes
    RecipeIngredient |o--o{ GroceryItemSource : contributes
    GroceryListItem ||--o{ GroceryItemSource : derived_from

    ApplicationUser {
        string Id PK "table: Users"
        string UserName
        string NormalizedUserName
        string Email UK
        string NormalizedEmail
        bool EmailConfirmed
        string PasswordHash
        string SecurityStamp
        string ConcurrencyStamp
        string PhoneNumber
        bool PhoneNumberConfirmed
        bool TwoFactorEnabled
        datetimeoffset LockoutEnd
        bool LockoutEnabled
        int AccessFailedCount
    }

    AspNetRoles {
        string Id PK
        string Name
        string NormalizedName UK
        string ConcurrencyStamp
    }

    AspNetRoleClaims {
        int Id PK
        string RoleId FK
        string ClaimType
        string ClaimValue
    }

    AspNetUserClaims {
        int Id PK
        string UserId FK
        string ClaimType
        string ClaimValue
    }

    AspNetUserLogins {
        string LoginProvider PK
        string ProviderKey PK
        string ProviderDisplayName
        string UserId FK
    }

    AspNetUserRoles {
        string UserId PK, FK
        string RoleId PK, FK
    }

    AspNetUserTokens {
        string UserId PK, FK
        string LoginProvider PK
        string Name PK
        string Value
    }

    Recipe {
        int Id PK
        string UserId FK
        string Title "max 100"
        string Description "max 500"
        int PrepMinutes
        int CookMinutes
        int Servings
        string RecipeInstructions
    }

    RecipeTag {
        int RecipeId PK, FK
        string TagName PK "max 50"
    }

    Product {
        int Id PK
        string Name "max 120"
        string Category "max 50"
        string DefaultUnit "max 50"
    }

    RecipeIngredient {
        int Id PK
        int RecipeId FK
        int ProductId FK
        string Name
        decimal Quantity
        string Unit
        int DisplayOrder
    }

    MealPlan {
        int Id PK
        string UserId FK
        datetime WeekStartDate "unique with UserId"
        bool IsActive
    }

    PlannedMeal {
        int Id PK
        int MealPlanId FK
        int RecipeId FK
        datetime MealDate
        string MealType
    }

    GroceryListItem {
        int Id PK
        int MealPlanId FK
        int ProductId FK "nullable"
        datetime CreatedAt
        string Name
        decimal Quantity
        string Unit
        string SourceType
        bool IsPurchased
    }

    GroceryItemSource {
        int Id PK
        int GroceryListItemId FK
        int PlannedMealId FK "nullable"
        int RecipeIngredientId FK "nullable"
        decimal Quantity
        string Unit
    }

    StandaloneGroceryItem {
        int Id PK
        string Name "max 80"
        string Quantity "max 40"
        string Category "max 40"
        bool IsPurchased
    }
```

Notes:

- Derived from `MealCraft/Migrations/MealCraftDbContextModelSnapshot.cs`.
- `ApplicationUser` maps to the `Users` table; the `Ingredient` model maps to the `RecipeIngredient` table.
- `StandaloneGroceryItem` has no relationships (not tied to a user or meal plan).
- Deleting a user cascades to their recipes and meal plans. Deleting a recipe cascades to its tags and ingredients. Deleting a meal plan cascades to its planned meals and grocery items.
- `PlannedMeal -> Recipe`, `RecipeIngredient -> Product`, and the `GroceryItemSource -> PlannedMeal/RecipeIngredient` links are `Restrict`. `GroceryListItem -> Product` is `SetNull`.
