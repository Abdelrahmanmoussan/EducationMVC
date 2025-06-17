using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityText.Migrations
{
    /// <inheritdoc />
    public partial class addDeleteCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7aafd540-fdf8-482b-804d-780fb6726703",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a730a521-830f-4dfc-ab2e-0aa0c5a30eaf", "AQAAAAIAAYagAAAAENQlR8kWqSki+Q83gePzl5AQFIbXjvvy8UhkviJfAeq3nqbOIDR4W6dSWDcfSKuCxA==", "5a920afb-7619-4158-ae1d-1d12709a170e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b4cd611-6c35-4c98-a0dc-1d2e1349ab91",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2678b20d-9d58-4ba7-8fb9-930e1e56bf81", "AQAAAAIAAYagAAAAECx8quQKfaUsNcqURg+/B4LICKaImcB1wR8jNOaQstAe0F98f6W83WBC+J7R2BAxRA==", "af169f48-4caf-4e41-9a7e-dc9a6360b231" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7aafd540-fdf8-482b-804d-780fb6726703",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ca9f79c-d341-41c2-b9ea-e248e8fbb926", "AQAAAAIAAYagAAAAEMwFoC04KcMvg2UyfHN9mkGidp+VzoGfs1nV24xWSS5rXT9niW1kni7sy0XsPajcMw==", "ce9c147d-6110-4e9f-9156-6e370905398e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b4cd611-6c35-4c98-a0dc-1d2e1349ab91",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca01b68e-e500-434e-ace5-521ec18d6c0a", "AQAAAAIAAYagAAAAEF1ywsLWzQsLpTuJbprTjQYoAJBA+c/9vqnPUBpaSC4s3T/nPxqmYV0883rW3aEzAA==", "633fd7bf-31d7-4c69-b16a-c4b0ac0b9257" });
        }
    }
}
