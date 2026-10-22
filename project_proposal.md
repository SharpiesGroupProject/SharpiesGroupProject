# MealCraft – Project Proposal

MealCraft – .NET Blazor Weekly Meal Planner & Smart Grocery Assistant

## Table of Contents

- [Overview](#overview)
- [Project Scope](#project-scope)
- [Functional Requirements](#functional-requirements)
- [Non-Functional Requirements](#non-functional-requirements)
- [App Features](#app-features)
- [Technical Considerations](#technical-considerations)
- [Project Links](#project-links)

## Overview

Planning meals and coordinating grocery shopping is a recurring weekly challenge for college students, busy professionals, and families. Without a structured plan, individuals frequently waste money on impulse grocery purchases, let perishable ingredients spoil, and resort to costly and unhealthy fast-food dining.

*MealCraft* is a full-stack .NET Blazor web application designed to eliminate the friction of home cooking. It enables users to maintain a personal recipe collection, schedule their weekly meals across interactive calendar slots (Breakfast, Lunch, Dinner), and automatically synthesize a consolidated, categorized grocery shopping list directly from the scheduled recipes. By bridging the gap between meal ideation, planning, and shopping, MealCraft saves users time and money, reduces domestic food waste, and fosters healthier lifestyle habits.

## Project Scope

### In-Scope

1. **User Authentication & Authorization (CSE 325 requirement)**
   - Secure user registration, login, logout, and password management powered by [ASP.NET Core Identity](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/?view=aspnetcore-10.0).
   - Each user accesses and modifies only their personal recipes, calendar plans, and shopping checklists.
2. **Recipe Management (full CRUD)**
   - Create, read, update, and delete custom recipes.
   - Structured recipe data: title, description, category/tag (e.g., Quick & Easy, Vegetarian, Budget), prep and cook times, servings, detailed ingredient lists (quantity, unit, item name), and step-by-step instructions.
   - Recipe gallery with instant keyword search and category filtering.
3. **Automated Grocery List Engine**
   - Dynamic generation of a consolidated grocery checklist aggregated from all recipes scheduled for the selected week.
   - Differentiation between recipe-derived ingredients (with source meal references) and manually added custom items (snacks).
   - Interactive checklist allowing items to be checked off while shopping in real time.
4. **Data Persistence & Architecture**
   - Relational database schema managed via Entity Framework Core ([EF Core](https://learn.microsoft.com/en-us/ef/core/)) with code-first migrations.
   - SQLite for local team development; cloud-compatible database for staging/production.
5. **Responsive Web UI & Accessibility**
   - Modern, responsive Blazor components accessible across mobile phones, tablets, and desktops (allowing users to easily view their shopping list at the grocery store).
6. **Cloud Deployment**
   - Hosted and publicly accessible on a cloud service (e.g., Azure App Service).

### Out-of-Scope

- **Third-party retail grocery integration:** No direct ordering or price tracking through external store APIs (e.g., Walmart, Instacart).
- **Automated OCR / barcode scanning:** No receipt scanning or barcode hardware inputs.
- **Complex nutritional macro calculation engines:** No dynamic calorie/vitamin breakdown algorithms.
- **Social networking / community feeds:** The app will focus strictly on individual private user utility to maintain a clean, achievable scope.
- **AI integrations:** No recipe generation supported by AI.

## Functional Requirements

Functional requirements describe the specific actions and operations that the MealCraft application must perform.
Each requirement has a unique identifier to simplify organization, development, testing, and tracking in Jira.

### Authentication and User Accounts

#### FR-1: Register an Account

The system shall allow a new user to register a personal account using a unique email address and a password that meets the system's password requirements.

#### FR-2: Log In and Log Out

The system shall allow registered users to log in and log out, and shall maintain the user's authenticated session while they use the application.

#### FR-3: Manage Password

The system shall allow authenticated users to change their password and shall allow users who forgot their password to reset it.

#### FR-4: Restrict Access to Personal Data

The system shall require users to be logged in to access recipes, meal plans, and grocery lists, and shall ensure each user can view and modify only their own data.

### Recipe Management

#### FR-5: Create Recipes

The system shall allow users to create recipes by entering a title, description, category/tags, prep time, cook time, servings, a list of ingredients (quantity, unit, and name), and step-by-step instructions.

#### FR-6: View Recipes

The system shall display a gallery of the user's saved recipes and allow users to view the formatted ingredient list and directions of an individual recipe.

#### FR-7: Search and Filter Recipes

The system shall allow users to search their recipes by keyword and filter them by category/tag, updating the displayed results immediately.

#### FR-8: Edit Recipes

The system shall allow users to update existing recipe information, including details, tags, ingredients, quantities, and instructions.

#### FR-9: Delete Recipes

The system shall allow users to delete recipes from their library, with appropriate handling of recipes currently scheduled in the meal planner.

#### FR-10: Validate Recipe Information

The system shall validate required recipe fields (such as title and ingredients) and non-negative quantities, times, and servings before saving, and shall display an appropriate message when information is missing or invalid.

### Weekly Meal Planning

#### FR-11: View Weekly Meal Planner

The system shall display an interactive 7-day calendar (Monday through Sunday) with Breakfast, Lunch, and Dinner slots for each day.

#### FR-12: Navigate Between Weeks

The system shall allow users to move between weeks in the meal planner and shall designate one week as the active week used for grocery list generation.

#### FR-13: Assign Recipes to Meal Slots

The system shall allow users to select a recipe from their library and assign it to a specific meal slot on a specific day.

#### FR-14: Remove Planned Meals

The system shall allow users to remove a recipe from a meal slot on the calendar.

#### FR-15: Replace and Reschedule Planned Meals

The system shall allow users to replace the recipe in a meal slot or move a planned meal to a different day or meal slot.

#### FR-16: Display Meal Details

The system shall allow users to view the recipe information associated with a planned meal, including its ingredients and preparation instructions, directly from the calendar.

### Grocery List

#### FR-17: View Grocery Checklist

The system shall display a grocery checklist for the active week containing ingredients generated from planned meals and custom items added manually by the user.

#### FR-18: Automatically Generate and Consolidate Grocery Items

The system shall automatically generate the grocery list from all recipes scheduled in the active week and shall combine matching ingredients (same name and compatible unit) into a single item with a total quantity.

#### FR-19: Identify Grocery Item Sources

The system shall identify whether each grocery list item was generated from scheduled recipes or manually added by the user, and shall display the origin recipe(s) for each recipe-derived item.

#### FR-20: Update Grocery List When Meals Change

The system shall update the recipe-derived portion of the grocery list when a planned meal is added, replaced, rescheduled, or removed, while preserving manually added items and the purchased status of unaffected items.

#### FR-21: Add Custom Grocery Items

The system shall allow users to manually add custom grocery or household items (such as snacks and pantry staples) that are not tied to a recipe.

#### FR-22: Edit Custom Grocery Items

The system shall allow users to modify the names and quantities of manually added grocery items.

#### FR-23: Remove Custom Grocery Items

The system shall allow users to remove manually added grocery items from their grocery lists.

#### FR-24: Mark Grocery Items as Purchased

The system shall provide an interactive checklist that allows users to mark items as purchased while shopping and shall visually distinguish purchased items from items that still need to be purchased.

#### FR-25: Display Grocery Item Quantities

The system shall display the required quantities and measurement units for grocery items when that information is available.

#### FR-26: Clear Purchased Items and Reset Checklist

The system shall allow users to clear purchased items and reset the grocery checklist to begin a new shopping cycle.

### Navigation and User Interface

#### FR-27: Navigate Between Application Pages

The system shall provide navigation controls that allow users to move between the recipe management, meal planner, and grocery list pages, as well as account pages such as login and registration.

#### FR-28: Display Confirmation Messages

The system shall provide confirmation or feedback messages when users successfully add, update, or delete information.

#### FR-29: Display Validation Errors

The system shall display understandable, real-time error messages when users enter invalid information or attempt to submit incomplete forms.

#### FR-30: Confirm Deletion Actions

The system shall request confirmation before permanently deleting a recipe or other information whose deletion may affect associated records, such as scheduled meals.

#### FR-31: Persist Application Data

The system shall save changes to recipes, meal plans, and grocery lists so that the information remains available when the user logs out and logs back in.

## Non-Functional Requirements

The application should be straightforward to use, reliable, and manageable for the development team.

#### NFR-1: Usability

The application should have clear navigation, consistent controls, and helpful messages when an action succeeds or needs correction.

#### NFR-2: Responsive Design

The application should remain usable on desktop and mobile screens, especially when viewing the grocery list while shopping.

#### NFR-3: Accessibility

The application should use readable text, labeled form controls, and clear visual contrast.

#### NFR-4: Data Persistence

Saved recipes, meal plans, and grocery lists should remain available between user sessions.

#### NFR-5: Maintainability

The application should use readable, organized code, and the project README should explain how to set up and use the application.

#### NFR-6: Testing

The development team should test the main application workflows, including recipes, meal planning, and grocery lists.

## App Features

### 1. Authentication & User Accounts

- Users will register a personal account with a unique email and secure password.
- The system will provide secure user authentication (login, logout, and session state).
- The system will enforce data isolation, ensuring users can only access and modify their own recipes, meal plans, and grocery items.

### 2. Recipe Management (CRUD)

- Users will create new recipes with title, description, category/tags, prep and cook times, servings, ingredients (quantity, unit, name), and cooking instructions.
- The system will display detailed recipe views with formatted ingredient lists and directions.
- The system will provide search and filtering capabilities by recipe name and category tags.
- Users will edit and update existing recipe details and ingredient lists.
- Users will delete recipes from their library.

### 3. Weekly Meal Planner

- The system will display an interactive 7-day calendar view (Monday through Sunday) organized by meal categories (Breakfast, Lunch, Dinner).
- Users will assign recipes from their library to specific meal slots on any given day.
- Users will remove, replace, or reschedule meals on the calendar.

### 4. Consolidated Grocery Checklist

- The system will automatically generate a consolidated grocery list aggregating all ingredients from meals scheduled for the active week.
- The system will display the origin recipe associated with each aggregated ingredient.
- Users will manually add custom grocery or household items (e.g., snacks, pantry staples) not tied to a recipe.
- The system will provide an interactive checklist allowing users to check off items as purchased during shopping.
- The system will allow users to clear purchased items and reset the grocery checklist for a new shopping cycle.

## Technical Considerations

1. **Technology Stack**
   - **Framework:** .NET 10 / C# with ASP.NET Core Blazor Web App (Interactive Server).
   - **Data layer:** Entity Framework Core (EF Core) with code-first migrations.
   - **Database:** SQLite (local development) and Netlify SQL or Azure SQL / PostgreSQL (cloud production).
   - **Authentication:** ASP.NET Core Identity.
2. **Usability & Mobile Responsiveness**
   - Responsive design allowing frictionless usability on smartphones in grocery aisles.
   - Clear visual hierarchy, consistent typography, and intuitive button placements.
3. **Data Validation & Reliability**
   - Model validation on all forms using DataAnnotations (e.g., required recipe title, non-negative quantities, valid email formats) with real-time UI feedback.
4. **Documentation & Code Quality**
   - Clean, readable C# following standard naming conventions.
   - Meaningful XML/code comments on complex service logic and a comprehensive user guide (setup and usage instructions in the README).
5. **Cloud Deployment**
   - Continuous deployment from GitHub to a cloud hosting environment (e.g., Azure App Service) with high availability for the final presentation.

## Project Links

- [GitHub repository](https://github.com/SharpiesGroupProject/SharpiesGroupProject)
- [Jira board](https://jeremy-troy-suchanski.atlassian.net/jira/software/projects/SHAR/boards/3)
