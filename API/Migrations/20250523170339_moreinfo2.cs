using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class moreinfo2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Phone", "Role" },
                values: new object[,]
                {
                    { 37, "ion.popescu@apia.ro", "Ion Popescu", "d4f0bc5a29de06b510f9aa428f1eedba926012b591fef7a518e776a7c9bd1824", "0700000001", "Agent" },
                    { 38, "maria.ionescu@apia.ro", "Maria Ionescu", "d4f0bc5a29de06b510f9aa428f1eedba926012b591fef7a518e776a7c9bd1824", "0700000002", "Agent" },
                    { 39, "vasile.georgescu@apia.ro", "Vasile Georgescu", "d4f0bc5a29de06b510f9aa428f1eedba926012b591fef7a518e776a7c9bd1824", "0700000003", "Agent" },
                    { 40, "elena.dumitrescu@apia.ro", "Elena Dumitrescu", "d4f0bc5a29de06b510f9aa428f1eedba926012b591fef7a518e776a7c9bd1824", "0700000004", "Agent" },
                    { 41, "mihai.marin@apia.ro", "Mihai Marin", "d4f0bc5a29de06b510f9aa428f1eedba926012b591fef7a518e776a7c9bd1824", "0700000005", "Agent" },
                    { 42, "ana.vasilescu@apia.ro", "Ana Vasilescu", "d4f0bc5a29de06b510f9aa428f1eedba926012b591fef7a518e776a7c9bd1824", "0700000006", "Agent" },
                    { 43, "cristian.ene@apia.ro", "Cristian Ene", "d4f0bc5a29de06b510f9aa428f1eedba926012b591fef7a518e776a7c9bd1824", "0700000007", "Agent" },
                    { 44, "silvia.radu@apia.ro", "Silvia Radu", "d4f0bc5a29de06b510f9aa428f1eedba926012b591fef7a518e776a7c9bd1824", "0700000008", "Agent" },
                    { 45, "andrei.pavel@apia.ro", "Andrei Pavel", "d4f0bc5a29de06b510f9aa428f1eedba926012b591fef7a518e776a7c9bd1824", "0700000009", "Agent" },
                    { 46, "ioana.neagu@apia.ro", "Ioana Neagu", "d4f0bc5a29de06b510f9aa428f1eedba926012b591fef7a518e776a7c9bd1824", "0700000010", "Agent" },
                    { 47, "radu.iliescu@apia.ro", "Radu Iliescu", "d4f0bc5a29de06b510f9aa428f1eedba926012b591fef7a518e776a7c9bd1824", "0700000011", "Agent" },
                    { 48, "monica.florescu@apia.ro", "Monica Florescu", "d4f0bc5a29de06b510f9aa428f1eedba926012b591fef7a518e776a7c9bd1824", "0700000012", "Agent" },
                    { 49, "george.petrescu@apia.ro", "George Petrescu", "d4f0bc5a29de06b510f9aa428f1eedba926012b591fef7a518e776a7c9bd1824", "0700000013", "Agent" },
                    { 50, "daniela.voicu@apia.ro", "Daniela Voicu", "d4f0bc5a29de06b510f9aa428f1eedba926012b591fef7a518e776a7c9bd1824", "0700000014", "Agent" }
                });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "AgencyId", "Email", "Name", "UserId" },
                values: new object[,]
                {
                    { 12, 13, "ion.popescu@apia.ro", "Ion Popescu", 37 },
                    { 13, 14, "maria.ionescu@apia.ro", "Maria Ionescu", 38 },
                    { 14, 15, "vasile.georgescu@apia.ro", "Vasile Georgescu", 39 },
                    { 15, 16, "elena.dumitrescu@apia.ro", "Elena Dumitrescu", 40 },
                    { 16, 17, "mihai.marin@apia.ro", "Mihai Marin", 41 },
                    { 17, 18, "ana.vasilescu@apia.ro", "Ana Vasilescu", 42 },
                    { 18, 19, "cristian.ene@apia.ro", "Cristian Ene", 43 },
                    { 19, 20, "silvia.radu@apia.ro", "Silvia Radu", 44 },
                    { 20, 21, "andrei.pavel@apia.ro", "Andrei Pavel", 45 },
                    { 21, 22, "ioana.neagu@apia.ro", "Ioana Neagu", 46 },
                    { 22, 23, "radu.iliescu@apia.ro", "Radu Iliescu", 47 },
                    { 23, 13, "monica.florescu@apia.ro", "Monica Florescu", 48 },
                    { 24, 14, "george.petrescu@apia.ro", "George Petrescu", 49 },
                    { 25, 15, "daniela.voicu@apia.ro", "Daniela Voicu", 50 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 18);

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
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 43);

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
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 50);
        }
    }
}
