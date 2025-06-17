using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityText.Migrations
{
    /// <inheritdoc />
    public partial class CreateAtInClassGroupTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ClassGroups",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7aafd540-fdf8-482b-804d-780fb6726703",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e27cc26-4bae-44a1-b50f-c020f544e079", "AQAAAAIAAYagAAAAEABkhD0Z4kPTA/Hq/HFc1F9a4Td4w6/Bc3ZMtC3HOeWibxbBEkBTAmN7mPRDW+a3yw==", "42651356-2df0-456f-97ce-b5c580cf7d56" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b4cd611-6c35-4c98-a0dc-1d2e1349ab91",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0fe25f74-1195-4a59-8e3c-e9b8b9b3efb7", "AQAAAAIAAYagAAAAEGBZ+VNjzbSbSGqCuqQi6G6l8DvIlUnd/pmYvCwSdOwqkJAdq+ttNY9IL098Sqgb+Q==", "7388d429-c9dc-4d1a-b12f-a47b21e07f9b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ClassGroups");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7aafd540-fdf8-482b-804d-780fb6726703",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a730a521-830f-4dfc-ab2e-0aa0c5a30eaf", "AQAAAAIAAYagAAAAENQlR8kWqSki+Q83gePzl5AQFIbXjvvy8UhkviJfAeq3nqbOIDR4W6dSWDcfSKuCxA==", "5a920afb-7619-4158-ae1d-1d12709a170e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b4cd611-6c35-4c98-a0dc-1d2e1349ab91",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2678b20d-9d58-4ba7-8fb9-930e1e56bf81", "AQAAAAIAAYagAAAAECx8quQKfaUsNcqURg+/B4LICKaImcB1wR8jNOaQstAe0F98f6W83WBC+J7R2BAxRA==", "af169f48-4caf-4e41-9a7e-dc9a6360b231" });
        }
    }
}
