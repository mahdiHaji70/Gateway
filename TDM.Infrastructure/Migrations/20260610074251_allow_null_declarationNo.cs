using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TDM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class allow_null_declarationNo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IpasDeclarationNo",
                schema: "doc",
                table: "Declarations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IpasDeclarationNo",
                schema: "doc",
                table: "Declarations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
