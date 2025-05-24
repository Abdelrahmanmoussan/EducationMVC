using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityText.Migrations
{
    /// <inheritdoc />
    public partial class updateOrderItemModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "OrderItems");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7aafd540-fdf8-482b-804d-780fb6726703",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01ab85b5-d05d-4727-b737-ff78bd284372", "AQAAAAIAAYagAAAAEAKSbtNYq2NaVtI34WyLTW4xmKqzzWRm8/j4Q+TxQw6qy43gaQqF5nok5WjuSHhzmQ==", "46ef2715-3227-4608-96c8-022031d8b476" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b4cd611-6c35-4c98-a0dc-1d2e1349ab91",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a0c51a0-284e-4b77-a0ca-8dcbdf1db970", "AQAAAAIAAYagAAAAELH0cRSsOyjGbuoVJt9Uw7zLXdxaMd6hp55aUCanwgC05wZI1+dUrnOF1ZHwlR4GVg==", "a1e80074-9911-4ef7-9eec-c4e9c71e5df3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "OrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7aafd540-fdf8-482b-804d-780fb6726703",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2686ac76-2b35-477e-8470-4bf30cd92f31", "AQAAAAIAAYagAAAAEG9VnedMKEEQ5LunBf34QsJ9YSBobTRojTNKJGEErdShK7D0kyP5yOd23XpfSyIHKw==", "3732c270-c130-4ae8-9ed2-0fb837741e3e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b4cd611-6c35-4c98-a0dc-1d2e1349ab91",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a227665a-06d9-4b3b-84ff-8b99f1d5789d", "AQAAAAIAAYagAAAAEDny48EO8ONL9w93OGGDoMTJJviflp6qlAhzY+ybR9fCU2AsSmIVwYQwphJ7ImQOfw==", "075c5f70-056d-45e9-bb61-56d8c95c473d" });
        }
    }
}
