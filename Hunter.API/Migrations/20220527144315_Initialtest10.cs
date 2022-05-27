using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hunter.API.Migrations
{
    public partial class Initialtest10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feature_Individual_IndividualId",
                table: "Feature");

            migrationBuilder.DropForeignKey(
                name: "FK_Individual_Population_PopulationId",
                table: "Individual");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Individual",
                table: "Individual");

            migrationBuilder.RenameTable(
                name: "Individual",
                newName: "Individuals");

            migrationBuilder.RenameIndex(
                name: "IX_Individual_PopulationId",
                table: "Individuals",
                newName: "IX_Individuals_PopulationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Individuals",
                table: "Individuals",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Ghost",
                keyColumn: "Id",
                keyValue: 1,
                column: "PopulationId",
                value: 1);

            migrationBuilder.AddForeignKey(
                name: "FK_Feature_Individuals_IndividualId",
                table: "Feature",
                column: "IndividualId",
                principalTable: "Individuals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Individuals_Population_PopulationId",
                table: "Individuals",
                column: "PopulationId",
                principalTable: "Population",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feature_Individuals_IndividualId",
                table: "Feature");

            migrationBuilder.DropForeignKey(
                name: "FK_Individuals_Population_PopulationId",
                table: "Individuals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Individuals",
                table: "Individuals");

            migrationBuilder.RenameTable(
                name: "Individuals",
                newName: "Individual");

            migrationBuilder.RenameIndex(
                name: "IX_Individuals_PopulationId",
                table: "Individual",
                newName: "IX_Individual_PopulationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Individual",
                table: "Individual",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Ghost",
                keyColumn: "Id",
                keyValue: 1,
                column: "PopulationId",
                value: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Feature_Individual_IndividualId",
                table: "Feature",
                column: "IndividualId",
                principalTable: "Individual",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Individual_Population_PopulationId",
                table: "Individual",
                column: "PopulationId",
                principalTable: "Population",
                principalColumn: "Id");
        }
    }
}
