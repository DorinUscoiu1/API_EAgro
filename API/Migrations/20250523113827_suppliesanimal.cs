using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class suppliesanimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplies_Animals_AnimalId",
                table: "Supplies");

            migrationBuilder.DropIndex(
                name: "IX_Supplies_AnimalId",
                table: "Supplies");

            migrationBuilder.DropColumn(
                name: "AnimalId",
                table: "Supplies");

            migrationBuilder.CreateTable(
                name: "AnimalSupplies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    SupplyId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalSupplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimalSupplies_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimalSupplies_Supplies_SupplyId",
                        column: x => x.SupplyId,
                        principalTable: "Supplies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AnimalSupplies",
                columns: new[] { "Id", "AnimalId", "Quantity", "SupplyId" },
                values: new object[] { 1, 2, 20, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalSupplies_AnimalId",
                table: "AnimalSupplies",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalSupplies_SupplyId",
                table: "AnimalSupplies",
                column: "SupplyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalSupplies");

            migrationBuilder.AddColumn<int>(
                name: "AnimalId",
                table: "Supplies",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Supplies_AnimalId",
                table: "Supplies",
                column: "AnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplies_Animals_AnimalId",
                table: "Supplies",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
