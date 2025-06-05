using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityText.Migrations
{
    /// <inheritdoc />
    public partial class addCodeForStuSuscmk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7aafd540-fdf8-482b-804d-780fb6726703",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f6c9e7b6-8a95-48d4-aa73-f3a2ccaf03d9", "AQAAAAIAAYagAAAAEBULOq1jxG04g0PGS2RvL+sFmQ6vV8x0vsZ3TlNM2ej83ZLnw5SgMmAOGCTdk1oPdw==", "e5952ff6-25ed-4b4a-85d1-ef880a57f53a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b4cd611-6c35-4c98-a0dc-1d2e1349ab91",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8d77576f-c42d-4ff7-a379-fbabffdc8284", "AQAAAAIAAYagAAAAEE3F4egg733R9nJiUgEKJ6RVq3C/wj6lljcvYjPlRN/Huq8vIWlDfnR884yWldMQhA==", "d5062719-942f-4770-8ddd-7f9e686fa9ed" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7aafd540-fdf8-482b-804d-780fb6726703",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d3f1a00-f944-4296-85d5-498381af8ce6", "AQAAAAIAAYagAAAAEH9TJ/tp4gbajnW0zKmFOYvtihFuWCqwrQMji4xdLMXoc1ShtepQY6F2EUtx1AZ2oQ==", "83d9d05b-3819-4f30-9c36-399cb018e742" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b4cd611-6c35-4c98-a0dc-1d2e1349ab91",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87a31e6b-d010-4dbf-b933-ea80595812c5", "AQAAAAIAAYagAAAAEEUw3PpcNFBaCkQnZ9g/eUcPidmX77b1ke7RWzFq2Np2FvwJOQJkEzhsFO5VpxnXBA==", "227976e9-6c83-4df7-8822-9681e2d6cce1" });
        }
    }
}
