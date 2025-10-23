# PaginationCore API

A .NET Core Web API project demonstrating advanced data handling with pagination, filtering, and sorting capabilities for a member management system.

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

### Advanced Data Handling

#### Pagination

- Dynamic page size configuration
- Page number navigation
- Metadata including:
  - Total items count
  - Total pages count
  - Current page number
  - Items per page
  - Has previous/next page indicators
  - First/last page information

#### Filtering

- Gender-based filtering
- Age range filtering (min/max age)
- Current member exclusion
- Multiple filters can be combined
- Extensible filter parameters

#### Sorting

- Default sorting by last active date
- Alternative sorting by creation date
- Extensible sorting mechanism
- Descending order optimization
- Custom sort field support

### Implementation Highlights

- Repository Pattern for clean architecture
- Generic pagination implementation
- Fluent query building
- Efficient database queries
- LINQ-based dynamic filtering
- Asynchronous operations
- Error handling with proper status codes
- Dependency injection for loose coupling

## API Endpoints

### Members API

```plaintext
GET /api/members
```

Query Parameters:
- `pageNumber` (int): Page number (default: 1)
- `pageSize` (int): Items per page (default: 10)
- `gender` (string): Filter by gender
- `minAge` (int): Minimum age filter
- `maxAge` (int): Maximum age filter
- `orderBy` (string): Sort field (created/lastActive)

Response includes:
- Paginated member list
- Pagination metadata
- Filtering details
- Sorting information

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

## Development Features

### Repository Pattern Implementation

- Clean separation of concerns
- Easy to test and maintain
- Centralized data access logic
- Consistent error handling

### Pagination Helper

- Generic implementation
- Reusable across entities
- Efficient query execution
- Metadata calculation

### Query Optimization

- Deferred execution
- Efficient filtering
- Smart sorting implementation
- Minimal memory usage

### Error Handling

- Proper HTTP status codes
- Detailed error messages
- Global exception handling
- Validation responses