﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BudgetApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initialization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Budgets",
                columns: table => new
                {
                    BudgetId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budgets", x => x.BudgetId);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                });

            migrationBuilder.CreateTable(
                name: "BudgetCategories",
                columns: table => new
                {
                    BudgetCategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    AllocatedAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    CategoryName = table.Column<string>(type: "text", nullable: false),
                    BudgetId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetCategories", x => x.BudgetCategoryId);
                    table.ForeignKey(
                        name: "FK_BudgetCategories_Budgets_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budgets",
                        principalColumn: "BudgetId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_BudgetCategories_BudgetId",
                table: "BudgetCategories",
                column: "BudgetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BudgetCategories");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Budgets");
        }
    }
}
