using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityText.Migrations
{
    /// <inheritdoc />
    public partial class CreateAtInPrivateLessonTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PrivateLessons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7aafd540-fdf8-482b-804d-780fb6726703",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f3e0e0f-c465-4b1d-a9e5-98729f0b8ebc", "AQAAAAIAAYagAAAAEEEKB1wK5CFLLHZHoiVcnAe2Ja+J4BGrPLvtJJTKK/WopfalnpZ4EqLPnGjTMD4spw==", "1d43bbf0-5b46-46f1-8158-9a5ef00264b5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b4cd611-6c35-4c98-a0dc-1d2e1349ab91",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b0cafb94-13da-40cd-b097-7a6232074e53", "AQAAAAIAAYagAAAAED5rmarPH+AGBfORxq4Jy2vk3CL6EfXQXmpx0AoN8dkj/hTGfr1AnjIjHOBvelkwtw==", "eeb56b05-fae0-4827-b196-0314920586eb" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PrivateLessons");

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
    }
}
