using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityText.Migrations
{
    /// <inheritdoc />
    public partial class studentUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_ApplicationUserId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ApplicationUserId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Students");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Students",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AcademicYears",
                keyColumn: "AcademicYearId",
                keyValue: 1,
                column: "Name",
                value: "الصف  الاول الاعدادي ");

            migrationBuilder.UpdateData(
                table: "AcademicYears",
                keyColumn: "AcademicYearId",
                keyValue: 2,
                column: "Name",
                value: "الصف  الثانى الاعدادي");

            migrationBuilder.UpdateData(
                table: "AcademicYears",
                keyColumn: "AcademicYearId",
                keyValue: 3,
                column: "Name",
                value: "الصف  الثالث الاعدادي");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7aafd540-fdf8-482b-804d-780fb6726703",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd01ba39-a78d-40cb-9c7d-1111093220b3", "AQAAAAIAAYagAAAAECUgX+F1StaBr+xMhgEKBNFhpx0ikMVx3xDRqV0yQ58ZtWEpY1LctQRCuefoWmcRtA==", "10ea867f-a1b3-45d6-a52b-21bd72070fda" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b4cd611-6c35-4c98-a0dc-1d2e1349ab91",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "519e99ee-27e5-4f68-bd49-0fbd091c1506", "AQAAAAIAAYagAAAAEF85q6WiprHpt9EVZWztiGe+4RBJJfddDIBi9VxIrk0Dirmg24tqSZUAe/ZmKVU/zQ==", "d54ddab5-fe55-4ce8-b38d-6e3761aaee56" });

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_UserId",
                table: "Students",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_UserId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_UserId",
                table: "Students");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Students",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AcademicYears",
                keyColumn: "AcademicYearId",
                keyValue: 1,
                column: "Name",
                value: "one");

            migrationBuilder.UpdateData(
                table: "AcademicYears",
                keyColumn: "AcademicYearId",
                keyValue: 2,
                column: "Name",
                value: "two");

            migrationBuilder.UpdateData(
                table: "AcademicYears",
                keyColumn: "AcademicYearId",
                keyValue: 3,
                column: "Name",
                value: "three");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7aafd540-fdf8-482b-804d-780fb6726703",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca8ab646-b2ac-4bbe-83e9-9bf4dc6b6f0f", "AQAAAAIAAYagAAAAEF1P/gJQhOYB5VQB80vSIvVnMyP8YQ65EBLwjrM3QsxkHo1agTqPuTpxsQww8KG6cQ==", "3b8459b4-a248-4ee0-9c4e-6980173d8a98" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b4cd611-6c35-4c98-a0dc-1d2e1349ab91",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c02f6cde-a5db-47f4-9889-a154984c2785", "AQAAAAIAAYagAAAAEEASGBLqdRnTag83gPHed618jHkbZbXe8ygDDcmpHF7jNQ5jc40kjCZ8xOHW856ZQg==", "99cb9949-9601-4e4b-b74e-d44eb7f171c1" });

            migrationBuilder.CreateIndex(
                name: "IX_Students_ApplicationUserId",
                table: "Students",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_ApplicationUserId",
                table: "Students",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
