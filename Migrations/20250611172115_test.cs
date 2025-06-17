using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityText.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7aafd540-fdf8-482b-804d-780fb6726703",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ca9f79c-d341-41c2-b9ea-e248e8fbb926", "AQAAAAIAAYagAAAAEMwFoC04KcMvg2UyfHN9mkGidp+VzoGfs1nV24xWSS5rXT9niW1kni7sy0XsPajcMw==", "ce9c147d-6110-4e9f-9156-6e370905398e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b4cd611-6c35-4c98-a0dc-1d2e1349ab91",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca01b68e-e500-434e-ace5-521ec18d6c0a", "AQAAAAIAAYagAAAAEF1ywsLWzQsLpTuJbprTjQYoAJBA+c/9vqnPUBpaSC4s3T/nPxqmYV0883rW3aEzAA==", "633fd7bf-31d7-4c69-b16a-c4b0ac0b9257" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7aafd540-fdf8-482b-804d-780fb6726703",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9b030195-6599-44cc-8638-a06251d3b5c1", "AQAAAAIAAYagAAAAEKrtoYqEBJH+5S9mG0Lxa3e49yotYhZE9uhsy31H8GMgRt4Ix1Be19ngST6py/zdEw==", "5b3eee54-31fa-4fb0-a01c-24ff584056ce" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b4cd611-6c35-4c98-a0dc-1d2e1349ab91",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd8ba5e5-3575-4f28-9599-5d22ecb77988", "AQAAAAIAAYagAAAAEAopRSFtYW5sen4tJdCSfuqXwp01onTTW9qk4SCd1ubfkidS7L+4d4zuwU1BegYB1g==", "809aec49-0b7e-4a59-962e-acbe89f21e40" });
        }
    }
}
