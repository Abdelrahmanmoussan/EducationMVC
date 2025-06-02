using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityText.Migrations
{
    /// <inheritdoc />
    public partial class lksjgsl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CGStatus",
                table: "ClassGroups",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7aafd540-fdf8-482b-804d-780fb6726703",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69b0376a-e724-410b-a481-3faabdbf8d3d", "AQAAAAIAAYagAAAAEEkJLlGDVUdMRbzstQDriS8tyclQJfievGQ1Jo9oh8H1XIrcNJcZVssHH8W363Obwg==", "69fe06db-065c-4b43-8518-00630438a780" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b4cd611-6c35-4c98-a0dc-1d2e1349ab91",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10263125-8feb-4d9e-9fd8-10c910b84b4f", "AQAAAAIAAYagAAAAEKNTSiV8/c8U5tRMIlw9gRX6HdE/ai/By1/HOehCmrvjjhSWhiu3ND0mXwiVntHRMA==", "d60f2af8-b8b2-4de1-8952-fb3f2d521337" });
        }
    }
}
