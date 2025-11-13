# EfValueObjectAsJson.DemoApi

This project is a small demo API that uses Entity Framework Core to persist `Order` data.

## Local SQL Server for development (Docker)

To run a local SQL Server 2025 container for development you can use the following `docker run` command:

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Your_password123" -e "MSSQL_PID=Developer" -p 11433:1433 --name sqlserver2025 -v sqlserver2025-data:/var/opt/mssql -d mcr.microsoft.com/mssql/server:2025-latest
```

Docker Compose example:

```yaml
version: '3.8'
services:
  sqlserver:
    image: mcr.microsoft.com/mssql/server:2025-latest
    environment:
      - ACCEPT_EULA=Y
      - SA_PASSWORD=Your_password123
      - MSSQL_PID=Developer
    ports:
      - "11433:1433"
    volumes:
      - sqlserver2025-data:/var/opt/mssql

volumes:
  sqlserver2025-data:
```

## Connection string

Update `appsettings.json` (or `appsettings.Development.json`) to point to the running container. Example connection string used by this project:

```
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost,11433;Database=OrdersDb;User Id=sa;Password=Your_password123;TrustServerCertificate=True;"
}
```

Notes:
- Replace `Your_password123` with a strong password.
- Ensure Docker is running before starting the container.
- If you prefer Windows Authentication, adjust the connection string and container configuration accordingly.

## Migrations

After the database is running, apply migrations (if any) with:

```bash
dotnet ef database update --project EfValueObjectAsJson.DemoApi
```

(Ensure `dotnet-ef` tools are installed and the working directory is the solution or project folder.)
