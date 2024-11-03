using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BudgetApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSetupCompleteToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f926960-918a-42ab-876f-b13c13247e68");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f36104bc-140c-4270-a7f2-5a9cb0ac19c8");

            migrationBuilder.AddColumn<bool>(
                name: "SetupComplete",
                table: "AspNetUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d089b4ef-0bdf-4798-b205-0c9d80e4c53f", null, "Admin", "ADMIN" },
                    { "fd4c2929-6d9a-45db-bdab-6503da9457eb", null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a29f7b85-9f5f-4b0e-9497-9c6f91b8b1c4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "SetupComplete" },
                values: new object[] { "37629444-f7b2-4b55-9a2c-265300c54157", "AQAAAAIAAYagAAAAEFz3TLwQBmahRoIyepSqFmMfQ3noqKcZWp6TJOYTXL07o8IZ7+Kx7F3u4NHMEeBzFQ==", "e46b8ba7-cfd1-400f-8679-dd141bf60d39", false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d089b4ef-0bdf-4798-b205-0c9d80e4c53f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd4c2929-6d9a-45db-bdab-6503da9457eb");

            migrationBuilder.DropColumn(
                name: "SetupComplete",
                table: "AspNetUsers");

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
        }
    }
}
