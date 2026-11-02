using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class address : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Agencies",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Agencies",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Agencies",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Agencies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Agencies",
                keyColumn: "Id",
                keyValue: 1,
                column: "Address",
                value: "Strada Agricultorilor nr. 10");

            migrationBuilder.UpdateData(
                table: "Agencies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Address",
                value: "Strada Principală nr. 45");

            migrationBuilder.UpdateData(
                table: "Agencies",
                keyColumn: "Id",
                keyValue: 3,
                column: "Address",
                value: "Strada Morii nr. 22");

            migrationBuilder.UpdateData(
                table: "Agencies",
                keyColumn: "Id",
                keyValue: 13,
                column: "Address",
                value: "Str. Ecaterina Teodoroiu, nr. 38A");

            migrationBuilder.UpdateData(
                table: "Agencies",
                keyColumn: "Id",
                keyValue: 14,
                column: "Address",
                value: "str. Laterală, nr. 224");

            migrationBuilder.UpdateData(
                table: "Agencies",
                keyColumn: "Id",
                keyValue: 15,
                column: "Address",
                value: "str.Principală, nr. 82");

            migrationBuilder.UpdateData(
                table: "Agencies",
                keyColumn: "Id",
                keyValue: 16,
                column: "Address",
                value: "str. Cetății, nr. 40");

            migrationBuilder.UpdateData(
                table: "Agencies",
                keyColumn: "Id",
                keyValue: 17,
                column: "Address",
                value: "str. Muntişor, nr. 1");

            migrationBuilder.UpdateData(
                table: "Agencies",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Address", "Location", "Name" },
                values: new object[] { "str. Ştefan Ludwig Roth, nr. 565 A,", "Prejmer", "Centrul Local Prejmer" });

            migrationBuilder.UpdateData(
                table: "Agencies",
                keyColumn: "Id",
                keyValue: 19,
                column: "Address",
                value: "str.Republicii nr. 166");

            migrationBuilder.UpdateData(
                table: "Agencies",
                keyColumn: "Id",
                keyValue: 22,
                column: "Address",
                value: "str. Piața Unirii, nr. 20");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Agencies");

            migrationBuilder.UpdateData(
                table: "Agencies",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Location", "Name" },
                values: new object[] { "Predeal", "Centrul Local Predeal" });

            migrationBuilder.InsertData(
                table: "Agencies",
                columns: new[] { "Id", "County", "Location", "Name" },
                values: new object[,]
                {
                    { 20, "Brasov", "Zărnești", "Centrul Local Zărnești" },
                    { 21, "Brasov", "Victoria", "Centrul Local Victoria" },
                    { 23, "Brasov", "Săcele", "Centrul Local Săcele" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Phone", "Role" },
                values: new object[,]
                {
                    { 44, "silvia.radu@example.ro", "Silvia Radu", "d4f0bc5a29de06b510f9aa428f1eedba926012b591fef7a518e776a7c9bd1824", "0700000008", "Agent" },
                    { 45, "andrei.pavel@example.ro", "Andrei Pavel", "d4f0bc5a29de06b510f9aa428f1eedba926012b591fef7a518e776a7c9bd1824", "0700000009", "Agent" },
                    { 47, "radu.iliescu@example.ro", "Radu Iliescu", "d4f0bc5a29de06b510f9aa428f1eedba926012b591fef7a518e776a7c9bd1824", "0700000011", "Agent" }
                });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "AgencyId", "Email", "Name", "UserId" },
                values: new object[,]
                {
                    { 19, 20, "silvia.radu@example.ro", "Silvia Radu", 44 },
                    { 20, 21, "andrei.pavel@example.ro", "Andrei Pavel", 45 },
                    { 22, 23, "radu.iliescu@example.ro", "Radu Iliescu", 47 }
                });
        }
    }
}
