using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class dorin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Agencies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "County", "Location" },
                values: new object[] { "Brasov", "Brasov" });

            migrationBuilder.UpdateData(
                table: "Agencies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "County", "Location" },
                values: new object[] { "Brasov", "Poiana Marului" });

            migrationBuilder.UpdateData(
                table: "Agencies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "County", "Location" },
                values: new object[] { "Brasov", "Sercaia" });

            migrationBuilder.InsertData(
                table: "Agencies",
                columns: new[] { "Id", "County", "Location", "Name" },
                values: new object[,]
                {
                    { 6, "Brasov", "Fagaras", "Centrul Local Fagaras" },
                    { 7, "Brasov", "Codlea", "Centrul Local Codlea" }
                });

            migrationBuilder.UpdateData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Location",
                value: "Sinca Noua");

            migrationBuilder.UpdateData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Location",
                value: "Poiana Marului");

            migrationBuilder.UpdateData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Location",
                value: "Sinca Veche");

            migrationBuilder.UpdateData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: 4,
                column: "Location",
                value: "Sinca Noua");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agencies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Agencies",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "Agencies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "County", "Location" },
                values: new object[] { "Cluj", "Cluj-Napoca" });

            migrationBuilder.UpdateData(
                table: "Agencies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "County", "Location" },
                values: new object[] { "Timiș", "Timișoara" });

            migrationBuilder.UpdateData(
                table: "Agencies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "County", "Location" },
                values: new object[] { "Iași", "Brasov" });

            migrationBuilder.UpdateData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Location",
                value: "Village A");

            migrationBuilder.UpdateData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Location",
                value: "Village B");

            migrationBuilder.UpdateData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Location",
                value: "Village C");

            migrationBuilder.UpdateData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: 4,
                column: "Location",
                value: "Village D");
        }
    }
}
