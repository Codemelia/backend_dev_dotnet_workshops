# Simple Console Application

## Project Overview

This is a **Simple .NET Console Application** built with .NET 10.0. The application demonstrates:
- Basic console I/O functionality
- Dependency injection with Microsoft.Extensions.DependencyInjection
- Service-based architecture using IExampleService
- Calculator operations (addition, subtraction, multiplication)
- Personalized user greeting based on input

## Important Files

| File | Purpose |
|------|---------|
| [SimpleConsoleApp/Program.cs](SimpleConsoleApp/Program.cs) | Main application entry point with dependency injection and service testing |
| [SimpleConsoleApp/service/IExampleService.cs](SimpleConsoleApp/service/IExampleService.cs) | Service interface defining calculator operations |
| [SimpleConsoleApp/service/ExampleService.cs](SimpleConsoleApp/service/ExampleService.cs) | Service implementation for calculator operations |
| [SimpleConsoleApp/SimpleConsoleApp.csproj](SimpleConsoleApp/SimpleConsoleApp.csproj) | Project configuration file specifying SDK, target framework (.NET 10.0), and compiler settings |
| [LICENSE](LICENSE) | Project license |

## Service Functions

The application uses **IExampleService** with the following calculator operations:

- **performAddition(int a, int b)**: Adds two numbers and returns the result as a formatted string
- **performSubtraction(int a, int b)**: Subtracts two numbers and returns the result as a formatted string
- **performMultiplication(int a, int b)**: Multiplies two numbers and returns the result as a formatted string

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
