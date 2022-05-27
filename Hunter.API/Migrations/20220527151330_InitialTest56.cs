using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hunter.API.Migrations
{
    public partial class InitialTest56 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ghost_Projects_ProjectId",
                table: "Ghost");

            migrationBuilder.DropForeignKey(
                name: "FK_Population_Ghost_GhostId",
                table: "Population");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ghost",
                table: "Ghost");

            migrationBuilder.RenameTable(
                name: "Ghost",
                newName: "Ghosts");

            migrationBuilder.RenameIndex(
                name: "IX_Ghost_ProjectId",
                table: "Ghosts",
                newName: "IX_Ghosts_ProjectId");

            migrationBuilder.AddColumn<double>(
                name: "Fitness",
                table: "Individuals",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Generations",
                table: "Individuals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PopulationPosition",
                table: "Individuals",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "FK_Population_Ghosts_GhostId",
                table: "Population",
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
                name: "FK_Population_Ghosts_GhostId",
                table: "Population");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ghosts",
                table: "Ghosts");

            migrationBuilder.DropColumn(
                name: "Fitness",
                table: "Individuals");

            migrationBuilder.DropColumn(
                name: "Generations",
                table: "Individuals");

            migrationBuilder.DropColumn(
                name: "PopulationPosition",
                table: "Individuals");

            migrationBuilder.RenameTable(
                name: "Ghosts",
                newName: "Ghost");

            migrationBuilder.RenameIndex(
                name: "IX_Ghosts_ProjectId",
                table: "Ghost",
                newName: "IX_Ghost_ProjectId");

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
                name: "FK_Population_Ghost_GhostId",
                table: "Population",
                column: "GhostId",
                principalTable: "Ghost",
                principalColumn: "Id");
        }
    }
}
