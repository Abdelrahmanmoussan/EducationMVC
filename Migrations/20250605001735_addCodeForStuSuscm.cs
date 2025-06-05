using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IdentityText.Migrations
{
    /// <inheritdoc />
    public partial class addCodeForStuSuscm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "SubscriptionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "SubscriptionId",
                keyValue: 2);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7aafd540-fdf8-482b-804d-780fb6726703",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "03b33cbd-090b-4837-9f34-83ce91537736", "AQAAAAIAAYagAAAAEH7XTHlgU5SQZ7esL2kgl2O0gF90B2DfFpnfJwv5Qx1c7L/PYC+5liKEOnNJNrGscw==", "66bf6314-3759-4b05-a660-0ad710648a93" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b4cd611-6c35-4c98-a0dc-1d2e1349ab91",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d270f5d3-f95c-4c34-948f-858fbf9bf75e", "AQAAAAIAAYagAAAAED3QeOYRtRrjB6IQjDoyrUaKZXc2DHaw+ug0yLv5jWIKhLOmk7hFQ7PueugQBEqN5w==", "1fb3c3bd-d814-4300-8f53-8fa387133add" });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "SubscriptionId", "Code", "EndDate", "EnrollmentId", "StartDate", "SubscriptionStatus" },
                values: new object[,]
                {
                    { 1, "SUBS2024A", new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 2, "SUBS2023B", new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });
        }
    }
}
