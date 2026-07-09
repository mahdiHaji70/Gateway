using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExternalIntegration.Service.Migrations
{
    /// <inheritdoc />
    public partial class nnasirivoyage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Voyages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VoyageNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoticeNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoticeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Eta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Etd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocalPortCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsContainerized = table.Column<bool>(type: "bit", nullable: false),
                    PortOfLoadingCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PortOfDischargeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastPortCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NextPortCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingLineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShippingLine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAgent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAgentCompanyIdNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VesselData = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voyages", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Voyages");
        }
    }
}
