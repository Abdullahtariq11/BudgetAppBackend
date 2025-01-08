# Budget App Backend

![GitHub Stars](https://img.shields.io/github/stars/AbdullahTariq11/BudgetAppBackend)
![GitHub License](https://img.shields.io/github/license/AbdullahTariq11/BudgetAppBackend)

## Table of Contents

1. [Introduction](#introduction)
2. [Features](#features)
3. [API Endpoints](#api-endpoints)
   - [User Authentication](#user-authentication)
   - [Expense Tracking](#expense-tracking)
   - [Category Management](#category-management)
   - [Card Management](#card-management)
4. [Database Schema](#database-schema)
   - [User](#user)
   - [Expense](#expense)
   - [Category](#category)
   - [Card](#card)
5. [Technologies Used](#technologies-used)
6. [Project Structure](#project-structure)
7. [Getting Started](#getting-started)
   - [Prerequisites](#prerequisites)
   - [Installation](#installation)
8. [Contributing](#contributing)
9. [License](#license)
10. [Contact](#contact)

## Introduction

The **Budget App** is a personal finance application designed to help users track expenses, manage budgets, and gain insights into their spending habits. This repository contains the backend code for the application, developed using **ASP.NET Core Web API** with a **PostgreSQL database**.

## Features

- **User Authentication**: Secure user registration and login with password hashing.
- **Expense Tracking**: Add, edit, delete, and view expenses with details such as date, amount, and category.
- **Category Management**: Create, update, and delete expense categories for organized tracking.
- **Card Management**: Manage user cards, including adding, editing, and deleting cards.
- **Budgeting**: Set budgets for different categories and monitor spending.
- **Reporting**: Generate reports to visualize spending trends over time.

## API Endpoints

### User Authentication

| Endpoint       | Method | Description            |
| -------------- | ------ | ---------------------- |
| `/user/signup` | POST   | Register a new user    |
| `/user/login`  | POST   | Login an existing user |

### Expense Tracking

| Endpoint                                  | Method | Description                     |
| ----------------------------------------- | ------ | ------------------------------- |
| `/expense/add`                            | POST   | Add a new expense               |
| `/expense/edit/{id:int}`                  | PUT    | Edit an existing expense        |
| `/expense/delete/{id:int}`                | DELETE | Delete an expense               |
| `/expense/get`                            | GET    | Retrieve all expenses           |
| `/expense/get/{id:int}`                   | GET    | Retrieve an expense by ID       |
| `/expense/getByCategory/{categoryId:int}` | GET    | Retrieve expenses by category   |
| `/expense/getByDate`                      | GET    | Retrieve expenses by date range |

### Category Management

| Endpoint                    | Method | Description               |
| --------------------------- | ------ | ------------------------- |
| `/category/add`             | POST   | Add a new category        |
| `/category/edit/{id:int}`   | PUT    | Edit an existing category |
| `/category/delete/{id:int}` | DELETE | Delete a category         |
| `/category/get`             | GET    | Retrieve all categories   |
| `/category/get/{id:int}`    | GET    | Retrieve a category by ID |

### Card Management

| Endpoint                    | Method | Description               |
| --------------------------- | ------ | ------------------------- |
| `/card/add`                 | POST   | Add a new card            |
| `/card/edit/{id:int}`       | PUT    | Edit an existing card     |
| `/card/delete/{id:int}`     | DELETE | Delete a card             |
| `/card/get`                 | GET    | Retrieve all cards        |
| `/card/get/{id:int}`        | GET    | Retrieve a card by ID     |

## Database Schema

The database schema consists of four main tables:

### User

| Column   | Data Type | Description            |
| -------- | --------- | ---------------------- |
| UserId   | int       | Primary key, user ID   |
| Username | string    | User’s unique username |
| Email    | string    | User’s email address   |
| Password | string    | Hashed user password   |

### Expense

| Column      | Data Type | Description                       |
| ----------- | --------- | --------------------------------- |
| ExpenseId   | int       | Primary key, expense ID           |
| UserId      | int       | Foreign key, linked to User table |
| CategoryId  | int       | Foreign key, linked to Category   |
| Date        | date      | Expense date                      |
| Amount      | decimal   | Expense amount                    |
| Description | string    | Optional description              |

### Category

| Column     | Data Type | Description                       |
| ---------- | --------- | --------------------------------- |
| CategoryId | int       | Primary key, category ID          |
| UserId     | int       | Foreign key, linked to User table |
| Name       | string    | Name of the category              |
| Budget     | decimal   | Optional budget amount            |

### Card

| Column     | Data Type | Description                       |
| ---------- | --------- | --------------------------------- |
| CardId     | int       | Primary key, card ID              |
| UserId     | int       | Foreign key, linked to User table |
| CardName   | string    | Name of the card                  |
| Balance    | decimal   | Current balance on the card       |

## Technologies Used

- **.NET 7**
- **ASP.NET Core Web API**
- **PostgreSQL**
- **Entity Framework Core**
- **AutoMapper**
- **Swashbuckle** (Swagger UI)
- **BCrypt.Net-Core** (Password hashing)
- **NLog** (Advanced logging)
- **xUnit and Moq** (Unit testing)

## Project Structure

- `Controllers`: Handles API requests and responses.
- `Data`: Includes database context and DTOs (Data Transfer Objects).
- `Migrations`: Contains database migration files.
- `Models`: Defines database entity models.
- `Profiles`: Configures AutoMapper mappings.
- `Middleware`: Contains custom middleware for exception handling.
- `Logging`: Configures logging using NLog.
- `Tests`: Contains unit tests for the project.

## Getting Started

### Prerequisites

- **.NET 7 SDK**
- **PostgreSQL Database**

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/AbdullahTariq11/BudgetAppBackend.git
   ```
2. Configure the database connection string in `appsettings.json`.
3. Run database migrations:
   ```bash
   dotnet ef database update
   ```
4. Build and run the application:
   ```bash
   dotnet run
   ```

## Contributing

Contributions are welcome! Feel free to submit issues and pull requests.

## License

This project is licensed under the MIT License. See the [LICENSE](https://github.com/AbdullahTariq11/BudgetAppBackend/blob/main/LICENSE) file for details.

## Contact

- **Developer**: Abdullah Tariq
- **Email**: [abdullahtariq096@gmail.com](mailto:abdullahtariq096@gmail.com)
- **Project Link**: [GitHub Repository](https://github.com/AbdullahTariq11/BudgetAppBackend)

