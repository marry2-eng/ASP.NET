
# Car Insurance Web Application

This ASP.NET MVC application uses Entity Framework and SQL Server (.mdf) to manage insurance data. It provides full CRUD functionality and custom logic to calculate insurance quotes.

## 🧩 Technologies Used
- ASP.NET MVC (Web Application .NET Framework)
- Entity Framework (EF Designer from Database)
- SQL Server (LocalDB, .mdf database)
- Visual Studio

## ✅ Features

### Part 1 – Project Setup
- MVC application named `Car Insurance`.
- SQL Server database `Insurance.mdf` in App_Data.
- Table `Insurees` with fields: Id, FirstName, LastName, EmailAddress, DateOfBirth, CarYear, CarMake, CarModel, DUI, SpeedingTickets, CoverageType, Quote.
- Used ADO.NET Entity Data Model to scaffold models and controller.

### Part 2 – CRUD Functionality
- Create, Edit, View, Delete tested using a test entry (`Joe Black`).
- Verified changes persisted to the SQL Server database.

### Part 3 – MVC Structure
- Models: Database table mapped to class using EF.
- Controllers: Business logic handled in `InsureeController`.
- Views: Razor views for all standard CRUD operations.

### Part 4 – Quote Calculation Logic
Custom quote logic added to `InsureeController.cs`:

- Base: $50/month
- Age:
  - ≤18: +$100
  - 19–25: +$50
  - ≥26: +$25
- Car Year:
  - <2000: +$25
  - >2015: +$25
- Porsche:
  - Make = Porsche: +$25
  - Model = 911 Carrera: +$25
- Speeding Tickets: +$10 each
- DUI: +25% of total
- Coverage Type (Full): +$50

- Quote field hidden from Create view.
- Admin view shows all Insurees: First Name, Last Name, Email, and Quote.


© 2025 Car Insurance MVC Assignment – All rights reserved.
