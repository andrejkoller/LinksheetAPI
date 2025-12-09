## Short description

This is the backend API for the Linksheet application. It provides endpoints to manage users, links, link spaces, and other related resources.

## 🛠️ Technologies Used

- .NET 9 Web API
- Entity Framework Core
- MS SQL Server
- RESTful API
- JWT Authentication

## 📋 Prerequisites

- .NET SDK 9
- MSSQL Server

## 📦 Installation

1. Clone the repository

```bash
git clone https://github.com/andrejkoller/LinksheetAPI.git
cd LinksheetAPI
```

2. Configure the database connection

Edit the connection string in `appsettings.json` or `appsettings.Development.json`:

```bash
"ConnectionStrings": {
"DefaultConnection": "Server=localhost;Database=LinksheetDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

3. Apply database migration

Make sure the Entity Framework Core CLI is installed:

 ```bash
dotnet tool install --global dotnet-ef
```

Then apply the migrations:

 ```bash
dotnet ef database update
```

4. Run the API

 ```bash
dotnet run --project LinksheetAPI
```

The API will be available at `https://localhost:7187` or `http://localhost:5234`.

## 🔗 Related

- Frontend Repository: [linksheet-frontend](https://github.com/andrejkoller/linksheet-frontend)
