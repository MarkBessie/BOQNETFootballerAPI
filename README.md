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

🧠 Design Considerations
This project uses Entity Framework Core for data access because it's a small-scale application with simple CRUD operations. EF Core provides a quick and efficient way to interact with the database using familiar .NET patterns, which is ideal for prototyping and lightweight APIs like this one.

For a production-grade or more complex system, the database design would be expanded to include:

A Matches table to store match-specific details.

A Teams table to define team entities.

The Matches table would contain two foreign keys:

HomeTeamId

AwayTeamId

These enhancements would allow richer relationships, better data normalization, and more robust querying. The FootballerMatchStats table would then be linked to the Matches table via a MatchId foreign key, providing clear traceability between a player’s stats and the specific match context.
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

# 📘 API Endpoints Overview

---

## 🧍‍♂️ Footballer Endpoints

### ➕ Create a Footballer
`POST /api/Footballers`
- Creates a new footballer.

### 📥 Get All Footballers
`GET /api/Footballers`
- Retrieves a list of all footballers.

### 🔍 Get a Footballer by ID
`GET /api/Footballers/{footballerId}`
- Retrieves a single footballer by their ID.

### 🛠️ Update a Footballer
`PATCH /api/Footballers/{footballerId}`
- Updates an existing footballer’s information.

---

## 📊 Footballer Match Stats Endpoints

### ➕ Create Match Stats
`POST /api/Footballers/Stats`
- Creates new match stats for a footballer.

### 📥 Get All Stats for a Footballer
`GET /api/Footballers/{footballerId}/Stats`
- Retrieves all recorded match stats for a specific footballer.

### 🔍 Get Match Stats by Match ID and Footballer ID
`GET /api/Footballers/{footballerId}/{matchId}/Stats`
- Retrieves specific match stats for a footballer in a given match.

### 📈 Get Stats Summary
`GET /api/Footballers/{footballerId}/Stats/Summary`
- Returns an aggregated summary: total goals, assists, matches played, total minutes, and average pass completion.

---


