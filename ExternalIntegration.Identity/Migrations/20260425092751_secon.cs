using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntegratedIdentity.Migrations
{
    /// <inheritdoc />
    public partial class secon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TermidasnalCode",
                table: "Users",
                newName: "TerminalCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TerminalCode",
                table: "Users",
                newName: "TermidasnalCode");
        }
    }
}
