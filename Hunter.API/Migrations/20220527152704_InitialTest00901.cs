using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hunter.API.Migrations
{
    public partial class InitialTest00901 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feature_Individuals_IndividualId",
                table: "Feature");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Feature",
                table: "Feature");

            migrationBuilder.RenameTable(
                name: "Feature",
                newName: "Features");

            migrationBuilder.RenameIndex(
                name: "IX_Feature_IndividualId",
                table: "Features",
                newName: "IX_Features_IndividualId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Features",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Features",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Features",
                table: "Features",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 1,
                column: "IndividualId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Individuals",
                keyColumn: "Id",
                keyValue: 1,
                column: "PopulationId",
                value: 1);

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Individuals_IndividualId",
                table: "Features",
                column: "IndividualId",
                principalTable: "Individuals",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_Individuals_IndividualId",
                table: "Features");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Features",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Features");

            migrationBuilder.RenameTable(
                name: "Features",
                newName: "Feature");

            migrationBuilder.RenameIndex(
                name: "IX_Features_IndividualId",
                table: "Feature",
                newName: "IX_Feature_IndividualId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feature",
                table: "Feature",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: 1,
                column: "IndividualId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Individuals",
                keyColumn: "Id",
                keyValue: 1,
                column: "PopulationId",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_Feature_Individuals_IndividualId",
                table: "Feature",
                column: "IndividualId",
                principalTable: "Individuals",
                principalColumn: "Id");
        }
    }
}
