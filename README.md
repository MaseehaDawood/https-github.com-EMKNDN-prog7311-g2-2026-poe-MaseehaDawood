
# Global Logistics Management System (GLMS)

## Executive Summary
The Global Logistics Management System (GLMS) is a web-based application developed using ASP.NET Core MVC. The system provides a centralized platform for managing clients, contracts, and service requests in a logistics environment.

This project demonstrates enterprise software development concepts such as database integration using Entity Framework Core, file handling, API integration, design patterns, and unit testing. The system follows a monolithic architecture where all components are developed and deployed as a single unit.

---

## System Features

### Client Management
- Create and manage clients
- Store client contact details and region

### Contract Management
- Assign contracts to clients
- Upload contract documents (PDF only)
- Download uploaded contracts
- Filter contracts by status (Active / Expired)

### Service Request Management
- Create service requests linked to contracts
- Enforce business rules:
  - Cannot create requests for expired contracts
- Automatic cost calculation

### File Handling
- Upload contract files
- Accepts only PDF files
- Rejects invalid file types
- Stores files in `wwwroot/files`

### API Integration
- Currency conversion from USD to ZAR
- Uses a live exchange rate API
- Implemented using async/await

### Design Pattern
- Strategy Pattern used for pricing calculation
- Allows flexible and reusable business logic

### Unit Testing
- Implemented using xUnit
- Tests include:
  - Currency calculation
  - File validation
  - Business rules

---

## Technologies Used

- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- xUnit
- C#
- LINQ

---

## Database Setup

### Step 1: Configure Connection String

Edit `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=GLMSDB;Trusted_Connection=True;"
}
````

---

### Step 2: Apply Migrations

Open Package Manager Console and run:

```
Add-Migration InitialCreate
Update-Database
```

---

### Step 3: Seed Data

The application includes sample data:

* Clients
* Contracts (Active and Expired)

---

## Running the Application

1. Open the solution in Visual Studio
2. Build the solution
3. Run the application (F5)
4. Navigate through:

   * Clients
   * Contracts
   * Service Requests

---

## Running Unit Tests

1. Open Test Explorer:

   ```
   Test → Test Explorer
   ```
2. Click:

   ```
   Run All Tests
   ```

All tests should pass successfully.

---

## Video Demonstration

YouTube Link : https://youtu.be/suADXnmo9xA?si=FrtfRB9XQF8ouU_A


---

##  Screenshots

### ✔ Unit Tests

<img width="1596" height="824" alt="6tests" src="https://github.com/user-attachments/assets/eca6461f-916f-4549-9c56-6955854d5228" />

### ✔ Application

<img width="1620" height="1204" alt="Contract page" src="https://github.com/user-attachments/assets/db671753-095e-4ab9-9e25-39cdd92bf40b" />


---

## <img width="2838" height="1332" alt="Requests" src="https://github.com/user-attachments/assets/6e0f5335-3a7a-43a9-a8dc-afa842720266" />
<img width="1442" height="1148" alt="client" src="https://github.com/user-attachments/assets/af773a5a-ea25-4e95-a484-57eb7fb101b0" />
Project Structure

```
GLMS
 ├── Controllers
 ├── Models
 ├── Services
 ├── Views
 ├── Data
 └── wwwroot/files

GLMS.Tests
 └── Unit Tests
```

---

## Validation Rules

* Only PDF files can be uploaded
* Service requests cannot be created for expired contracts
* Required fields must be completed before submission

---

## Design Pattern Explanation

The Strategy Pattern is used to define a family of algorithms for pricing calculations. This allows the system to change pricing logic without modifying existing code.

This improves:

* Flexibility
* Maintainability
* Code reusability

---

## Database Scripts

Database migrations are included in the project and can be used to recreate the database structure.

---

## Code Attribution

csharp
// Code attribution
// Title: Strategy Design Pattern
// Author: Refactoring.Guru
// Date: 2026
// Version: 1
// Available at: https://refactoring.guru/design-patterns/strategy
// [Accessed: 21 April 2026]

AI was used to generate the voice over for the demo (QuillBot,2026)
QuillBot. (2026). QuillBot AI Voice. Available at: https://quillbot.com (Accessed: 22 April 2026).


---

## Final Notes

* The system follows a monolithic architecture
* All components are integrated into a single application
* Demonstrates enterprise development concepts including:

  * Database integration
  * API usage
  * Design patterns
  * Unit testing

---

## 👤 Author
Maseeha Dawood



