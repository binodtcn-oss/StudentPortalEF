# StudentPortalEntityFramework: ASP.NET Core MVC + EF Core (.NET 10)

Student CRUD app that stores data in a file-based database using Entity Framework Core.

## Why SQLite and not SQL Server Compact (SQL CE)?
SQL CE is discontinued and works only with the old .NET Framework (EF6). It cannot be used
with .NET 10 / EF Core. SQLite is the modern equivalent: a single-file, zero-install,
embedded database with full EF Core support.

## Run
```
dotnet run --launch-profile http
```
Open http://localhost:5080. The file `StudentPortal.db` is created automatically on first run.
To reset the data, stop the app and delete `StudentPortal.db`.

## Key files
- `Data/AppDbContext.cs`: DbContext, DbSet<Student>, seed data
- `Models/Student.cs`: entity with validation attributes
- `Controllers/StudentsController.cs`: async CRUD + search using EF Core (LINQ)
- `Program.cs`: registers DbContext, creates the database with EnsureCreated()
- `appsettings.json`: connection string

## Optional: use Migrations instead of EnsureCreated
```
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef migrations add InitialCreate
dotnet ef database update
```
Then replace `EnsureCreated()` with `Database.Migrate()` in Program.cs.
