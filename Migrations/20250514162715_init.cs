using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityText.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7aafd540-fdf8-482b-804d-780fb6726703",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc5a0cd1-0a81-4225-9916-4f43c8593801", "AQAAAAIAAYagAAAAEDK64tpazhTk9CosZftYhRYMkD4u3AYvU5gmA4kSBPsTLjNPK1i0g70oA9NIeMUxKg==", "948a5c17-c6d4-41b2-82e9-2b6021e65a2f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b4cd611-6c35-4c98-a0dc-1d2e1349ab91",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2bc09674-5ff7-4214-9fb3-c0d96391f0e1", "AQAAAAIAAYagAAAAECxbHDQz+9jOfcb9byFijorCwf9ob73pedIV4S2+oOXctWV2TjEFVRqcJSp1Em+pyQ==", "bdeb089e-0a49-4fb7-bdc5-5e5501ba1363" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7aafd540-fdf8-482b-804d-780fb6726703",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "df7856a2-e168-4d5b-aa8e-bba106ca1ade", "AQAAAAIAAYagAAAAEDstiwxt0/ZVBrvp6m4JVr1Ul65nLui4i/IFrXefUHqzp1+MKR2j2SeC8tTd0LPaTw==", "417dda73-a6fe-47d9-bbbb-16b46887b302" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b4cd611-6c35-4c98-a0dc-1d2e1349ab91",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "576b8d72-4852-4b49-9743-d71c83ffd7e0", "AQAAAAIAAYagAAAAEF+6jEjek8+AwvW0UQHzVCo1X3rXzwUNHGeQ/Hb7S+iBVCEMRgFvBRT15Y4cuvjxUg==", "07dfd264-45d8-45e1-acfe-800bb237401c" });
        }
    }
}
