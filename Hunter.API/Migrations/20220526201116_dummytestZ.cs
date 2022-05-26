using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hunter.API.Migrations
{
    public partial class dummytestZ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Populations_GhostId",
                table: "Populations");

            migrationBuilder.AddColumn<int>(
                name: "PopulationId",
                table: "Ghosts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Populations_GhostId",
                table: "Populations",
                column: "GhostId",
                unique: true,
                filter: "[GhostId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Populations_GhostId",
                table: "Populations");

            migrationBuilder.DropColumn(
                name: "PopulationId",
                table: "Ghosts");

            migrationBuilder.CreateIndex(
                name: "IX_Populations_GhostId",
                table: "Populations",
                column: "GhostId");
        }
    }
}
