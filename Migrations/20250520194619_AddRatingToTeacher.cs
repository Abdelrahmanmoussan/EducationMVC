using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityText.Migrations
{
    /// <inheritdoc />
    public partial class AddRatingToTeacher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Rating",
                table: "Teachers",
                type: "decimal(2,1)",
                nullable: false,
                defaultValue: 0m);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Teachers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7aafd540-fdf8-482b-804d-780fb6726703",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1dc26d36-4c41-488f-85e4-0fbcf566331a", "AQAAAAIAAYagAAAAENz7awUUc0hNHMZTT0pVHjCDsoJ5KlpW7Bzs08c7Ppwmg4e+avRO4wQpS9omSji1+w==", "d8c1c358-b570-48b0-8eb1-c3851f81852c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b4cd611-6c35-4c98-a0dc-1d2e1349ab91",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55d979b5-7a4c-490b-9189-3ee534528fa0", "AQAAAAIAAYagAAAAEHtEJJfs5Ma+DocKH5AK3iKa6ieBbZt20oc51QLlliR4NfhBO+8YwAvoSJow3ZN2GA==", "3b9ee717-41be-4db5-9b53-0e7144d62f78" });
        }
    }
}
