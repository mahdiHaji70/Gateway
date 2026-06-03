using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TDM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addTerminalCodeToDeclaration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TerminalCode",
                schema: "doc",
                table: "Declarations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TerminalCode",
                schema: "doc",
                table: "Declarations");
        }
    }
}
