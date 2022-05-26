using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hunter.API.Migrations
{
    public partial class trialSeeding1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PopulationId",
                table: "Ghosts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Ghosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProjectId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "CompanyId",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PopulationId",
                table: "Ghosts");

            migrationBuilder.UpdateData(
                table: "Ghosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProjectId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "CompanyId",
                value: 0);
        }
    }
}
