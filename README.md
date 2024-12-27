# 💰 **BudgetApp API**

**BudgetApp API** is a robust financial management API developed with **ASP.NET Core Web API**. It enables users to manage transactions, budget categories, and cards with a secure authentication system powered by **JWT** (JSON Web Token). The API ensures scalability, clean architecture, and maintainability with modern development practices.

---

## ✨ **Features**

- 🔐 **User Authentication**: Secure user registration and login with JWT-based authentication.  
- 📊 **Transaction Management**: Create, read, update, and delete (CRUD) user transactions.  
- 🗂️ **Budget Categories**: Manage budget categories with CRUD operations.  
- 💳 **Card Management**: Add, view, update, and delete cards.  
- 🛠️ **Custom Middleware**: Handle exceptions with custom middleware.  
- 📜 **Integrated Logging**: Use **NLog** for advanced logging.  
- 🔒 **Secured Endpoints**: Token-based authentication for secure API access.  
- 📖 **API Documentation**: Swagger integration for detailed API documentation.  

---

## 🛠️ **Technologies Used**

- **Backend Framework**: ASP.NET Core Web API  
- **Database**: PostgreSQL  
- **Authentication**: JWT (JSON Web Tokens)  
- **Logging**: NLog  
- **Dependency Injection**: ASP.NET Core DI  
- **Testing**: xUnit and Moq for unit testing  
- **API Documentation**: Swagger  

---

## 📂 **Project Structure**

```plaintext
BudgetAppBackend/
│
├── API/              # Controllers and middleware for HTTP requests
├── Application/      # Business logic services
├── Domain/           # Entity models and domain contracts
├── Infrastructure/   # Data access layer (repositories and EF context)
├── Shared/           # DTOs and common utility classes
└── BudgetAppBackend.sln
```

---

## 🚀 **Getting Started**

### Prerequisites

- **.NET 6 SDK** or later  
- **PostgreSQL Database**  
- **Visual Studio** or **VS Code**  
- **IIS** (Optional for deployment)  
- **NLog** for logging configuration  

---

### ⚙️ **Setup**

#### 1. **Clone the Repository**
```bash
git clone https://github.com/Abdullahtariq11/BudgetAppBackend.git
cd BudgetAppBackend
```

#### 2. **Configure PostgreSQL Database**
Update the `appsettings.json` file with your PostgreSQL connection string:
```json
"ConnectionStrings": {
  "PostgresConnectionString": "Server=localhost;Port=5432;Database=BudgetDb;UserId=postgres;Password=YourPassword;"
}
```

#### 3. **Configure JWT Authentication**
Add your JWT settings in `appsettings.json`:
```json
"JWT": {
  "Key": "YourSuperSecretKey",
  "Issuer": "YourIssuer",
  "Audience": "YourAudience",
  "DurationInMinutes": 60
}
```

#### 4. **Run Migrations**
Apply migrations to set up the database schema:
```bash
dotnet ef migrations add InitialMigration
dotnet ef database update
```

#### 5. **Build and Run the API**
```bash
dotnet build
dotnet run
```
The API will be available at: `http://localhost:5000`.

#### 6. **Access Swagger**
View detailed API documentation at:
```
http://localhost:5000/swagger
```

---

## 🔍 **Endpoints Overview**

| **Endpoint**                  | **Method** | **Description**                                   |
|--------------------------------|------------|---------------------------------------------------|
| `/api/Users/Register`          | `POST`     | Register a new user                              |
| `/api/Users/Login`             | `POST`     | Login and generate JWT                           |
| `/api/Users/UserInfo`          | `GET`      | Get logged-in user information                   |
| `/api/Users/{userId}/transactions` | `GET`   | Get all transactions for a user                  |
| `/api/Users/{userId}/BudgetCategories` | `GET`| Get all budget categories for a user             |
| `/api/Users/{userId}/Card`     | `GET`      | Get all cards for a user                         |

---

## 🧪 **Testing**

### Unit Tests
Run unit tests to ensure the correctness of services and controllers:
```bash
dotnet test
```
Unit tests cover:
- Repository Layer  
- Service Layer  
- Controller Layer  

### Integration Tests
Integration tests use an **in-memory database** or a test PostgreSQL instance to validate end-to-end functionality.

---

## 📝 **Logging**

- **NLog** is used for logging. Configuration can be adjusted in the `nlog.config` file.  
- Logs are saved in the `logs/logfile.log` file.

---

## 📦 **Deployment**

### Deploying on IIS

1. **Publish the API**:
   - In Visual Studio, right-click the project and select `Publish`.
   - Choose the IIS option and publish to a folder.

2. **Configure IIS**:
   - Add a new site in IIS and point it to the published folder.
   - Bind the site to the desired port (e.g., 85).

3. **Access the API**:
   - API available at: `http://localhost:<port>/swagger`.

---

## 🤝 **Contributing**

1. Fork the repository.  
2. Create a feature branch:  
   ```bash
   git checkout -b feature/YourFeature
   ```
3. Commit your changes:  
   ```bash
   git commit -m 'Add YourFeature'
   ```
4. Push to the branch:  
   ```bash
   git push origin feature/YourFeature
   ```
5. Open a pull request.

---

## 📜 **License**

This project is licensed under the **MIT License**. See the `LICENSE` file for details.

---

## 📧 **Contact**

For inquiries or support, contact:  
**Abdullah Tariq**  
📧 Email: [abdullahtariq096@gmail.com](mailto:abdullahtariq096@gmail.com)

---

### 🌟 **"Manage your finances, simplify your life!"**  

Feel free to suggest any improvements or report issues in the repository. Happy coding! 🎉
