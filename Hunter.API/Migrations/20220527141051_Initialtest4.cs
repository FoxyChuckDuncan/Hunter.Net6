using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hunter.API.Migrations
{
    public partial class Initialtest4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ghost_Projects_ProjectId",
                table: "Ghost");

            migrationBuilder.DropForeignKey(
                name: "FK_Individual_Population_PopulationId",
                table: "Individual");

            migrationBuilder.DropForeignKey(
                name: "FK_Population_Ghost_GhostId",
                table: "Population");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Population",
                table: "Population");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ghost",
                table: "Ghost");

            migrationBuilder.RenameTable(
                name: "Population",
                newName: "Populations");

            migrationBuilder.RenameTable(
                name: "Ghost",
                newName: "Ghosts");

            migrationBuilder.RenameIndex(
                name: "IX_Population_GhostId",
                table: "Populations",
                newName: "IX_Populations_GhostId");

            migrationBuilder.RenameIndex(
                name: "IX_Ghost_ProjectId",
                table: "Ghosts",
                newName: "IX_Ghosts_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Populations",
                table: "Populations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ghosts",
                table: "Ghosts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ghosts_Projects_ProjectId",
                table: "Ghosts",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Individual_Populations_PopulationId",
                table: "Individual",
                column: "PopulationId",
                principalTable: "Populations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Populations_Ghosts_GhostId",
                table: "Populations",
                column: "GhostId",
                principalTable: "Ghosts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ghosts_Projects_ProjectId",
                table: "Ghosts");

            migrationBuilder.DropForeignKey(
                name: "FK_Individual_Populations_PopulationId",
                table: "Individual");

            migrationBuilder.DropForeignKey(
                name: "FK_Populations_Ghosts_GhostId",
                table: "Populations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Populations",
                table: "Populations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ghosts",
                table: "Ghosts");

            migrationBuilder.RenameTable(
                name: "Populations",
                newName: "Population");

            migrationBuilder.RenameTable(
                name: "Ghosts",
                newName: "Ghost");

            migrationBuilder.RenameIndex(
                name: "IX_Populations_GhostId",
                table: "Population",
                newName: "IX_Population_GhostId");

            migrationBuilder.RenameIndex(
                name: "IX_Ghosts_ProjectId",
                table: "Ghost",
                newName: "IX_Ghost_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Population",
                table: "Population",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ghost",
                table: "Ghost",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ghost_Projects_ProjectId",
                table: "Ghost",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Individual_Population_PopulationId",
                table: "Individual",
                column: "PopulationId",
                principalTable: "Population",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Population_Ghost_GhostId",
                table: "Population",
                column: "GhostId",
                principalTable: "Ghost",
                principalColumn: "Id");
        }
    }
}
