using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class medrtyhuxedrftgedrftg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplies_Animals_AnimalId",
                table: "Supplies");

            migrationBuilder.DeleteData(
                table: "Supplies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Supplies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AlterColumn<int>(
                name: "AnimalId",
                table: "Supplies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Supplies",
                keyColumn: "Id",
                keyValue: 1,
                column: "AnimalId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Supplies",
                keyColumn: "Id",
                keyValue: 2,
                column: "AnimalId",
                value: 2);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplies_Animals_AnimalId",
                table: "Supplies",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplies_Animals_AnimalId",
                table: "Supplies");

            migrationBuilder.AlterColumn<int>(
                name: "AnimalId",
                table: "Supplies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Supplies",
                keyColumn: "Id",
                keyValue: 1,
                column: "AnimalId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Supplies",
                keyColumn: "Id",
                keyValue: 2,
                column: "AnimalId",
                value: null);

            migrationBuilder.InsertData(
                table: "Supplies",
                columns: new[] { "Id", "AnimalId", "Name", "Price", "Quality", "Quantity" },
                values: new object[,]
                {
                    { 3, null, "Wheat Bran", 400m, "Standard", 80 },
                    { 4, null, "Rice Husk", 600m, "High", 120 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Supplies_Animals_AnimalId",
                table: "Supplies",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "Id");
        }
    }
}
