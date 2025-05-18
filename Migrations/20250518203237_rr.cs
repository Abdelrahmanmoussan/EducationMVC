using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityText.Migrations
{
    /// <inheritdoc />
    public partial class rr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_ClassGroups_ClassGroupId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_Assessments_AssessmentId",
                table: "Lectures");

            migrationBuilder.DropIndex(
                name: "IX_Lectures_AssessmentId",
                table: "Lectures");

            migrationBuilder.AlterColumn<string>(
                name: "VideoURL",
                table: "Lectures",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Lectures",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ClassGroupId",
                table: "Assessments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "AssessmentLink",
                table: "Assessments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "LectureId",
                table: "Assessments",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_LectureId",
                table: "Assessments",
                column: "LectureId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_ClassGroups_ClassGroupId",
                table: "Assessments",
                column: "ClassGroupId",
                principalTable: "ClassGroups",
                principalColumn: "ClassGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_Lectures_LectureId",
                table: "Assessments",
                column: "LectureId",
                principalTable: "Lectures",
                principalColumn: "LectureId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_ClassGroups_ClassGroupId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_Lectures_LectureId",
                table: "Assessments");

            migrationBuilder.DropIndex(
                name: "IX_Assessments_LectureId",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "LectureId",
                table: "Assessments");

            migrationBuilder.AlterColumn<string>(
                name: "VideoURL",
                table: "Lectures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Lectures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClassGroupId",
                table: "Assessments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AssessmentLink",
                table: "Assessments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7aafd540-fdf8-482b-804d-780fb6726703",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "06fd97ff-a069-456a-a27c-1766861456b8", "AQAAAAIAAYagAAAAELHO9RcX8MhmHFpQKHbxNdHIFVuha2rRntppUVSBippLUu0Clg5LFfJbJR2vF2Fgjw==", "57c147bc-308f-403e-81dc-a340199a745f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b4cd611-6c35-4c98-a0dc-1d2e1349ab91",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0fe16132-4c9d-46fa-8c40-901b54ad3522", "AQAAAAIAAYagAAAAELBVX3b2p4iQenrO+Oq9AFB04C9Vl+occtZHNaNWfUsJbpnsFfdl6WhhWJ6zLEEqXw==", "f5442fd3-5cc3-40ec-b688-3b3fac4e3d5a" });

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_AssessmentId",
                table: "Lectures",
                column: "AssessmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_ClassGroups_ClassGroupId",
                table: "Assessments",
                column: "ClassGroupId",
                principalTable: "ClassGroups",
                principalColumn: "ClassGroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_Assessments_AssessmentId",
                table: "Lectures",
                column: "AssessmentId",
                principalTable: "Assessments",
                principalColumn: "AssessmentId");
        }
    }
}
