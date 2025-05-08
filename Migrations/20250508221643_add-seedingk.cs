using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IdentityText.Migrations
{
    /// <inheritdoc />
    public partial class addseedingk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Subscriptions_SubscriptionId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "SubscriptionId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7aafd540-fdf8-482b-804d-780fb6726703",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f705834-5eca-4b84-9725-562c741cd0b1", "AQAAAAIAAYagAAAAEEVeBnGz1MS4tGRGbkzD4WTKTw8t3v0q82rppZy657kab67HQyrlZcW8utMGy+RoPw==", "028c0734-e486-446a-b03a-151df76cd5ef" });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "SubscriptionId", "Code", "EndDate", "StartDate", "SubscriptionStatus" },
                values: new object[,]
                {
                    { 1, "SUBS2024A", new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 2, "SUBS2023B", new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Subscriptions_SubscriptionId",
                table: "Students",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "SubscriptionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Subscriptions_SubscriptionId",
                table: "Students");

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "SubscriptionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "SubscriptionId",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "SubscriptionId",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7aafd540-fdf8-482b-804d-780fb6726703",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f2986c48-38a6-472a-8459-f19981eb3675", "AQAAAAIAAYagAAAAEBQ0FWzRU2dhRE5/gl1IC87poCPrjXuIV/cRprqSIsj7Em9UuKKKbQ0+S5BjsQJ3pQ==", "932a8cb1-a82f-41a2-aca5-0daf9c5fceaa" });

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Subscriptions_SubscriptionId",
                table: "Students",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "SubscriptionId");
        }
    }
}
