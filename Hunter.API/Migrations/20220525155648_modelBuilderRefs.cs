using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hunter.API.Migrations
{
    public partial class modelBuilderRefs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeatureIndividual");

            migrationBuilder.AddColumn<int>(
                name: "IndividualId",
                table: "Features",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ghosts_PopulationId",
                table: "Ghosts",
                column: "PopulationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Features_IndividualId",
                table: "Features",
                column: "IndividualId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_Individuals_IndividualId",
                table: "Features");

            migrationBuilder.DropForeignKey(
                name: "FK_Ghosts_Populations_PopulationId",
                table: "Ghosts");

            migrationBuilder.DropIndex(
                name: "IX_Ghosts_PopulationId",
                table: "Ghosts");

            migrationBuilder.DropIndex(
                name: "IX_Features_IndividualId",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "IndividualId",
                table: "Features");

            migrationBuilder.CreateTable(
                name: "FeatureIndividual",
                columns: table => new
                {
                    FeaturesId = table.Column<int>(type: "int", nullable: false),
                    IndividualId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureIndividual", x => new { x.FeaturesId, x.IndividualId });
                    table.ForeignKey(
                        name: "FK_FeatureIndividual_Features_FeaturesId",
                        column: x => x.FeaturesId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeatureIndividual_Individuals_IndividualId",
                        column: x => x.IndividualId,
                        principalTable: "Individuals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeatureIndividual_IndividualId",
                table: "FeatureIndividual",
                column: "IndividualId");
        }
    }
}
