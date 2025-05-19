using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityText.Migrations
{
    /// <inheritdoc />
    public partial class removetablesubacayear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubjectAcademicYears");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Subjects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Subjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "SubjectAcademicYears",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    AcademicYearId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectAcademicYears", x => new { x.SubjectId, x.AcademicYearId });
                    table.ForeignKey(
                        name: "FK_SubjectAcademicYears_AcademicYears_AcademicYearId",
                        column: x => x.AcademicYearId,
                        principalTable: "AcademicYears",
                        principalColumn: "AcademicYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectAcademicYears_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7aafd540-fdf8-482b-804d-780fb6726703",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4edd07e0-f782-4ec3-b1c2-0ded7db31a7b", "AQAAAAIAAYagAAAAEH7oKojAPNbGjhgKrBTplQcjpOOUM0/loBEB0QAjUOFcKb1+NED+goCHL2GScKy0cg==", "9e2f6018-3a73-4f00-83ae-abd6f6788b21" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b4cd611-6c35-4c98-a0dc-1d2e1349ab91",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d49a563d-134b-4379-ab11-5f4757ab4a28", "AQAAAAIAAYagAAAAEJhXd2Wi2vPtMNImUCyFvbrthTd/yr8ZrkLigDyfGk78K87lpIJ9pRrK7DlbllsImQ==", "3ab11783-6f7c-4688-a0c1-14fb4e0b10d3" });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectAcademicYears_AcademicYearId",
                table: "SubjectAcademicYears",
                column: "AcademicYearId");
        }
    }
}
