using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityText.Migrations
{
    /// <inheritdoc />
    public partial class addCodeForStuSuscmkl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Enrollments_EnrollmentId",
                table: "Subscriptions");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7aafd540-fdf8-482b-804d-780fb6726703",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca8ab646-b2ac-4bbe-83e9-9bf4dc6b6f0f", "AQAAAAIAAYagAAAAEF1P/gJQhOYB5VQB80vSIvVnMyP8YQ65EBLwjrM3QsxkHo1agTqPuTpxsQww8KG6cQ==", "3b8459b4-a248-4ee0-9c4e-6980173d8a98" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b4cd611-6c35-4c98-a0dc-1d2e1349ab91",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c02f6cde-a5db-47f4-9889-a154984c2785", "AQAAAAIAAYagAAAAEEASGBLqdRnTag83gPHed618jHkbZbXe8ygDDcmpHF7jNQ5jc40kjCZ8xOHW856ZQg==", "99cb9949-9601-4e4b-b74e-d44eb7f171c1" });

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Enrollments_EnrollmentId",
                table: "Subscriptions",
                column: "EnrollmentId",
                principalTable: "Enrollments",
                principalColumn: "EnrollmentId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Enrollments_EnrollmentId",
                table: "Subscriptions");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Enrollments_EnrollmentId",
                table: "Subscriptions",
                column: "EnrollmentId",
                principalTable: "Enrollments",
                principalColumn: "EnrollmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
