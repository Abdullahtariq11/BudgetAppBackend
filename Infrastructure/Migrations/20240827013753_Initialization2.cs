using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BudgetApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initialization2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Budgets",
                keyColumn: "BudgetId",
                keyValue: new Guid("52b557c0-b30e-4f15-8da5-52ff79461320"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("05750d24-fa99-4e21-81ac-8f4a91c0383a"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("aeff724f-ec4c-4548-9603-608fa77bf8a7"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("f0fc5345-2490-4fb0-883d-f5bbfb8e53da"));

            migrationBuilder.InsertData(
                table: "Budgets",
                columns: new[] { "BudgetId", "EndDate", "Name", "StartDate", "TotalAmount" },
                values: new object[] { new Guid("6fd88047-f440-4d32-89b9-fd472b2bb5bc"), new DateTime(2024, 9, 27, 1, 37, 52, 800, DateTimeKind.Utc).AddTicks(3628), "Monthly Budget", new DateTime(2024, 8, 27, 1, 37, 52, 800, DateTimeKind.Utc).AddTicks(3628), 2000m });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "Category", "Description", "TransactionDate", "Type" },
                values: new object[,]
                {
                    { new Guid("1c19ee4b-0d1a-4aed-84cb-7543ca065eff"), 1000m, "Salary", "Monthly salary", new DateTime(2024, 7, 27, 1, 37, 52, 800, DateTimeKind.Utc).AddTicks(3765), 0 },
                    { new Guid("9ef9bd57-831e-4e92-8f88-f440c303313d"), 200m, "Groceries", "Weekly groceries", new DateTime(2024, 8, 17, 1, 37, 52, 800, DateTimeKind.Utc).AddTicks(3770), 1 },
                    { new Guid("e82c3eac-09cf-4596-9565-c748e2fc210b"), 50m, "Entertainment", "Movie night", new DateTime(2024, 8, 22, 1, 37, 52, 800, DateTimeKind.Utc).AddTicks(3782), 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Budgets",
                keyColumn: "BudgetId",
                keyValue: new Guid("6fd88047-f440-4d32-89b9-fd472b2bb5bc"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("1c19ee4b-0d1a-4aed-84cb-7543ca065eff"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("9ef9bd57-831e-4e92-8f88-f440c303313d"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("e82c3eac-09cf-4596-9565-c748e2fc210b"));

            migrationBuilder.InsertData(
                table: "Budgets",
                columns: new[] { "BudgetId", "EndDate", "Name", "StartDate", "TotalAmount" },
                values: new object[] { new Guid("52b557c0-b30e-4f15-8da5-52ff79461320"), new DateTime(2024, 9, 27, 1, 33, 31, 705, DateTimeKind.Utc).AddTicks(4594), "Monthly Budget", new DateTime(2024, 8, 27, 1, 33, 31, 705, DateTimeKind.Utc).AddTicks(4593), 2000m });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "Category", "Description", "TransactionDate", "Type" },
                values: new object[,]
                {
                    { new Guid("05750d24-fa99-4e21-81ac-8f4a91c0383a"), 1000m, "Salary", "Monthly salary", new DateTime(2024, 7, 27, 1, 33, 31, 705, DateTimeKind.Utc).AddTicks(4706), 0 },
                    { new Guid("aeff724f-ec4c-4548-9603-608fa77bf8a7"), 200m, "Groceries", "Weekly groceries", new DateTime(2024, 8, 17, 1, 33, 31, 705, DateTimeKind.Utc).AddTicks(4709), 1 },
                    { new Guid("f0fc5345-2490-4fb0-883d-f5bbfb8e53da"), 50m, "Entertainment", "Movie night", new DateTime(2024, 8, 22, 1, 33, 31, 705, DateTimeKind.Utc).AddTicks(4767), 1 }
                });
        }
    }
}
