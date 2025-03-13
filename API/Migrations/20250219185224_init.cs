using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Agency = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Farmers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Budget = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farmers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Farmers_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FarmerRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FarmerId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmerRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FarmerRatings_Farmers_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "Farmers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<double>(type: "float", nullable: false),
                    FarmerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lands_Farmers_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "Farmers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Breed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    FarmerId = table.Column<int>(type: "int", nullable: false),
                    LandId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animals_Farmers_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "Farmers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animals_Lands_LandId",
                        column: x => x.LandId,
                        principalTable: "Lands",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Supplies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Quality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supplies_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "Agency", "Name" },
                values: new object[,]
                {
                    { 1, "AgroExperts", "Alex Johnson" },
                    { 2, "FarmAssist", "Laura Smith" },
                    { 3, "EcoFarm", "Robert Green" }
                });

            migrationBuilder.InsertData(
                table: "Supplies",
                columns: new[] { "Id", "AnimalId", "Name", "Price", "Quality", "Quantity" },
                values: new object[,]
                {
                    { 1, null, "Hay", 500m, "Good", 100 },
                    { 2, null, "Corn Feed", 700m, "Premium", 50 },
                    { 3, null, "Wheat Bran", 400m, "Standard", 80 },
                    { 4, null, "Rice Husk", 600m, "High", 120 }
                });

            migrationBuilder.InsertData(
                table: "Farmers",
                columns: new[] { "Id", "AgentId", "Budget", "Category", "Location", "Name" },
                values: new object[,]
                {
                    { 1, 1, 10000m, "Livestock", "Village A", "John Doe" },
                    { 2, 2, 15000m, "Crops", "Village B", "Jane Smith" },
                    { 3, 1, 20000m, "Dairy", "Village C", "Michael Brown" },
                    { 4, 3, 18000m, "Poultry", "Village D", "Emily Davis" }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Breed", "FarmerId", "LandId", "Name", "Price", "Weight" },
                values: new object[,]
                {
                    { 1, "Holstein", 1, null, "Cow 1", 1500m, 500.0 },
                    { 2, "Merino", 2, null, "Sheep 1", 300m, 80.0 },
                    { 3, "Boer", 2, null, "Goat 1", 200m, 50.0 },
                    { 4, "Leghorn", 4, null, "Chicken 1", 50m, 2.0 }
                });

            migrationBuilder.InsertData(
                table: "FarmerRatings",
                columns: new[] { "Id", "Comment", "CreatedAt", "FarmerId", "Rating" },
                values: new object[,]
                {
                    { 1, "Excellent work", new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc), 1, 5 },
                    { 2, "Good progress", new DateTime(2024, 1, 2, 14, 30, 0, 0, DateTimeKind.Utc), 2, 4 },
                    { 3, "Needs improvement", new DateTime(2024, 1, 3, 10, 15, 0, 0, DateTimeKind.Utc), 3, 3 },
                    { 4, "Very efficient", new DateTime(2024, 1, 4, 9, 45, 0, 0, DateTimeKind.Utc), 4, 5 }
                });

            migrationBuilder.InsertData(
                table: "Lands",
                columns: new[] { "Id", "Area", "FarmerId", "Location", "Type" },
                values: new object[,]
                {
                    { 1, 50.0, 1, "Field 1", "Pasture" },
                    { 2, 30.0, 2, "Field 2", "Corn" },
                    { 3, 40.0, 3, "Field 3", "Wheat" },
                    { 4, 60.0, 4, "Field 4", "Rice" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_FarmerId",
                table: "Animals",
                column: "FarmerId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_LandId",
                table: "Animals",
                column: "LandId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmerRatings_FarmerId",
                table: "FarmerRatings",
                column: "FarmerId");

            migrationBuilder.CreateIndex(
                name: "IX_Farmers_AgentId",
                table: "Farmers",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Lands_FarmerId",
                table: "Lands",
                column: "FarmerId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplies_AnimalId",
                table: "Supplies",
                column: "AnimalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FarmerRatings");

            migrationBuilder.DropTable(
                name: "Supplies");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Lands");

            migrationBuilder.DropTable(
                name: "Farmers");

            migrationBuilder.DropTable(
                name: "Agents");
        }
    }
}
