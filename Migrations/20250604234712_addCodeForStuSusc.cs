using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityText.Migrations
{
    /// <inheritdoc />
    public partial class addCodeForStuSusc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Subscriptions_SubscriptionId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_SubscriptionId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SubscriptionId",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "EnrollmentId",
                table: "Subscriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.UpdateData(
                table: "Subscriptions",
                keyColumn: "SubscriptionId",
                keyValue: 1,
                column: "EnrollmentId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Subscriptions",
                keyColumn: "SubscriptionId",
                keyValue: 2,
                column: "EnrollmentId",
                value: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_Code",
                table: "Subscriptions",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_EnrollmentId",
                table: "Subscriptions",
                column: "EnrollmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Enrollments_EnrollmentId",
                table: "Subscriptions",
                column: "EnrollmentId",
                principalTable: "Enrollments",
                principalColumn: "EnrollmentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Enrollments_EnrollmentId",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_Code",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_EnrollmentId",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "EnrollmentId",
                table: "Subscriptions");

            migrationBuilder.AddColumn<int>(
                name: "SubscriptionId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7aafd540-fdf8-482b-804d-780fb6726703",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d7b7edb-0bcc-499c-b348-7a6277562308", "AQAAAAIAAYagAAAAEO4NisRugTFKdhV+9YyTx1q9oYgS0z+BuBdax3heDo22SzFnoIFKebZVjlfhY93h2A==", "65450262-d48a-42bb-9ee5-40faf2c31bc7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b4cd611-6c35-4c98-a0dc-1d2e1349ab91",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9fe6954d-5cbd-43f3-a6c3-e2af91c02bd1", "AQAAAAIAAYagAAAAEEiQngn6fUyIkKou516HAq9lIP24Ed+xG3fYcj7WwTP/bJdCsHrsFO731Lml2MU+lQ==", "30fb30d3-4393-4311-9047-12ba89eb2217" });

            migrationBuilder.CreateIndex(
                name: "IX_Students_SubscriptionId",
                table: "Students",
                column: "SubscriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Subscriptions_SubscriptionId",
                table: "Students",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "SubscriptionId");
        }
    }
}
