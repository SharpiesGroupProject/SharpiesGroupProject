$ErrorActionPreference = "Stop"

$projectDirectory = Join-Path (Split-Path -Parent $PSScriptRoot) "MealCraft"
$toolDirectory = Join-Path $HOME ".dotnet/tools"

if (-not (Get-Command dotnet -ErrorAction SilentlyContinue)) {
    throw "The .NET SDK is required. Install it before running this script."
}

if (Test-Path $toolDirectory) {
    $env:PATH = "$toolDirectory$([IO.Path]::PathSeparator)$env:PATH"
}

Push-Location $projectDirectory
try {
    $versionOutput = & dotnet ef --version 2>&1
    $toolExitCode = $LASTEXITCODE
    $toolVersion = ($versionOutput | Select-Object -Last 1).ToString().Trim()

    if ($toolExitCode -ne 0) {
        & dotnet tool install --global dotnet-ef --version 10.0.14
        if ($LASTEXITCODE -ne 0) {
            throw "Failed to install dotnet-ef."
        }
        $env:PATH = "$toolDirectory$([IO.Path]::PathSeparator)$env:PATH"
    }
    elseif ($toolVersion -ne "10.0.14") {
        & dotnet tool update --global dotnet-ef --version 10.0.14
        if ($LASTEXITCODE -ne 0) {
            throw "Failed to update dotnet-ef to version 10.0.14."
        }
        $env:PATH = "$toolDirectory$([IO.Path]::PathSeparator)$env:PATH"
    }

    & dotnet restore MealCraft.csproj
    if ($LASTEXITCODE -ne 0) {
        throw "Failed to restore the MealCraft project."
    }

    & dotnet ef database update --project MealCraft.csproj --startup-project MealCraft.csproj --context MealCraftDbContext
    if ($LASTEXITCODE -ne 0) {
        throw "Failed to create or update the local database."
    }

    Write-Host "Local database is ready at MealCraft/mealcraft.db."
}
finally {
    Pop-Location
}
