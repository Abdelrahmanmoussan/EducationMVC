using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityText.Migrations
{
    /// <inheritdoc />
    public partial class lksjgsl11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CGStatus",
                table: "ClassGroups",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CGStatus",
                table: "ClassGroups");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7aafd540-fdf8-482b-804d-780fb6726703",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68a2d0c0-989e-4513-8659-98db2fac7eff", "AQAAAAIAAYagAAAAEAJnJ13HhMhIzuCx8rAuwWsmTkY0zVhnBmIX5vwMa3Q1ZwVTqmx3Hye7VdzgQagJAQ==", "5e60f5c3-c99f-455a-a451-5271ffc52661" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b4cd611-6c35-4c98-a0dc-1d2e1349ab91",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "325f2e23-9ca6-4431-ba19-e69f73cf2845", "AQAAAAIAAYagAAAAECnf4+Cqwcav57lO7JixniVFVmDjRFWRXWeidanNDuOhfy0qF0tyzZDc/a/1ChSYSg==", "adac952c-dbae-4b18-95e7-7a3a5c4d70fa" });
        }
    }
}
