# backend_dev_dotnet_workshops
Backend Workshops on dotnet

## Project Overview

This is a **Simple .NET Console Application** built with .NET 10.0. The application demonstrates basic console I/O functionality by:
- Displaying a welcome message
- Prompting the user for input (name)
- Displaying a personalized greeting based on user input

## Important Files

| File | Purpose |
|------|---------|
| [SimpleConsoleApp/Program.cs](SimpleConsoleApp/Program.cs) | Main application entry point containing the console I/O logic |
| [SimpleConsoleApp/SimpleConsoleApp.csproj](SimpleConsoleApp/SimpleConsoleApp.csproj) | Project configuration file specifying SDK, target framework (.NET 10.0), and compiler settings |
| [LICENSE](LICENSE) | Project license |

## Build and Run Commands

### Build the Project
```bash
dotnet build
```

### Run the Application
```bash
dotnet run
```
Or after building:
```bash
dotnet run --project SimpleConsoleApp/SimpleConsoleApp.csproj
```

### Build for Release
```bash
dotnet build --configuration Release
```

### Run Release Build
```bash
dotnet run --configuration Release
```

### Clean Build Artifacts
```bash
dotnet clean
``` 
