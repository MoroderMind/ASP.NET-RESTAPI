# Game Store REST API

This is a fully asynchronous REST API for a Game Store built using ASP.NET Core. The API follows best practices in structuring the project with a DTO folder, Data folder, Endpoints, Mapping, and Entities. Instead of traditional controllers, this project utilizes minimal API endpoints for a more lightweight architecture. It leverages Microsoft Entity Framework (EF) Core with the EF Migrations tool and connects to a SQLite database.

## Features
- Fully asynchronous operations
- Uses Entity Framework Core for database management
- SQLite database integration
- DTOs for better data transfer and abstraction
- Organized architecture with folders for Entities, Data, DTOs, Endpoints, and Mapping
- Uses Minimal API Endpoints instead of traditional Controllers
- Supports CRUD operations for managing games
- RESTful API design

## Technologies Used
- **ASP.NET Core** - Web framework for building the API
- **Entity Framework Core** - ORM for data access
- **SQLite** - Lightweight relational database
- **Minimal APIs Extensions** - Enhances minimal APIs with additional functionality

## Required Packages
This project uses the following NuGet packages:
- [MinimalApis.Extensions](https://www.nuget.org/packages/MinimalApis.Extensions)
- `dotnet tool install --global dotnet-ef --version 9.0.2`
- `dotnet add package Microsoft.EntityFrameworkCore.Design --version 9.0.2`
- [Microsoft.EntityFrameworkCore.Sqlite](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Sqlite/10.0.0-preview.1.25081.1)

## Project Structure
```
GameStoreAPI/
│-- Endpoints/          # API Endpoints (Minimal API Routes)
│-- Data/               # Database Context & Configurations
│-- DTOs/               # Data Transfer Objects (DTOs)
│-- Entities/           # Database Models
│-- Mappings/           # AutoMapper Profiles
│-- Migrations/         # EF Core Migrations
│-- Program.cs          # Main application entry point
│-- appsettings.json    # Configuration settings
```

## Getting Started

### Prerequisites
- .NET 6.0 or later
- SQLite installed (or use built-in SQLite support)

### Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/GameStoreAPI.git
   cd GameStoreAPI
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Apply database migrations:
   ```bash
   dotnet ef database update
   ```

4. Run the API:
   ```bash
   dotnet run
   ```


## API Endpoints
### Games
| Method | Endpoint       | Description          |
|--------|--------------|----------------------|
| GET    | `/games` | Get all games        |
| GET    | `/games/{id}` | Get game by ID |
| POST   | `/games` | Create a new game    |
| PUT    | `/games/{id}` | Update a game |
| DELETE | `/games/{id}` | Delete a game |

## Database Management
To create a new migration, run:
```bash
   dotnet ef migrations add <MigrationName>
```
To apply migrations and update the database:
```bash
   dotnet ef database update
```

---
## Acknowledgments

This project was created by following Julio Casal's excellent tutorial on building modern web applications with Blazor and .NET.


