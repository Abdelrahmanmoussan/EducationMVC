using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IdentityText.Migrations
{
    /// <inheritdoc />
    public partial class addseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Subscriptions_SubscriptionId",
                table: "Students");

            migrationBuilder.AlterColumn<bool>(
                name: "TeacherIsActive",
                table: "Teachers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SubscriptionId",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AcademicYears",
                columns: new[] { "AcademicYearId", "Name" },
                values: new object[,]
                {
                    { 1, "one" },
                    { 2, "two" },
                    { 3, "three" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7aafd540-fdf8-482b-804d-780fb6726703",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f2986c48-38a6-472a-8459-f19981eb3675", "AQAAAAIAAYagAAAAEBQ0FWzRU2dhRE5/gl1IC87poCPrjXuIV/cRprqSIsj7Em9UuKKKbQ0+S5BjsQJ3pQ==", "932a8cb1-a82f-41a2-aca5-0daf9c5fceaa" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "SubjectId", "Title" },
                values: new object[,]
                {
                    { 1, "الرياضيات" },
                    { 2, "العلوم" },
                    { 3, "اللغة العربية" },
                    { 4, "اللغة الإنجليزية" },
                    { 5, "الدراسات الاجتماعية" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Subscriptions_SubscriptionId",
                table: "Students",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "SubscriptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Subscriptions_SubscriptionId",
                table: "Students");

            migrationBuilder.DeleteData(
                table: "AcademicYears",
                keyColumn: "AcademicYearId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AcademicYears",
                keyColumn: "AcademicYearId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AcademicYears",
                keyColumn: "AcademicYearId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubjectId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubjectId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubjectId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubjectId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubjectId",
                keyValue: 5);

            migrationBuilder.AlterColumn<bool>(
                name: "TeacherIsActive",
                table: "Teachers",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

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
                values: new object[] { "77b98271-8239-4bec-b549-2b28f45549c8", "AQAAAAIAAYagAAAAEDHHmkRAuQifPPVB0c3Cf7DNkHok54hUtEq7yMatNaZwAm5Zt49AzOeYO6ktAEPZnQ==", "db95b525-04dd-48b6-9c5a-44b786a6bab9" });

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Subscriptions_SubscriptionId",
                table: "Students",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "SubscriptionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
