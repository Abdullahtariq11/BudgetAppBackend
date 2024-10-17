using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BudgetApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class subCardTypeAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a04b096-1d95-448f-8a07-ec00b72c8b69");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71a1797a-b2fa-4c77-b50d-4adad0744e25");

            migrationBuilder.DeleteData(
                table: "BudgetCategories",
                keyColumn: "BudgetCategoryId",
                keyValue: new Guid("435b7e31-96b0-4703-9958-623b7a018a86"));

            migrationBuilder.DeleteData(
                table: "BudgetCategories",
                keyColumn: "BudgetCategoryId",
                keyValue: new Guid("57270de8-4b7e-4346-9f76-bf2d1d85a6aa"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("1303f4a7-4480-4e08-a93e-c6726b353c8b"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("a04d5e01-1428-415b-895c-a50c5bf3f5b6"));

            migrationBuilder.AddColumn<int>(
                name: "subCardType",
                table: "Cards",
                type: "integer",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1b70b871-c457-4380-bec7-526c1952805b", null, "Admin", "ADMIN" },
                    { "9a8ba66e-520f-4f0b-9235-6efde8debb30", null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a29f7b85-9f5f-4b0e-9497-9c6f91b8b1c4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4a8c680f-aec9-426f-917d-f39d9853eddf", "AQAAAAIAAYagAAAAEGRmKYaO/jde8EAjpoa/A8Zf429o17fn39gWF1kGG+aJS0wWMrdlqL8QYjIzLF3F0A==", "cfbaebde-c6a7-4825-9ebb-1120ce497b62" });

            migrationBuilder.InsertData(
                table: "BudgetCategories",
                columns: new[] { "BudgetCategoryId", "AllocatedAmount", "CategoryName", "LastUpdated", "RemainingAmount", "UserID" },
                values: new object[,]
                {
                    { new Guid("7ef4c015-253c-4aed-b053-3742eb5db660"), 200m, "Entertainment", new DateTime(2024, 11, 17, 3, 40, 55, 815, DateTimeKind.Utc).AddTicks(3530), 0m, "a29f7b85-9f5f-4b0e-9497-9c6f91b8b1c4" },
                    { new Guid("e7464c74-478b-4081-b4cc-fcf71d563a8c"), 500m, "Groceries", new DateTime(2024, 10, 17, 3, 40, 55, 815, DateTimeKind.Utc).AddTicks(3520), 0m, "a29f7b85-9f5f-4b0e-9497-9c6f91b8b1c4" }
                });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "CardId",
                keyValue: new Guid("54e0c90e-1e91-42d1-8d24-8e00fa63ec0b"),
                column: "subCardType",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "CardId",
                keyValue: new Guid("abf2b781-ea45-4d36-b5f7-3c6fd7e4bdf7"),
                column: "subCardType",
                value: null);

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "CardId", "Category", "Description", "TransactionDate", "Type", "UserID" },
                values: new object[,]
                {
                    { new Guid("8e2deff2-88e0-4c7a-8e93-e127fc7f7dba"), 500m, new Guid("54e0c90e-1e91-42d1-8d24-8e00fa63ec0b"), "Freelance", "Web development project", new DateTime(2024, 10, 17, 3, 40, 55, 815, DateTimeKind.Utc).AddTicks(3870), 0, "a29f7b85-9f5f-4b0e-9497-9c6f91b8b1c4" },
                    { new Guid("dad18e95-30cc-494b-a728-b9f05d17e132"), 200m, new Guid("54e0c90e-1e91-42d1-8d24-8e00fa63ec0b"), "Groceries", "Weekly groceries", new DateTime(2024, 10, 17, 3, 40, 55, 815, DateTimeKind.Utc).AddTicks(3860), 1, "a29f7b85-9f5f-4b0e-9497-9c6f91b8b1c4" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b70b871-c457-4380-bec7-526c1952805b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a8ba66e-520f-4f0b-9235-6efde8debb30");

            migrationBuilder.DeleteData(
                table: "BudgetCategories",
                keyColumn: "BudgetCategoryId",
                keyValue: new Guid("7ef4c015-253c-4aed-b053-3742eb5db660"));

            migrationBuilder.DeleteData(
                table: "BudgetCategories",
                keyColumn: "BudgetCategoryId",
                keyValue: new Guid("e7464c74-478b-4081-b4cc-fcf71d563a8c"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("8e2deff2-88e0-4c7a-8e93-e127fc7f7dba"));

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("dad18e95-30cc-494b-a728-b9f05d17e132"));

            migrationBuilder.DropColumn(
                name: "subCardType",
                table: "Cards");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3a04b096-1d95-448f-8a07-ec00b72c8b69", null, "Customer", "CUSTOMER" },
                    { "71a1797a-b2fa-4c77-b50d-4adad0744e25", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a29f7b85-9f5f-4b0e-9497-9c6f91b8b1c4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1473908f-2d87-4668-81af-624d40c2013a", "AQAAAAIAAYagAAAAELPHMVwaD5wEdEFMP5gGSoFcdcqtAnqQP0qD5u4GoDBzZCr1PT5/TLNQYCuh4k+Ynw==", "8c208bfd-7934-4c72-bb11-bbb08fcb6317" });

            migrationBuilder.InsertData(
                table: "BudgetCategories",
                columns: new[] { "BudgetCategoryId", "AllocatedAmount", "CategoryName", "LastUpdated", "RemainingAmount", "UserID" },
                values: new object[,]
                {
                    { new Guid("435b7e31-96b0-4703-9958-623b7a018a86"), 200m, "Entertainment", new DateTime(2024, 10, 9, 5, 34, 25, 232, DateTimeKind.Utc).AddTicks(760), 0m, "a29f7b85-9f5f-4b0e-9497-9c6f91b8b1c4" },
                    { new Guid("57270de8-4b7e-4346-9f76-bf2d1d85a6aa"), 500m, "Groceries", new DateTime(2024, 9, 9, 5, 34, 25, 232, DateTimeKind.Utc).AddTicks(750), 0m, "a29f7b85-9f5f-4b0e-9497-9c6f91b8b1c4" }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "CardId", "Category", "Description", "TransactionDate", "Type", "UserID" },
                values: new object[,]
                {
                    { new Guid("1303f4a7-4480-4e08-a93e-c6726b353c8b"), 500m, new Guid("54e0c90e-1e91-42d1-8d24-8e00fa63ec0b"), "Freelance", "Web development project", new DateTime(2024, 9, 9, 5, 34, 25, 232, DateTimeKind.Utc).AddTicks(1100), 0, "a29f7b85-9f5f-4b0e-9497-9c6f91b8b1c4" },
                    { new Guid("a04d5e01-1428-415b-895c-a50c5bf3f5b6"), 200m, new Guid("54e0c90e-1e91-42d1-8d24-8e00fa63ec0b"), "Groceries", "Weekly groceries", new DateTime(2024, 9, 9, 5, 34, 25, 232, DateTimeKind.Utc).AddTicks(1090), 1, "a29f7b85-9f5f-4b0e-9497-9c6f91b8b1c4" }
                });
        }
    }
}
