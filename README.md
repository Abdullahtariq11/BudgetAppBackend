BudgetApp API

Overview

BudgetApp API is a comprehensive financial management API built using ASP.NET Core Web API. It provides users the ability to manage their transactions, budget categories, and cards, as well as handle user authentication with JWT (JSON Web Token) for secure access.

Features

	•	User Registration and Login with JWT-based authentication
	•	Create, Update, Delete, and Get Transactions
	•	Manage Budget Categories (CRUD operations)
	•	Manage Cards (CRUD operations)
	•	Custom Exception Handling with Middleware
	•	Integrated Logging with NLog
	•	Token-based authentication for securing API endpoints
	•	Swagger for API documentation

Technologies

	•	Backend Framework: ASP.NET Core Web API
	•	Database: PostgreSQL
	•	Authentication: JWT (JSON Web Tokens)
	•	Logging: NLog
	•	Dependency Injection: ASP.NET Core DI
	•	In-Memory Testing: EF Core In-Memory
	•	Swagger: Integrated for API documentation

Prerequisites

	•	.NET 6 SDK or later
	•	PostgreSQL Database
	•	Visual Studio or VS Code
	•	IIS (Optional for deployment)
	•	NLog for logging configuration

Project Structure

/BudgetAppBackend
├── /API
├── /Application
├── /Domain
├── /Infrastructure
├── /Shared

	•	API: Contains controllers and middleware for handling HTTP requests.
	•	Application: Business logic services.
	•	Domain: Entity models and contracts.
	•	Infrastructure: Data access layer (repositories and EF context).
	•	Shared: DTOs and common classes.

Setup

1. Clone the Repository

git clone https://github.com/Abdullahtariq11/BudgetAppBackend.git
cd BudgetAppBackend

2. Configure PostgreSQL Database

Ensure you have PostgreSQL running locally or remotely. Then update the appsettings.json with your database connection string.

{
  "ConnectionStrings": {
    "posgresConnectionString": "Server=localhost;Port=5432;Database=BudgetDb;UserId=postgres;Password=YourPassword;"
  }
}

3. Setup JWT Authentication

In appsettings.json, configure the JWT settings:

{
  "JWT": {
    "Key": "YourSuperSecretKey",
    "Issuer": "YourIssuer",
    "Audience": "YourAudience",
    "DurationInMinutes": 60
  }
}

	•	Key: A secret key for signing JWT tokens.
	•	Issuer: Identifies the issuing server.
	•	Audience: The intended recipient (usually your API).
	•	DurationInMinutes: Token expiry duration.

4. Run Migrations

Ensure the database is up to date with entity migrations.

dotnet ef migrations add InitialMigration
dotnet ef database update

5. Build and Run the API

dotnet build
dotnet run

The API will run at http://localhost:5000 by default.

6. Access Swagger

To view the API documentation, navigate to:

http://localhost:5000/swagger

Testing

Unit Tests

This project uses Moq and xUnit for unit testing. To run the unit tests:

dotnet test

Unit tests are structured to test:

	•	Repository Layer
	•	Service Layer
	•	Controller Layer

Integration Tests

Integration tests can be configured to use an in-memory database or a testing PostgreSQL instance to ensure the full flow of data.

Logging

NLog is configured for logging. You can modify the log settings in the nlog.config file.

<nlog>
  <targets>
    <target name="logfile" xsi:type="File" fileName="logs/logfile.log" />
  </targets>
  <rules>
    <logger name="*" minlevel="Info" writeTo="logfile" />
  </rules>
</nlog>

Logs will be saved in the logs/logfile.log file.

Deployment

Deploying on IIS

	1.	Publish the API:
	•	Right-click on the project in Visual Studio and select Publish.
	•	Choose the IIS option and publish it to a folder.
	2.	Configure IIS:
	•	Add a new site in IIS and point the physical path to the published folder.
	•	Set the binding to the appropriate port (e.g., 85).
	•	Access the API via http://localhost:<port>/swagger.

Endpoints Overview

Endpoint	Method	Description
/api/Users/Register	POST	Register a new user
/api/Users/Login	POST	Login and generate JWT
/api/Users/UserInfo	GET	Get logged-in user info
/api/Users/{userId}/transactions	GET	Get all transactions for a user
/api/Users/{userId}/BudgetCategories	GET	Get all budget categories for a user
/api/Users/{userId}/Card	GET	Get all cards for a user

Contributing

	1.	Fork the repository
	2.	Create your feature branch (git checkout -b feature/YourFeature)
	3.	Commit your changes (git commit -m 'Add YourFeature')
	4.	Push to the branch (git push origin feature/YourFeature)
	5.	Open a pull request

License

This project is licensed under the MIT License. See the LICENSE file for details.

Contact

For any inquiries or support, contact Abdullah Tariq at abdullahtariq096@gmail.com.

