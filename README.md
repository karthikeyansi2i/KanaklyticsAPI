# Kanaklytics Inventory Management API

This is a .NET 8 RESTful API for inventory management, following Clean Architecture principles and using Entity Framework Core with SQL Server.

## Features
- Product Catalog: CRUD for products
- Inventory: Track product stock per warehouse
- Warehouses: Manage warehouse locations
- Purchase Orders: Manage supplier orders
- Stock Alerts: Low stock alert configuration
- Reports: Stock valuation and inventory trends

## Project Structure
- Controllers: API Endpoints
- Services: Business Logic
- Repositories: Data Access
- DTOs: Data Transfer Objects
- Models: Domain Entities
- Migrations: EF Core Migrations

## Getting Started
1. Update `appsettings.json` with your SQL Server connection string.
2. Run EF Core migrations to create the database schema.
3. Launch the API and access Swagger UI at `/swagger`.

## API Endpoints
See the documentation in Swagger UI for details on all endpoints.

## Requirements
- .NET 8 SDK
- SQL Server

## How to Build & Run
```powershell
# Restore dependencies
 dotnet restore
# Build the project
 dotnet build
# Run the API
 dotnet run
```

## License
MIT
