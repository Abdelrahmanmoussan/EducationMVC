using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityText.Migrations
{
    /// <inheritdoc />
    public partial class addcgstatus1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "ClassGroups",
                newName: "CGStatus");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7aafd540-fdf8-482b-804d-780fb6726703",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69b0376a-e724-410b-a481-3faabdbf8d3d", "AQAAAAIAAYagAAAAEEkJLlGDVUdMRbzstQDriS8tyclQJfievGQ1Jo9oh8H1XIrcNJcZVssHH8W363Obwg==", "69fe06db-065c-4b43-8518-00630438a780" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b4cd611-6c35-4c98-a0dc-1d2e1349ab91",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10263125-8feb-4d9e-9fd8-10c910b84b4f", "AQAAAAIAAYagAAAAEKNTSiV8/c8U5tRMIlw9gRX6HdE/ai/By1/HOehCmrvjjhSWhiu3ND0mXwiVntHRMA==", "d60f2af8-b8b2-4de1-8952-fb3f2d521337" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CGStatus",
                table: "ClassGroups",
                newName: "Status");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7aafd540-fdf8-482b-804d-780fb6726703",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eacd1383-1f4f-4716-87c4-690aaab66358", "AQAAAAIAAYagAAAAEEgJhfQh77yeznUVyq5Dh2SSf6ZndE/Sk5YYoan1KMgUOmbbiOkFg6iCjioZv3587g==", "ce03cbbb-a47a-45f4-8d3c-8552aa6e2c8d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b4cd611-6c35-4c98-a0dc-1d2e1349ab91",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54ea77fe-6c39-4e78-9cce-7e4e9b9527f9", "AQAAAAIAAYagAAAAEGrCRFcUC3088mPWfBQghBW2PaRmvtUZYO6QtAZabMJg84W4WIORehQ3gQqClbVBWQ==", "0b01061b-881a-46e3-a71b-4d6ae46a1dc7" });
        }
    }
}
