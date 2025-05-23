using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityText.Migrations
{
    /// <inheritdoc />
    public partial class ratingteacher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7aafd540-fdf8-482b-804d-780fb6726703",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e04db1b0-d0c1-47b9-b8d7-6cad68454691", "AQAAAAIAAYagAAAAEGzQilXtIjMqqfH9eDJsCawV231JawDLqsHPDShuT7Hi2ffrJagUubTVcu9Y5AgTbQ==", "f6e97853-5793-4ec1-a73d-4f860ce08221" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b4cd611-6c35-4c98-a0dc-1d2e1349ab91",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e456db0c-291c-45dd-9fe1-3d34977bc0fd", "AQAAAAIAAYagAAAAEB+dT/sqLZ4145dk3tLW9wACSXBEO/1vrMIBEr0z+RlXgTDpls0lCXGEIMrXxDxPLg==", "8d27a81d-eb25-495b-ac64-1053090d882b" });
        }
    }
}
