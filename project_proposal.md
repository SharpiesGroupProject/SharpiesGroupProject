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


<ins>Jeremy Troy Suchanski</ins>
# Meal Planner: A Meal Planning and Grocery List Management Application<br>
## Overview
The Meal Planner application will be designed with the intention to help families and individuals organize their meals, manage recipes, and simplify grocery shopping. The application's primary goal is to provide a centralized location where users can plan meals, store recipes, and automatically generate grocery lists based on their planned meals.

Planning meals and preparing grocery lists is a time-consuming process, especially for families who need to organize multiple meals throughout the week. This process consists of having to decide on what meals to prepare, following the desired recipes, identifying what ingredients are required, and manually creating a grocery list for the items that are not already in stock at home. Performing all of these tasks requires coordination of these different moving parts and can result in forgotten ingredients, duplicate grocery purchases, and extra amounts of time spent organizing meals and shopping.

The Meal Planner application purpose is to address these real-world problems by connecting three primary functions: meal planning, recipe management, and grocery list management.

Users of the Meal Planner application will be able to create and maintain a collection of recipes, select meals to include in their meal plans, and automatically add the required recipe ingredients to their grocery lists. The application will also allow users to manually add any additionally desired grocery items that are not associated with planned meals.

One of the application's distinguishing features will be its ability to maintain a connection between grocery list items and the planned meals that require them. This will allow users to identify which ingredients are needed for specific meals and distinguish those ingredients from grocery items added independently.

The target users will primarily be families who regularly plan meals and shop for groceries. However, the application will also benefit individuals, couples, and anyone interested in simplifying meal preparation and grocery shopping.

The overall goal of the project is to develop a user-friendly application that improves meal planning organization, reduces the time required to do it, and helps to automate the creation of a grocery list, thereby making obtaining of the necessary groceries more efficient.

## Scope
The scope of the Meal Planner project includes developing an application that allows users to create, manage, and maintain meal plans and recipes, and grocery lists. These features will be integrated so that changes to planned meals can be reflected in the grocery list.

The project will focus on providing the essential functionality needed to plan meals, create recipes, and prepare grocery lists without introducing unnecessary complexity.

### Meal Planning Features
•	Provide a meal planning page where users can view and organize their planned meals.<br>
•	Allow users to add meals to their meal plans.<br>
•	Allow users to update or remove planned meals.<br>
•	Allow users to associate existing recipes with planned meals.<br>
•	Allow users to view the meals planned for specific days.<br>
### Recipe Management
•	Provide a recipe management page where users can create, view, update, and delete recipes.<br>
•	Allow users to enter recipe names, ingredients, ingredient quantities, and preparation instructions.<br>
•	Store recipes so they can be reused in future meal plans.<br>
•	Allow users to select saved recipes when creating meal plans.<br>
### Grocery List Management
•	Provide a grocery list page where users can view the items needed for their planned meals.<br>
•	Automatically add the ingredients from selected recipes to the grocery list.<br>
•	Allow users to manually add grocery items that are not associated with planned meals.<br>
•	Allow users to update or remove manually added grocery items.<br>
•	Identify which grocery list items were generated from planned meals.<br>
•	Display the associated meal or recipe for automatically generated grocery items.<br>
•	Allow users to mark grocery items as purchased.<br>
•	Update the grocery list when meals are added to or removed from the meal plan.<br>
### User Interface
•	Provide navigation between the meal planning, recipe management, and grocery list pages.<br>
•	Use a consistent interface throughout the application.<br>
•	Provide forms and controls for adding, editing, and deleting information.<br>
•	Display appropriate messages when required information is missing or invalid.<br>
•	Support use on desktop and mobile devices through a responsive interface.<br>
### Features Excluded from the Project
The following features will not be included in the initial version of the application:<br>

•	User Accounts: Users will not be able to create accounts and log in.<br>
•	Rate Difficulty of Recipes: The application will not allow you to rate the difficulty of recipes.<br>
•	Dietary Restrictions: The application will not provide a way to include dietary restrictions.<br>
•	Nutritional Analysis: The application will not calculate calories, nutritional values, or dietary information for recipes.<br>
•	Recipe Import from External Websites: Users will enter and maintain their own recipes rather than importing recipes directly from websites.<br>
•	Pantry Inventory Management: The application will not track the quantities of ingredients users currently have in their homes.<br>
•	AI-Generated Meal Recommendations: The application will not automatically recommend meals using artificial intelligence.<br>

These features may be considered for future development but are outside the scope of the initial project.<br>
## Functional Requirements
The purpose of functional requirements are to describe the specific actions and operations that the Meal Planner application must perform.
Each functional requirement is assigned a unique identifier to simplify organization, development, testing, and tracking in Jira.<br>
### Meal Planning Requirements
#### FR-1: View Meal Plans
The system shall allow users to view their planned meals organized by date.
#### FR-2: Add Planned Meals
The system shall allow users to add a meal to a selected date in their meal plan.
#### FR-3: Edit Planned Meals
The system shall allow users to modify existing planned meals, including changing the associated recipe or scheduled date.
#### FR-4: Remove Planned Meals
The system shall allow users to remove meals from their meal plans.
#### FR-5: Associate Recipes with Meals
The system shall allow users to select an existing recipe and associate it with a planned meal.
#### FR-6: Display Meal Details
The system shall allow users to view the recipe information associated with a planned meal, including its ingredients and preparation instructions.
### Recipe Management Requirements
#### FR-7: Create Recipes
The system shall allow users to create recipes by entering a recipe name, ingredients, ingredient quantities, and preparation instructions.
#### FR-8: View Recipes
The system shall display a list of saved recipes and allow users to view the details of an individual recipe.
#### FR-9: Edit Recipes
The system shall allow users to update existing recipe information, including ingredients, quantities, and preparation instructions.
#### FR-10: Delete Recipes
The system shall allow users to delete saved recipes, with appropriate handling of recipes currently associated with planned meals.
#### FR-11: Store Recipes
The system shall store recipe information persistently so users can retrieve and reuse saved recipes.
#### FR-12: Validate Recipe Information
The system shall validate required recipe fields before allowing a recipe to be saved and display an appropriate message when required information is missing.
### Grocery List Requirements
#### FR-13: View Grocery List
The system shall display a grocery list containing ingredients generated from planned meals and items added manually by users.
#### FR-14: Automatically Generate Grocery Items
The system shall automatically add the ingredients required by a recipe to the grocery list when that recipe is added to the meal plan.
#### FR-15: Identify Grocery Item Sources
The system shall identify whether each grocery list item was automatically generated from a planned meal or manually added by the user.
#### FR-16: Associate Grocery Items with Planned Meals
The system shall maintain an association between automatically generated grocery items and the planned meals that require them.
#### FR-17: Add Grocery Items Manually
The system shall allow users to manually add grocery items that are not associated with planned meals.
#### FR-18: Edit Manually Added Grocery Items
The system shall allow users to modify the names and quantities of manually added grocery items.
#### FR-19: Remove Manually Added Grocery Items
The system shall allow users to remove manually added grocery items from their grocery lists.
#### FR-20: Update Grocery List When Meals Change
The system shall update the automatically generated portion of the grocery list when a planned meal is added, modified, or removed, while preserving unrelated manually added grocery items.
#### FR-21: Mark Grocery Items as Purchased
The system shall allow users to mark grocery items as purchased and distinguish purchased items from items that still need to be purchased.
#### FR-22: Display Grocery Item Quantities
The system shall display the required quantities and measurement units for grocery items when that information is available.
### Navigation and User Interface Requirements
#### FR-23: Navigate Between Application Pages
The system shall provide navigation controls that allow users to move between the meal planning, recipe management, and grocery list pages.
#### FR-24: Display Confirmation Messages
The system shall provide confirmation or feedback messages when users successfully add, update, or delete information.
#### FR-25: Display Validation Errors
The system shall display understandable error messages when users enter invalid information or attempt to submit incomplete forms.
#### FR-26: Confirm Deletion Actions
The system shall request confirmation before permanently deleting a saved recipe or other information whose deletion may affect associated records.
#### FR-27: Persist Application Data
The system shall save changes to meal plans, recipes, and grocery lists so that the information remains available when the application is closed and reopened.
## Non-Functional Requirements
The purpose of non-functional requirements are to define how the application should operate, including performance, usability, reliability, security, and maintainability.
These requirements establish quality standards that will help ensure the Meal Planner application is practical, reliable, and easy to use.
### Performance Requirements
#### NFR-1: Page Loading Performance
The application shall load its primary pages within 3 seconds under normal operating conditions and with a typical amount of stored data.
#### NFR-2: Grocery List Generation Performance
The application shall update the grocery list within 2 seconds after a user adds or removes a planned meal under normal operating conditions.
#### NFR-3: User Interaction Responsiveness
The application shall provide visible feedback within 1 second when a user initiates an action, such as saving a recipe or adding a grocery item.
### Usability Requirements
#### NFR-4: Intuitive Navigation
The application shall provide consistent navigation controls and clearly labeled pages so users can easily locate the meal planning, recipe management, and grocery list features.
#### NFR-5: Responsive Design
The application shall provide a responsive interface that adapts to desktop, tablet, and mobile screen sizes without requiring horizontal scrolling for primary application functions.
#### NFR-6: Consistent User Interface
The application shall use consistent layouts, colors, buttons, labels, and form controls throughout its pages.
#### NFR-7: Clear Error Messages
The application shall display error messages that identify the problem and provide sufficient information for users to correct invalid or missing entries.
#### NFR-8: Accessibility
The application shall support readable text, appropriately labeled form controls, and sufficient color contrast, following applicable WCAG 2.2 Level AA guidelines where feasible.
### Security Requirements
#### NFR-9: Input Validation
The application shall validate user-provided information before processing or storing it to reduce the risk of invalid data and common security vulnerabilities.
#### NFR-10: Secure Data Handling
The application shall use secure data handling practices to protect stored information and prevent unauthorized modification of application data.
#### NFR-11: Protection Against Common Web Vulnerabilities
The application shall use appropriate safeguards against common web application vulnerabilities, including cross-site scripting and injection attacks.
### Reliability Requirements
#### NFR-12: Data Persistence
The application shall preserve saved meal plans, recipes, and grocery list information between application sessions.
#### NFR-13: Data Consistency
The application shall maintain consistent relationships between planned meals, recipes, and automatically generated grocery items when associated information changes.
#### NFR-14: Error Handling
The application shall handle unexpected errors without unnecessarily losing previously saved information and shall display an understandable message when an operation cannot be completed.
#### NFR-15: Grocery List Accuracy
The application shall correctly identify the ingredients required by planned meals and shall not remove unrelated manually added grocery items when a planned meal is changed or deleted.
### Compatibility Requirements
#### NFR-16: Browser Compatibility
The application shall support current versions of major web browsers, including Google Chrome, Microsoft Edge, Mozilla Firefox, and Safari.
#### NFR-17: Device Compatibility
The application shall support common desktop, tablet, and smartphone screen sizes through its responsive interface.
Maintainability Requirements
#### NFR-18: Modular Design
The application shall organize its functionality into separate, maintainable components for meal planning, recipe management, and grocery list management.
#### NFR-19: Code Readability
The application's source code shall follow consistent naming conventions, formatting practices, and organizational standards established by the development team.
#### NFR-20: Version Control
The development team shall maintain the application's source code in a shared version control repository and use version control to track changes throughout development.
#### NFR-21: Testing
The development team shall test the application's primary functions, including recipe management, meal planning, automatic grocery list generation, and the preservation of manually added grocery items.
## Conclusion
The Meal Planner project will provide a practical solution for individuals and families who want to simplify meal planning and grocery shopping.

By combining meal planning, recipe management, and grocery list management into a single application, users will be able to organize their meals and automatically identify the ingredients needed for grocery shopping.

The application's ability to maintain relationships between planned meals and grocery list items will provide an additional level of organization beyond a traditional grocery list.

The project will focus on developing a functional, reliable, and user-friendly application while maintaining a manageable scope for the development team. The resulting application will provide a foundation that could be expanded in the future to include additional features such as user accounts, dietary restrictions, nutritional analysis, recipe imports, and advanced meal planning capabilities.

