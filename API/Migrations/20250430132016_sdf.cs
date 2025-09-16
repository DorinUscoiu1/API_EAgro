using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class sdf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Lands_LandId",
                table: "Animals");

            migrationBuilder.DropIndex(
                name: "IX_Animals_LandId",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "LandId",
                table: "Animals");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LandId",
                table: "Animals",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 1,
                column: "LandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 2,
                column: "LandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 3,
                column: "LandId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 4,
                column: "LandId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Animals_LandId",
                table: "Animals",
                column: "LandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Lands_LandId",
                table: "Animals",
                column: "LandId",
                principalTable: "Lands",
                principalColumn: "Id");
        }
    }
}
