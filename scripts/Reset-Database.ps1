<#
.SYNOPSIS
    Rebuilds the local MealCraft SQLite database from scratch.

.DESCRIPTION
    Use this when your local mealcraft.db is out of date or was created with a
    different schema than the current migrations (e.g. "no such column/table"
    errors, or migration failures on `dotnet ef database update`).

    The existing database is backed up next to the original (mealcraft.db.<timestamp>.bak),
    deleted, and recreated by running Setup-Database.ps1. Demo data is seeded the
    next time the app starts.

.PARAMETER Force
    Skip the confirmation prompt.

.PARAMETER NoBackup
    Do not keep a backup copy of the old database.
#>
[CmdletBinding()]
param(
    [switch]$Force,
    [switch]$NoBackup
)

$ErrorActionPreference = "Stop"

$projectDirectory = Join-Path (Split-Path -Parent $PSScriptRoot) "MealCraft"
$databasePath = Join-Path $projectDirectory "mealcraft.db"
$databaseFiles = @($databasePath, "$databasePath-wal", "$databasePath-shm", "$databasePath-journal")

if (Test-Path $databasePath) {
    if (-not $Force) {
        Write-Warning "This will delete your local database at $databasePath. Local data (e.g. accounts, recipes you added) will be lost."
        $answer = Read-Host "Continue? (y/N)"
        if ($answer -notmatch '^(y|yes)$') {
            Write-Host "Cancelled."
            return
        }
    }

    if (-not $NoBackup) {
        $backupPath = "$databasePath.$(Get-Date -Format 'yyyyMMdd-HHmmss').bak"
        try {
            Copy-Item -LiteralPath $databasePath -Destination $backupPath
            Write-Host "Backed up old database to $backupPath"
        }
        catch {
            throw "Could not back up the database. Stop the running MealCraft app and try again. $($_.Exception.Message)"
        }
    }

    foreach ($file in $databaseFiles) {
        if (Test-Path $file) {
            try {
                Remove-Item -LiteralPath $file -Force
            }
            catch {
                throw "Could not delete $file. Stop the running MealCraft app (or anything else using the database) and try again."
            }
        }
    }
    Write-Host "Removed old database."
}
else {
    Write-Host "No existing database found; creating a new one."
}

& (Join-Path $PSScriptRoot "Setup-Database.ps1")

Write-Host "Done. Start the app to seed demo data."
