Project requirements - this can be deleted later. 
https://byui-cse.github.io/cse325-course/unit07/group-project-description.html

# Proposal document

Title: Provide a title for the project.

Overview: Briefly describe the purpose and goals of the project. Include the problem or opportunity the project aims to solve or the value it will add to the organization or society in general.

Scope: Do the best you can to describe the scope of the project. What is included and what is have you decided to not included in the project?

Functional Requirements: List the functional requirements of the project. What are the features of the project?

- Using Jira Boards in your group project's repo, start adding these requirements and/or user stories that might be relevant to your group project. Let the application help you consider some common User Stories.

Non-Functional Requirements: List the non-functional requirements of the project. What are the performance, security, and other feasible requirements or considerations of the project?

Project: Provide the address of the Project with its repo and board.

Tristan Zatylny

Title: Meal Planner

Overview: The goal of this project is to make an app that will help people plan meals for their week by allowing users to select recipes, creating a list of groceries to make those meals. This helps reduce the stress of meal prep and planning and increases the motivation to cook instead of eating out.

Scope: The scope of this project would include fetching data from a database of recipes and using that data to populate the app. Out of scope would be user authentication/login.

Functional Requirements:

- Meal plan page to see selected recipes
- Recipe page to look at and select recipes
- Grocery list page to see total groceries required
- Database connection for recipes (potentially)

Non-Functional Requirements:

- Fast loading of pages and grocery list
- Validation of meal/recipe creation so invalid data isn't put into database (if we do that)

## Proposal by: Milton Chino Mamani

**Title:** MealCraft &ndash; .NET Blazor Weekly Meal Planner & Smart Grocery Assistant

**Overview:**
Planning meals and coordinating grocery shopping is a recurring weekly challenge for college students, busy professionals, and families. Without a structured plan, individuals frequently waste money on impulse grocery purchases, let perishable ingredients spoil, and resort to costly and unhealthy fast-food dining. 

*MealCraft* is a full-stack .NET Blazor web application designed to eliminate the friction of home cooking. It enables users to maintain a personal recipe collection, schedule their weekly meals across interactive calendar slots (Breakfast, Lunch, Dinner), and automatically synthesize a consolidated, categorized grocery shopping list directly from the scheduled recipes. By bridging the gap between meal ideation, planning, and shopping, MealCraft saves users time and money, reduces domestic food waste, and fosters healthier lifestyle habits.

---

### Project Scope

#### In-Scope:
1. **User Authentication & Authorization (CSE 325 Requirement):**
   - Secure user registration, login, logout, and password management powered by [ASP.NET Core Identity](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/?view=aspnetcore-10.0).
   - Each user accesses and modifies only their personal recipes, calendar plans, and shopping checklists.
2. **Recipe Management (Full CRUD):**
   - Create, Read, Update, and Delete custom recipes.
   - Structured recipe data: title, description, category/tag (e.g., Quick & Easy, Vegetarian, Budget), prep & cook times, servings, detailed ingredient lists (quantity, unit, item name), and step-by-step instructions.
   - Recipe gallery with instant keyword search and category filtering.
3. **Automated Grocery List Engine:**
   - Dynamic generation of a consolidated grocery checklist aggregated from all recipes scheduled for the selected week.
   - Differentiation between recipe-derived ingredients (with source meal references) and manually added custom items (snacks).
   - Interactive checklist allowing items to be checked off while shopping in real time.
4. **Data Persistence & Architecture:**
   - Relational database schema managed via Entity Framework Core ([EF Core](https://learn.microsoft.com/en-us/ef/core/)) with code-first migrations.
   - SQLite for local team development; cloud-compatible database for staging/production.
5. **Responsive Web UI & Accessibility:**
   - Modern, responsive Blazor components accessible across mobile phones, tablets, and desktops (allowing users to easily view their shopping list at the grocery store).
6. **Cloud Deployment:**
   - Hosted and publicly accessible on a cloud service (e.g., Azure App Service).

#### Out-of-Scope
- *Third-party retail grocery integration:* No direct ordering or price tracking through external store APIs (e.g., Walmart, Instacart).
- *Automated OCR / Barcode scanning:* No receipt scanning or barcode hardware inputs.
- *Complex nutritional macro calculation engines:* No dynamic calorie/vitamin breakdown algorithms.
- *Social networking / Community feeds:* The app will focus strictly on individual private user utility to maintain a clean, achievable scope.
- *AI integrations:* No recipe generation supported by AI.

---

### App Features

#### 1. Authentication & User Accounts
- Users will register a personal account with a unique email and secure password.
- The system will provide secure user authentication (login, logout, and session state).
- The system will enforce data isolation, ensuring users can only access and modify their own recipes, meal plans, and grocery items.

#### 2. Recipe Management (CRUD)
- Users will create new recipes with title, description, category/tags, prep and cook times, servings, ingredients (quantity, unit, name), and cooking instructions.
- The system will display detailed recipe views with formatted ingredient lists and directions.
- The system will provide search and filtering capabilities by recipe name and category tags.
- Users will edit and update existing recipe details and ingredient lists.
- Users will delete recipes from their library.

#### 3. Weekly Meal Planner
- The system will display an interactive 7-day calendar view (Monday through Sunday) organized by meal categories (Breakfast, Lunch, Dinner).
- Users will assign recipes from their library to specific meal slots on any given day.
- Users will remove, replace, or reschedule meals on the calendar.

#### 4. Consolidated Grocery Checklist
- The system will automatically generate a consolidated grocery list aggregating all ingredients from meals scheduled for the active week.
- The system will display the origin recipe associated with each aggregated ingredient.
- Users will manually add custom grocery or household items (e.g., snacks, pantry staples) not tied to a recipe.
- The system will provide an interactive checklist allowing users to check off items as purchased during shopping.
- The system will allow users to clear purchased items and reset the grocery checklist for a new shopping cycle.


---

### Technical Considerations

1. **Technology Stack:**
   - **Framework:** .NET 10 / C# with ASP.NET Core Blazor Web App Interactive Server.
   - **Data Layer:** Entity Framework Core (EF Core) with Code-First Migrations.
   - **Database:** SQLite (local development) and Netlify SQL or Azure SQL / PostgreSQL (cloud production).
   - **Authentication:** ASP.NET Core Identity.
2. **Usability & Mobile Responsiveness:**
   - Responsive design allowing frictionless usability on smartphones in grocery aisles.
   - Clear visual hierarchy, consistent typography, and intuitive button placements.
3. **Data Validation & Reliability:**
   - Model validation on all forms using DataAnnotations (e.g., required recipe title, non-negative quantities, valid email formats) with real-time UI feedback.
4. **Documentation & Code Quality:**
   - Clean, readable C# following standard naming conventions.
   - Meaningful XML/code comments on complex service logic and a comprehensive User Guide (setup and usage instructions in README).
5. **Cloud Deployment:**
   - Continuous deployment from GitHub to a cloud hosting environment (e.g., Azure App Service) with high availability for the final presentation.



[GitHub repository](https://github.com/SharpiesGroupProject/SharpiesGroupProject)
[Jira board](https://jeremy-troy-suchanski.atlassian.net/jira/software/projects/SHAR/boards/3)