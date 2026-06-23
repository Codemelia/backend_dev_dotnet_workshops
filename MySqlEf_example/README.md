# MySql API Demo

## Steps
1. In parent directory, create a new solution and new project with controllers
**CLI**
```
dotnet new sln -o MySqlEf_example
dotnet new webapi --use-controllers -n MySqlEf.Api
```

3. Navigate to Project directory
**CLI**
```
cd MySqlEf.Api
```

4. Add packages for EntityFramework
**CLI**
```
dotnet add package MySql.EntityFrameworkCore --version 9.0.9
dotnet add package Microsoft.EntityFrameworkCore.Design --version 9.0.9
```

5. Create Entity models
[Person](./MySqlEf.Api/Models/Person.cs)
- Required: "using System.ComponentModel.DataAnnotations;"

6. Create DBContext
[DbContext](./MySqlEf.Api/Models/AppDbContext.cs)
- Required: "using Microsoft.EntityFrameworkCore;"

7. In appsettings.json, add db connection string
[AppSettings](./MySqlEf.Api/appsettings.json)
```  
"ConnectionStrings": { "default": "Server=localhost;Port=3306;database=DemoDb;Uid=userid;Pwd=password" },
```

8. Add db connection string to Program.cs
[Program.cs](./MySqlEf.Api/Program.cs)
- Required: "using Microsoft.EntityFrameworkCore;"
- Required: "using MySqlEf.Api.Models;"
```
string dbConnectionString = builder
    .Configuration
    .GetConnectionString("default")
    ?? throw new InvalidOperationException("Connection string 'default' not found.");

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(dbConnectionString)
);
```

9. Compare current DbContext & entities against last migration state and generate migration files that describe db schema; Execute migration files & update db
**CLI**
```
dotnet ef migrations add InitialCreate
dotnet ef database update
```

10. Create DTOs, Controllers, etc...