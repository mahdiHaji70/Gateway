using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExternalIntegration.Service.Migrations
{
    /// <inheritdoc />
    public partial class addmanifestchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ManifestChanges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TerminalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RevisionNo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Port = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PortCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManifestLocalNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VoyageNoticeNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingLineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShippingLine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAgentIdNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAgent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChangeLogs = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManifestChanges", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManifestChanges");
        }
    }
}
