using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TDM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class edit_declaration_ipas_fields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IpasDeclarationIdReceivedAt",
                schema: "doc",
                table: "Declarations",
                newName: "IpasDeclarationReceivedAt");

            migrationBuilder.AlterColumn<Guid>(
                name: "IpasDeclarationId",
                schema: "doc",
                table: "Declarations",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IpasDeclarationNo",
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
                name: "IpasDeclarationNo",
                schema: "doc",
                table: "Declarations");

            migrationBuilder.RenameColumn(
                name: "IpasDeclarationReceivedAt",
                schema: "doc",
                table: "Declarations",
                newName: "IpasDeclarationIdReceivedAt");

            migrationBuilder.AlterColumn<string>(
                name: "IpasDeclarationId",
                schema: "doc",
                table: "Declarations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }
    }
}
