using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hunter.API.Migrations
{
    public partial class Initialtest1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Population_GhostId",
                table: "Population");

            migrationBuilder.DropColumn(
                name: "PopulationId",
                table: "Ghost");

            migrationBuilder.AddColumn<int>(
                name: "ProjectGhostId",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Population_GhostId",
                table: "Population",
                column: "GhostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Population_GhostId",
                table: "Population");

            migrationBuilder.DropColumn(
                name: "ProjectGhostId",
                table: "Projects");

            migrationBuilder.AddColumn<int>(
                name: "PopulationId",
                table: "Ghost",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Population_GhostId",
                table: "Population",
                column: "GhostId",
                unique: true,
                filter: "[GhostId] IS NOT NULL");
        }
    }
}
