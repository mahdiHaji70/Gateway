using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TDM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class change_common_to_basicInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "basicInfo");

            migrationBuilder.RenameTable(
                name: "Companies",
                schema: "common",
                newName: "Companies",
                newSchema: "basicInfo");

            migrationBuilder.RenameTable(
                name: "Commodities",
                schema: "common",
                newName: "Commodities",
                newSchema: "basicInfo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "common");

            migrationBuilder.RenameTable(
                name: "Companies",
                schema: "basicInfo",
                newName: "Companies",
                newSchema: "common");

            migrationBuilder.RenameTable(
                name: "Commodities",
                schema: "basicInfo",
                newName: "Commodities",
                newSchema: "common");
        }
    }
}
