# PaginationCore API

A .NET Core Web API project demonstrating pagination functionality for a member management system.

## Technologies Used

- .NET 9.0
- Entity Framework Core 9.0.10
- SQLite Database
- ASP.NET Core Web API

## Project Structure

- `API/` - Main project directory
  - `Controllers/` - API Controllers
  - `Data/` - Database context and repositories
  - `Entity/` - Domain models
  - `Helper/` - Utility classes for pagination
  - `Interface/` - Repository interfaces

## Features

- Member management with CRUD operations
- Pagination support with metadata
- Filtering by:
  - Gender
  - Age range
  - Current member
- Sorting by:
  - Creation date
  - Last active date

## Models

### Member

```csharp
public class Member
{
    public string Id { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string? ImageUrl { get; set; }
    public required string DisplayName { get; set; }
    public DateTime Created { get; set; }
    public DateTime LastActive { get; set; }
    public required string Gender { get; set; }
    public string? Description { get; set; }
    public required string City { get; set; }
    public required string Country { get; set; }
}
```

## Configuration

The application uses SQLite as its database. Connection string can be configured in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data source=PaginationCore.db"
  }
}
```

## Getting Started

1. Clone the repository
2. Install dependencies:
```sh
dotnet restore
```
3. Update database:
```sh
dotnet ef database update
```
4. Run the application:
```sh
dotnet run
```

The API will be available at `http://localhost:5180`

## Development

The project includes:
- Entity Framework Core with SQLite
- Repository pattern implementation
- Pagination helper utilities
- Custom parameter classes for filtering and pagination