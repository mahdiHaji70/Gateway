using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TDM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_declaration_date : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                schema: "doc",
                table: "Declarations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                schema: "doc",
                table: "Declarations");
        }
    }
}
