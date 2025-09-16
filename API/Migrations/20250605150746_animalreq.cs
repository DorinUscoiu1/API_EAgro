using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class animalreq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnimalFundingRequestId",
                table: "Animals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AnimalFundingRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FarmerId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgentComment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalFundingRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimalFundingRequests_Farmers_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "Farmers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 1,
                column: "AnimalFundingRequestId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 2,
                column: "AnimalFundingRequestId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 3,
                column: "AnimalFundingRequestId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 4,
                column: "AnimalFundingRequestId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Animals_AnimalFundingRequestId",
                table: "Animals",
                column: "AnimalFundingRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalFundingRequests_FarmerId",
                table: "AnimalFundingRequests",
                column: "FarmerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_AnimalFundingRequests_AnimalFundingRequestId",
                table: "Animals",
                column: "AnimalFundingRequestId",
                principalTable: "AnimalFundingRequests",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_AnimalFundingRequests_AnimalFundingRequestId",
                table: "Animals");

            migrationBuilder.DropTable(
                name: "AnimalFundingRequests");

            migrationBuilder.DropIndex(
                name: "IX_Animals_AnimalFundingRequestId",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "AnimalFundingRequestId",
                table: "Animals");
        }
    }
}
