using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hunter.API.Migrations
{
    public partial class trialSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companys",
                columns: new[] { "Id", "Billing", "Name", "Region" },
                values: new object[] { 1, "free unlimited", "Solution Hunter Engineering", "NewEngland" });

            migrationBuilder.InsertData(
                table: "Features",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, null });

            migrationBuilder.InsertData(
                table: "Ghosts",
                columns: new[] { "Id", "Era", "Name", "ProjectId", "initialEra", "isActive" },
                values: new object[] { 1, 0, null, 0, "", true });

            migrationBuilder.InsertData(
                table: "Individuals",
                columns: new[] { "Id", "PopulationId" },
                values: new object[] { 1, 0 });

            migrationBuilder.InsertData(
                table: "Populations",
                columns: new[] { "Id", "Evolution" },
                values: new object[] { 1, 0 });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CompanyId", "Designer", "Name", "Runner" },
                values: new object[] { 1, 0, "Chuck Duncan", null, "Buttons Duncan" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companys",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ghosts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Individuals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Populations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
