using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityText.Migrations
{
    /// <inheritdoc />
    public partial class addData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7aafd540-fdf8-482b-804d-780fb6726703",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "94d9439c-3d46-4d68-b48c-538f9b2e4e8c", "AQAAAAIAAYagAAAAEMh8TKly8x08Vrimm2vKwDENXU8/X44/TcB3LktnqjxxjmyowWETXYXxwAwS6zdu2w==", "5f6f4f95-d908-4c1e-a543-eb00df544d87" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b4cd611-6c35-4c98-a0dc-1d2e1349ab91",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d2f80657-babe-4460-80ce-81b59378beda", "AQAAAAIAAYagAAAAELktJHjH6rnNN0c85I+IAcYvM/IdETCKMBsx1xzZHILr2tamh4CMbgCPVYSD44KuRQ==", "867bc1e8-3f1b-4bf3-b2a7-1f4613352bb7" });
        }
    }
}
