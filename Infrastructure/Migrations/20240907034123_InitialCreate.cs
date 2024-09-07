using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BudgetApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BudgetCategories",
                keyColumn: "BudgetCategoryId",
                keyValue: new Guid("2b67c8b2-f5c1-4560-a574-f3873cfc24f7"));

            migrationBuilder.DeleteData(
                table: "BudgetCategories",
                keyColumn: "BudgetCategoryId",
                keyValue: new Guid("d763bf77-a4e1-44ba-8dce-10638184ebb0"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("3f1d451c-a56d-4ab0-a6c1-29360f83a2df"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("8e094510-9c17-401e-bbd5-7ba415b22c16"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a29f7b85-9f5f-4b0e-9497-9c6f91b8b1c4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dcf9a4c7-aacd-491e-a145-d84e639af2c8", "AQAAAAIAAYagAAAAEAPK/i1kY1XBPxkBnTZX7DHWbHPW38aO+30DzFf+LRK63IIJOdI8XU0pjKnDdPkt6w==", "d4b03b5a-3107-45f2-b1f6-e9ff67f4b268" });

            migrationBuilder.InsertData(
                table: "BudgetCategories",
                columns: new[] { "BudgetCategoryId", "AllocatedAmount", "CategoryName", "LastUpdated", "RemainingAmount", "UserID" },
                values: new object[,]
                {
                    { new Guid("b336cbc3-409f-4554-ade4-e4388c4c7af2"), 200m, "Entertainment", new DateTime(2024, 10, 7, 3, 41, 23, 26, DateTimeKind.Utc).AddTicks(7760), 0m, "a29f7b85-9f5f-4b0e-9497-9c6f91b8b1c4" },
                    { new Guid("f377faa4-4336-4b2b-adc7-0aea3cc15e1b"), 500m, "Groceries", new DateTime(2024, 9, 7, 3, 41, 23, 26, DateTimeKind.Utc).AddTicks(7760), 0m, "a29f7b85-9f5f-4b0e-9497-9c6f91b8b1c4" }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "CardId", "Category", "Description", "TransactionDate", "Type", "UserID" },
                values: new object[,]
                {
                    { new Guid("0ee1dfb2-ba31-4887-a753-6123d1fe4c95"), 200m, new Guid("54e0c90e-1e91-42d1-8d24-8e00fa63ec0b"), "Groceries", "Weekly groceries", new DateTime(2024, 9, 7, 3, 41, 23, 26, DateTimeKind.Utc).AddTicks(8080), 1, "a29f7b85-9f5f-4b0e-9497-9c6f91b8b1c4" },
                    { new Guid("cc25f84c-b612-40c6-aa7f-a9e167b769ec"), 500m, new Guid("54e0c90e-1e91-42d1-8d24-8e00fa63ec0b"), "Freelance", "Web development project", new DateTime(2024, 9, 7, 3, 41, 23, 26, DateTimeKind.Utc).AddTicks(8090), 0, "a29f7b85-9f5f-4b0e-9497-9c6f91b8b1c4" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BudgetCategories",
                keyColumn: "BudgetCategoryId",
                keyValue: new Guid("b336cbc3-409f-4554-ade4-e4388c4c7af2"));

            migrationBuilder.DeleteData(
                table: "BudgetCategories",
                keyColumn: "BudgetCategoryId",
                keyValue: new Guid("f377faa4-4336-4b2b-adc7-0aea3cc15e1b"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("0ee1dfb2-ba31-4887-a753-6123d1fe4c95"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("cc25f84c-b612-40c6-aa7f-a9e167b769ec"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a29f7b85-9f5f-4b0e-9497-9c6f91b8b1c4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "906fba59-66db-4b10-b7bb-500255036e99", "AQAAAAIAAYagAAAAED/55ys55my9V7VIKPLoqFq9l6vyUDrACnR6bWKFbKy0B6/+liP7YysM1NfMB4gBXg==", "67bb697c-6ecc-4bf4-abef-c60c4726e701" });

            migrationBuilder.InsertData(
                table: "BudgetCategories",
                columns: new[] { "BudgetCategoryId", "AllocatedAmount", "CategoryName", "LastUpdated", "RemainingAmount", "UserID" },
                values: new object[,]
                {
                    { new Guid("2b67c8b2-f5c1-4560-a574-f3873cfc24f7"), 500m, "Groceries", new DateTime(2024, 9, 6, 6, 1, 29, 320, DateTimeKind.Utc).AddTicks(8972), 0m, "a29f7b85-9f5f-4b0e-9497-9c6f91b8b1c4" },
                    { new Guid("d763bf77-a4e1-44ba-8dce-10638184ebb0"), 200m, "Entertainment", new DateTime(2024, 10, 6, 6, 1, 29, 320, DateTimeKind.Utc).AddTicks(8977), 0m, "a29f7b85-9f5f-4b0e-9497-9c6f91b8b1c4" }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "CardId", "Category", "Description", "TransactionDate", "Type", "UserID" },
                values: new object[,]
                {
                    { new Guid("3f1d451c-a56d-4ab0-a6c1-29360f83a2df"), 500m, new Guid("54e0c90e-1e91-42d1-8d24-8e00fa63ec0b"), "Freelance", "Web development project", new DateTime(2024, 9, 6, 6, 1, 29, 320, DateTimeKind.Utc).AddTicks(9554), 0, "a29f7b85-9f5f-4b0e-9497-9c6f91b8b1c4" },
                    { new Guid("8e094510-9c17-401e-bbd5-7ba415b22c16"), 200m, new Guid("54e0c90e-1e91-42d1-8d24-8e00fa63ec0b"), "Groceries", "Weekly groceries", new DateTime(2024, 9, 6, 6, 1, 29, 320, DateTimeKind.Utc).AddTicks(9550), 1, "a29f7b85-9f5f-4b0e-9497-9c6f91b8b1c4" }
                });
        }
    }
}
