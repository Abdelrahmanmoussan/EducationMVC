using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityText.Migrations
{
    /// <inheritdoc />
    public partial class studentUser1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Attendances",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Attendances",
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
                values: new object[] { "bd01ba39-a78d-40cb-9c7d-1111093220b3", "AQAAAAIAAYagAAAAECUgX+F1StaBr+xMhgEKBNFhpx0ikMVx3xDRqV0yQ58ZtWEpY1LctQRCuefoWmcRtA==", "10ea867f-a1b3-45d6-a52b-21bd72070fda" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b4cd611-6c35-4c98-a0dc-1d2e1349ab91",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "519e99ee-27e5-4f68-bd49-0fbd091c1506", "AQAAAAIAAYagAAAAEF85q6WiprHpt9EVZWztiGe+4RBJJfddDIBi9VxIrk0Dirmg24tqSZUAe/ZmKVU/zQ==", "d54ddab5-fe55-4ce8-b38d-6e3761aaee56" });
        }
    }
}
