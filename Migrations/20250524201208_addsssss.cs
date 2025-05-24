using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityText.Migrations
{
    /// <inheritdoc />
    public partial class addsssss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7aafd540-fdf8-482b-804d-780fb6726703",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8088e531-3ab8-406a-83c3-36c8ba51166b", "AQAAAAIAAYagAAAAEGzWUzhx0gxWNR03Mso+SKOTolF6s1qjrXdmlJ/tN5SN23UQDoqngPYHhHtw6/pHlw==", "1d61cec0-9e82-487e-b029-42f79b6d5d5a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b4cd611-6c35-4c98-a0dc-1d2e1349ab91",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f9308ced-65aa-4b8e-a97b-b6e0686896ac", "AQAAAAIAAYagAAAAEP8089Li0uwRaqCOTrbaH6eg0ig9uf+p/t2ZVKv2nyHGxtoC4B++B2hx6J2IGJoCUQ==", "1c3e6e94-a969-4a0e-a121-38303ea4a428" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7aafd540-fdf8-482b-804d-780fb6726703",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4efb0f61-0fec-4aa8-8397-45943da65cfc", "AQAAAAIAAYagAAAAEE9BExSlmNyETbVXV+hmInL8XCprb/nfdoJLD+p02uHEwVevEgy6lOJEMFEt5T8ifA==", "dcb1d907-2082-4f04-92a8-9934460a8a87" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b4cd611-6c35-4c98-a0dc-1d2e1349ab91",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b7f1b0d8-28c0-43da-999f-78e4eb112178", "AQAAAAIAAYagAAAAECfcpG5bXymnRcn6nX7CIRSXDRgnQKs8kNJuWaiq+lqRPpBthvndHP3dHitUPv7Vrw==", "a1ff9461-90e3-4b4c-9fbf-44197c7d6083" });
        }
    }
}
