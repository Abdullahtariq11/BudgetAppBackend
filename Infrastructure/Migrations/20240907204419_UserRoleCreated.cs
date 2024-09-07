using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BudgetApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserRoleCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7c949a31-e687-4423-a5f1-8969373b190b", null, "Admin", "Admin" },
                    { "a927b9ef-6179-4db0-985f-ce8120aaa85c", null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a29f7b85-9f5f-4b0e-9497-9c6f91b8b1c4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e511a73a-210f-449d-9a5d-952f235b4ba7", "AQAAAAIAAYagAAAAEL84JOe6237l9sU9V9gpBgI8q5jzP89KACMKezhzwB26du9R6n1nLZlbvBXd/GuEUA==", "468ed373-8a55-4b1a-98f4-391bba2be82d" });

            migrationBuilder.InsertData(
                table: "BudgetCategories",
                columns: new[] { "BudgetCategoryId", "AllocatedAmount", "CategoryName", "LastUpdated", "RemainingAmount", "UserID" },
                values: new object[,]
                {
                    { new Guid("19781dca-8227-4f2a-a9c3-8b0ea867be8d"), 200m, "Entertainment", new DateTime(2024, 10, 7, 20, 44, 19, 377, DateTimeKind.Utc).AddTicks(3020), 0m, "a29f7b85-9f5f-4b0e-9497-9c6f91b8b1c4" },
                    { new Guid("d263c203-3632-422a-84ce-13cf5d24e5d0"), 500m, "Groceries", new DateTime(2024, 9, 7, 20, 44, 19, 377, DateTimeKind.Utc).AddTicks(3020), 0m, "a29f7b85-9f5f-4b0e-9497-9c6f91b8b1c4" }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "CardId", "Category", "Description", "TransactionDate", "Type", "UserID" },
                values: new object[,]
                {
                    { new Guid("ba6fac45-81a9-4336-86ad-1e1728a500e9"), 200m, new Guid("54e0c90e-1e91-42d1-8d24-8e00fa63ec0b"), "Groceries", "Weekly groceries", new DateTime(2024, 9, 7, 20, 44, 19, 377, DateTimeKind.Utc).AddTicks(3360), 1, "a29f7b85-9f5f-4b0e-9497-9c6f91b8b1c4" },
                    { new Guid("c2936e69-01bb-45c5-a604-dcb7f60b8c2c"), 500m, new Guid("54e0c90e-1e91-42d1-8d24-8e00fa63ec0b"), "Freelance", "Web development project", new DateTime(2024, 9, 7, 20, 44, 19, 377, DateTimeKind.Utc).AddTicks(3370), 0, "a29f7b85-9f5f-4b0e-9497-9c6f91b8b1c4" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c949a31-e687-4423-a5f1-8969373b190b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a927b9ef-6179-4db0-985f-ce8120aaa85c");

            migrationBuilder.DeleteData(
                table: "BudgetCategories",
                keyColumn: "BudgetCategoryId",
                keyValue: new Guid("19781dca-8227-4f2a-a9c3-8b0ea867be8d"));

            migrationBuilder.DeleteData(
                table: "BudgetCategories",
                keyColumn: "BudgetCategoryId",
                keyValue: new Guid("d263c203-3632-422a-84ce-13cf5d24e5d0"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("ba6fac45-81a9-4336-86ad-1e1728a500e9"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("c2936e69-01bb-45c5-a604-dcb7f60b8c2c"));

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
    }
}
