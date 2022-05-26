using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hunter.API.Migrations
{
    public partial class SyntaxUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_Individuals_IndividualId",
                table: "Features");

            migrationBuilder.DropForeignKey(
                name: "FK_Ghosts_Populations_PopulationId",
                table: "Ghosts");

            migrationBuilder.DropForeignKey(
                name: "FK_Individuals_Populations_PopulationId",
                table: "Individuals");

            migrationBuilder.DropIndex(
                name: "IX_Ghosts_PopulationId",
                table: "Ghosts");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Ghosts");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Features");

            migrationBuilder.AddColumn<int>(
                name: "GhostId",
                table: "Populations",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PopulationId",
                table: "Individuals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PopulationId",
                table: "Ghosts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IndividualId",
                table: "Features",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 1,
                column: "IndividualId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Ghosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "PopulationId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Individuals",
                keyColumn: "Id",
                keyValue: 1,
                column: "PopulationId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Populations_GhostId",
                table: "Populations",
                column: "GhostId",
                unique: true,
                filter: "[GhostId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Individuals_IndividualId",
                table: "Features",
                column: "IndividualId",
                principalTable: "Individuals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Individuals_Populations_PopulationId",
                table: "Individuals",
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
                name: "FK_Features_Individuals_IndividualId",
                table: "Features");

            migrationBuilder.DropForeignKey(
                name: "FK_Individuals_Populations_PopulationId",
                table: "Individuals");

            migrationBuilder.DropForeignKey(
                name: "FK_Populations_Ghosts_GhostId",
                table: "Populations");

            migrationBuilder.DropIndex(
                name: "IX_Populations_GhostId",
                table: "Populations");

            migrationBuilder.DropColumn(
                name: "GhostId",
                table: "Populations");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PopulationId",
                table: "Individuals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PopulationId",
                table: "Ghosts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Ghosts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IndividualId",
                table: "Features",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Features",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 1,
                column: "IndividualId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Ghosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "PopulationId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Individuals",
                keyColumn: "Id",
                keyValue: 1,
                column: "PopulationId",
                value: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ghosts_PopulationId",
                table: "Ghosts",
                column: "PopulationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Individuals_IndividualId",
                table: "Features",
                column: "IndividualId",
                principalTable: "Individuals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ghosts_Populations_PopulationId",
                table: "Ghosts",
                column: "PopulationId",
                principalTable: "Populations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Individuals_Populations_PopulationId",
                table: "Individuals",
                column: "PopulationId",
                principalTable: "Populations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
