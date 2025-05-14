# ⚽ Footballer Stats Tracker API

A simple .NET 8 Web API for tracking footballers and their match statistics. This project is part of a backend developer technical assessment and demonstrates clean RESTful API design, service abstraction, model binding, and asynchronous database access using Entity Framework Core.

---

## 🚀 Features

- Add, update, and retrieve footballers.
- Track match statistics for each footballer.
- Retrieve all match stats or summaries for individual players.
- Proper error handling and clean separation of concerns.

---

## 🛠 Tech Stack

- **.NET 8**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **SQLite / SQL Server (configurable)**
- **Dependency Injection**
- **Swagger (optional for testing)**

---

## 📦 Project Structure

```bash
FootballerStatsAPI/
│
├── Controllers/
│   ├── FootballerAPIController.cs
│   └── FootballerStatsAPIController.cs
│
├── Models/
│   ├── Footballer.cs
│   └── FootballerMatchStats.cs
│
├── Services/
│   ├── Interfaces/
│   │   ├── IFootballer.cs
│   │   └── IFootballerStats.cs
│   └── Implementations/
│       ├── FootballerService.cs
│       └── FootballerStatsService.cs
│
├── Data/
│   └── AppDbContext.cs
│
├── Dtos/
│   └── MatchStatsSummaryDto.cs
│
└── Program.cs
