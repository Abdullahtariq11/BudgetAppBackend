using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BudgetApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class configuringTransactionToDeleteWithCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Cards_CardId",
                table: "Transactions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5da6616f-93e3-4b2e-9e57-f00060cdd239");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c8ae361-82df-4fb3-9652-6b646265b57f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1f926960-918a-42ab-876f-b13c13247e68", null, "Customer", "CUSTOMER" },
                    { "f36104bc-140c-4270-a7f2-5a9cb0ac19c8", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a29f7b85-9f5f-4b0e-9497-9c6f91b8b1c4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b737e8a-ec85-45a0-8670-8e5cfd9102c8", "AQAAAAIAAYagAAAAEAtGnBrUsOyEaaRGp+8aIXBE2z4X0GeoVIilwqhxKrtIdZAT9t6sYjCPEQmYYjsSSA==", "ef94ae1e-d77c-45ea-957d-46626c56b85f" });

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Cards_CardId",
                table: "Transactions",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "CardId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Cards_CardId",
                table: "Transactions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f926960-918a-42ab-876f-b13c13247e68");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f36104bc-140c-4270-a7f2-5a9cb0ac19c8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5da6616f-93e3-4b2e-9e57-f00060cdd239", null, "Customer", "CUSTOMER" },
                    { "6c8ae361-82df-4fb3-9652-6b646265b57f", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a29f7b85-9f5f-4b0e-9497-9c6f91b8b1c4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "62c03d65-7850-482d-98c6-150c4c322464", "AQAAAAIAAYagAAAAEF/BOFslqr1BY+wxdLY4kil6CXIVGNANVSjIa5WKkZ4QzVgrsJ5d1YD+h4FD4kJhgg==", "f360bd1e-37c4-42bf-86df-4d9569e294a3" });

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Cards_CardId",
                table: "Transactions",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "CardId",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
