using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hunter.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Billing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Designer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Runner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Companys_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ghost",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Era = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    initialEra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    PopulationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ghost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ghost_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Population",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Evolution = table.Column<int>(type: "int", nullable: false),
                    GhostId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Population", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Population_Ghost_GhostId",
                        column: x => x.GhostId,
                        principalTable: "Ghost",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Individual",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PopulationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Individual", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Individual_Population_PopulationId",
                        column: x => x.PopulationId,
                        principalTable: "Population",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Feature",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndividualId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feature_Individual_IndividualId",
                        column: x => x.IndividualId,
                        principalTable: "Individual",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Companys",
                columns: new[] { "Id", "Billing", "Name", "Region" },
                values: new object[] { 1, "free unlimited", "Solution Hunter Engineering", "NewEngland" });

            migrationBuilder.InsertData(
                table: "Feature",
                columns: new[] { "Id", "IndividualId" },
                values: new object[] { 1, null });

            migrationBuilder.InsertData(
                table: "Individual",
                columns: new[] { "Id", "PopulationId" },
                values: new object[] { 1, null });

            migrationBuilder.InsertData(
                table: "Population",
                columns: new[] { "Id", "Evolution", "GhostId" },
                values: new object[] { 1, 0, null });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CompanyId", "Description", "Designer", "Runner", "Title" },
                values: new object[] { 1, 1, null, "Chuck Duncan", "Buttons Duncan", "Sample Project" });

            migrationBuilder.InsertData(
                table: "Ghost",
                columns: new[] { "Id", "Era", "PopulationId", "ProjectId", "initialEra", "isActive" },
                values: new object[] { 1, 0, 0, 1, "", true });

            migrationBuilder.CreateIndex(
                name: "IX_Feature_IndividualId",
                table: "Feature",
                column: "IndividualId");

            migrationBuilder.CreateIndex(
                name: "IX_Ghost_ProjectId",
                table: "Ghost",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Individual_PopulationId",
                table: "Individual",
                column: "PopulationId");

            migrationBuilder.CreateIndex(
                name: "IX_Population_GhostId",
                table: "Population",
                column: "GhostId",
                unique: true,
                filter: "[GhostId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CompanyId",
                table: "Projects",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feature");

            migrationBuilder.DropTable(
                name: "Individual");

            migrationBuilder.DropTable(
                name: "Population");

            migrationBuilder.DropTable(
                name: "Ghost");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Companys");
        }
    }
}
