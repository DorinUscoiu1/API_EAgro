using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class addedfarmersupply : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalSupplies");

            migrationBuilder.CreateTable(
                name: "FarmerSupply",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FarmerId = table.Column<int>(type: "int", nullable: false),
                    SupplyId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmerSupply", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FarmerSupply_Farmers_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "Farmers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FarmerSupply_Supplies_SupplyId",
                        column: x => x.SupplyId,
                        principalTable: "Supplies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FarmerSupply",
                columns: new[] { "Id", "FarmerId", "Quantity", "SupplyId" },
                values: new object[] { 9, 2, 30, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_FarmerSupply_FarmerId",
                table: "FarmerSupply",
                column: "FarmerId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmerSupply_SupplyId",
                table: "FarmerSupply",
                column: "SupplyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FarmerSupply");

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
                values: new object[,]
                {
                    { 1, 2, 20, 2 },
                    { 2, 2, 10, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalSupplies_AnimalId",
                table: "AnimalSupplies",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalSupplies_SupplyId",
                table: "AnimalSupplies",
                column: "SupplyId");
        }
    }
}
