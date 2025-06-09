using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityText.Migrations
{
    /// <inheritdoc />
    public partial class changeNoteToRemark : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "Attendances",
                newName: "Remark");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7aafd540-fdf8-482b-804d-780fb6726703",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3ea6f030-9f69-4587-bb98-7c24b96bf5bd", "AQAAAAIAAYagAAAAEDa4rz6IE2eGGWBh4X1WqfLnEpzeAGCuHA2XkFSesIaRMOE/3QdqOuCkuYd4f2FvRg==", "f371f869-ae5e-4d45-b42e-6573aab97006" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b4cd611-6c35-4c98-a0dc-1d2e1349ab91",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "11bfb8c6-18ba-4562-99d9-18d15203541f", "AQAAAAIAAYagAAAAEHqhz+nWMXk6eRQ4Tg8wAsJVWMIyNIgnH4h5E7jy89r4chlCpwrDgN7caMSPftGedg==", "8fb1a7e2-b1d8-4e8c-a866-a19b0155d55b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Remark",
                table: "Attendances",
                newName: "Notes");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7aafd540-fdf8-482b-804d-780fb6726703",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc8ba03f-6f27-43ae-983a-e3ab4cb400f6", "AQAAAAIAAYagAAAAEK8VQiEOwzAg305HOsvYSYI/uX+kF2x+BnCphzmbrPhQb1zS8zTOTSKR+D6BUEUv8w==", "de442f31-fad4-40ba-82da-1884bbaa786d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b4cd611-6c35-4c98-a0dc-1d2e1349ab91",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0198a91a-b5b3-45cf-9d22-3b8ef7e38861", "AQAAAAIAAYagAAAAEM+sluB29rFBV15TKcFtGMlfSoCH3LvKuwD1RBTgCMuJewqoCVXJPKZ+BSAJVGAsUA==", "fb1cbdb4-604f-4e52-ac3a-b44a498d91e2" });
        }
    }
}
