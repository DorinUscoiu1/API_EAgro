using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class solver : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Farmers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Agents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "alex.johnson@example.com");

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 2,
                column: "Email",
                value: "laura.smith@example.com");

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 3,
                column: "Email",
                value: "robert.green@example.com");

            migrationBuilder.UpdateData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "john.doe@example.com");

            migrationBuilder.UpdateData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Email",
                value: "jane.smith@example.com");

            migrationBuilder.UpdateData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Email",
                value: "michael.brown@example.com");

            migrationBuilder.UpdateData(
                table: "Farmers",
                keyColumn: "Id",
                keyValue: 4,
                column: "Email",
                value: "emily.davis@example.com");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Farmers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Agents");
        }
    }
}
