# 🏠 StayEasy - Property Rental & Sales Platform

## 📋 Overview
StayEasy is a comprehensive platform for buying, selling, and renting properties. Built with N-tier architecture for scalability and maintainability.

## 🏗️ Architecture
This project follows N-tier architecture pattern:

- **StayEasy.Domain** - Domain entities and models
- **StayEasy.DataAccess** - Data Access Layer (repositories, EF Core)
- **StayEasy.Service** - Business Logic Layer (services)
- **StayEasy.WebApi** - Presentation Layer (REST API)

## 🚀 Technologies
- .NET 8.0
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server / PostgreSQL

## 📦 Getting Started

### Prerequisites
- .NET 8.0 SDK
- SQL Server / PostgreSQL
- Visual Studio 2022 or JetBrains Rider

### Installation
1. Clone the repository
```bash
git clone https://github.com/Erkebulan1/StayEasy.git
cd StayEasy
```

2. Restore dependencies
```bash
dotnet restore
```

3. Update database connection string in `appsettings.json`

4. Run migrations
```bash
dotnet ef database update
```

5. Run the application
```bash
dotnet run --project StayEasy.WebApi
```

## 🔧 Features
- [ ] Property listing management
- [ ] User authentication & authorization
- [ ] Search and filtering
- [ ] Property booking/rental system
- [ ] Payment integration
- [ ] Reviews and ratings
- [ ] Admin dashboard

## 👨‍💻 Author
Erkebulan

## 📝 License
MIT License
