using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityText.Migrations
{
    /// <inheritdoc />
    public partial class updatesometable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_Attendances_AttendanceId",
                table: "Lectures");

            migrationBuilder.DropIndex(
                name: "IX_Lectures_AttendanceId",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "AttendanceId",
                table: "Lectures");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Subjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SubjectType",
                table: "Subjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LectureId",
                table: "Attendances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7aafd540-fdf8-482b-804d-780fb6726703",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6bffa4e1-2a2e-4337-bbb0-664bf6be5b02", "AQAAAAIAAYagAAAAEJqcCBeI+I7GFjf6CSw1jBqyVYhSgAT1Ch6stNst4GqTqDOE6NbrbB6ASdDWX+O1JA==", "6936b79c-25d0-419f-82cf-4a7be3f91793" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b4cd611-6c35-4c98-a0dc-1d2e1349ab91",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01210eb7-3a2f-444d-8570-84208fc81825", "AQAAAAIAAYagAAAAEOzP1ElxBc/Vy9sG0/ILMXZyTubGiKSh4iTQ0Jv7e3hiKGXuArDPtsrIdZSQ0eZ+Ow==", "8c5436b6-1707-4cb2-b61c-7ea98e9b6bf3" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "SubjectId",
                keyValue: 1,
                columns: new[] { "Description", "SubjectType" },
                values: new object[] { "مادة الرياضيات الأساسية", 0 });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "SubjectId",
                keyValue: 2,
                columns: new[] { "Description", "SubjectType" },
                values: new object[] { "مادة العلوم الأساسية", 0 });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "SubjectId",
                keyValue: 3,
                columns: new[] { "Description", "SubjectType" },
                values: new object[] { "مادة اللغة العربية الأساسية", 0 });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "SubjectId",
                keyValue: 4,
                columns: new[] { "Description", "SubjectType" },
                values: new object[] { "مادة اللغة الإنجليزية الأساسية", 1 });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "SubjectId",
                keyValue: 5,
                columns: new[] { "Description", "SubjectType" },
                values: new object[] { "مادة الدراسات الاجتماعية الأساسية", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_LectureId",
                table: "Attendances",
                column: "LectureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Lectures_LectureId",
                table: "Attendances",
                column: "LectureId",
                principalTable: "Lectures",
                principalColumn: "LectureId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Lectures_LectureId",
                table: "Attendances");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_LectureId",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "SubjectType",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "LectureId",
                table: "Attendances");

            migrationBuilder.AddColumn<int>(
                name: "AttendanceId",
                table: "Lectures",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_AttendanceId",
                table: "Lectures",
                column: "AttendanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_Attendances_AttendanceId",
                table: "Lectures",
                column: "AttendanceId",
                principalTable: "Attendances",
                principalColumn: "AttendanceId");
        }
    }
}
