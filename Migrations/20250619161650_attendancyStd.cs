using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityText.Migrations
{
    /// <inheritdoc />
    public partial class attendancyStd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttendancePercent",
                table: "Students");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7aafd540-fdf8-482b-804d-780fb6726703",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e6dd3d99-04d0-4509-9a01-2e14725a9429", "AQAAAAIAAYagAAAAEAdq2mGpXFSSgjSWXvF5wz7yQGM+ANux1wJPh7dpU9VDKAtCMpTLf7dX1urgqOHNEA==", "b67ec00f-36d5-4602-a0fe-06dc3ed54e2b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7nnfd540-fdf8-482b-804d-780fb6726703",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e439c6f9-cd7d-4869-ae09-78cfa52e64e3", "AQAAAAIAAYagAAAAEHqQ4pDQ62uNAgnko79rvUfnCgu6NdDzRqv8yUb8id83E3MhMjFRGug32OffV4MTLg==", "b22cb1c5-718a-45c9-9a34-81f3be2a7765" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7zzfd540-fdf8-482b-804d-780fb6726703",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "721df772-db70-4db4-a136-2fffb7ea3304", "AQAAAAIAAYagAAAAEEnl5LvoGuRuA1MUj29seyqTFTIbVPji2SN9rFf+89KRW4l1wKNt0Bmersmjzldsag==", "e23468f8-e958-467d-b734-3c0cff98005c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b4cd611-6c35-4c98-a0dc-1d2e1349ab91",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4204a4c2-e6c6-4d83-8fbf-1549512cfe2a", "AQAAAAIAAYagAAAAEIwYvYx1QxgjUFRbZCf/4n15q5jBy6CcibKVKtaFfZB02EWsh6hy/eBAhU3F8TsSuQ==", "26adfe3c-52b0-44d5-9ef7-75f126075ce1" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "EnrollmentDate",
                value: new DateTime(2025, 6, 19, 19, 16, 37, 437, DateTimeKind.Local).AddTicks(1987));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AttendancePercent",
                table: "Students",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7aafd540-fdf8-482b-804d-780fb6726703",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9972db73-79a5-44fd-83ea-abc55743315e", "AQAAAAIAAYagAAAAEASZmmVpzsm6kV6Lacj5Y/c4amQkSNdNhGS8Ghj8NJE65YaMBR4RS5BXPp+6nySTBw==", "0c322de8-a9ba-48c8-8aa5-747da0dd5030" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7nnfd540-fdf8-482b-804d-780fb6726703",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "24ae7629-e45d-4402-8520-e92f87bf0993", "AQAAAAIAAYagAAAAEGGUUBukbj8ue8yB3EUiYw+Jh3iU7ozy5vAZA3rHMrb2vwD2F1+nKMjwYJFJdgAFQQ==", "b7bc1e69-eec9-496b-8ae9-7e8e2795a76d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7zzfd540-fdf8-482b-804d-780fb6726703",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d6a2079-5524-4023-bee8-ef2acf2c33d4", "AQAAAAIAAYagAAAAEH5PE0ymU6JhkMJqcJfITMBL1WJTS9kPbU6vq5b9a+vakYN7EtZa8gAjRmjOb0uI4g==", "12b5d5e2-c949-4b6a-9005-6bd7b9ed818e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b4cd611-6c35-4c98-a0dc-1d2e1349ab91",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2aa86871-c5f3-43ca-9ef7-cf68daff3afa", "AQAAAAIAAYagAAAAEMPFGse4KolttLYFRXgjpdIvOa1/esb3BAVV/0O5ejMDvJR6cFiLB5+XM+LkRewDHA==", "3bd5ddd5-da4c-44fb-a5c6-e658ae07fcf7" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                columns: new[] { "AttendancePercent", "EnrollmentDate" },
                values: new object[] { 100m, new DateTime(2025, 6, 18, 18, 55, 46, 633, DateTimeKind.Local).AddTicks(634) });
        }
    }
}
