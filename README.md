# Sharpies Group Project

## Local database setup

Run `./scripts/Setup-Database.ps1` from PowerShell to create or update the local SQLite database using the EF Core migrations. The script installs or updates the matching `dotnet-ef` tool if needed. Start the app afterward; it applies migrations and seeds demo data automatically. The generated `MealCraft/mealcraft.db` file is ignored by Git.

## Running locally

In the `MealCraft` directory, run `dotnet run`.

## Project Summary & Design

[Project Proposal Page](docs/project_proposal.md)

[ERD](docs/meal-planner-erd.md)

## Team Members

- Jeremy Suchanski
- Tristan Zatylny
- Seth Taylor
- Milton Chino Mamani
- Reece Beaumont-Thomas