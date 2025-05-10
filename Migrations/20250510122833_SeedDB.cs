using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityText.Migrations
{
    /// <inheritdoc />
    public partial class SeedDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7aafd540-fdf8-482b-804d-780fb6726703",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "df7856a2-e168-4d5b-aa8e-bba106ca1ade", "AQAAAAIAAYagAAAAEDstiwxt0/ZVBrvp6m4JVr1Ul65nLui4i/IFrXefUHqzp1+MKR2j2SeC8tTd0LPaTw==", "417dda73-a6fe-47d9-bbbb-16b46887b302" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9b4cd611-6c35-4c98-a0dc-1d2e1349ab91", 0, "Port Said", "576b8d72-4852-4b49-9743-d71c83ffd7e0", "abdelrahmanmoussan@gmail.com", true, "Abdelrahman", "Moussan", false, null, "ABDELRAHMANMOUSSAN@GMAIL.COM", "ABDELRAHMAN", "AQAAAAIAAYagAAAAEF+6jEjek8+AwvW0UQHzVCo1X3rXzwUNHGeQ/Hb7S+iBVCEMRgFvBRT15Y4cuvjxUg==", null, false, "Moussan.jpg", "07dfd264-45d8-45e1-acfe-800bb237401c", false, "abdelrahman" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5aa54943-8b55-4399-91b7-d247ab235cf3", "9b4cd611-6c35-4c98-a0dc-1d2e1349ab91" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5aa54943-8b55-4399-91b7-d247ab235cf3", "9b4cd611-6c35-4c98-a0dc-1d2e1349ab91" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b4cd611-6c35-4c98-a0dc-1d2e1349ab91");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7aafd540-fdf8-482b-804d-780fb6726703",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8820c25-4fa0-4705-9ddd-58bd36543a5a", "AQAAAAIAAYagAAAAEBPAcrYmYs29d9fXXGj/6KwpSHqzd0Z0YBsENNcbYDkopatOAJuAXAyoyH6qqFJSLA==", "eae13608-ef9d-43b8-ae6a-a3282d91f9b1" });
        }
    }
}
