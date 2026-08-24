using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TDM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addvesseldischarge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
  

            migrationBuilder.AddColumn<Guid>(
                name: "IpasItemId",
                schema: "doc",
                table: "ManifestItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "VesselDischarges",
                schema: "operation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TerminalCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManifestItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DischargeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PackNB = table.Column<long>(type: "bigint", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    Volume = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    IsNonPalletized = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsDamaged = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsVoluminous = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsDangerous = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DangerousCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Classification = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IgnitionTemperature = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: true),
                    IgnitionTemperatureUnit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IpasVesselDischargeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IpasVesselDischargeReceivedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UnitWeight = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false, defaultValue: 0m),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VesselDischarges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VesselDischarges_ManifestItems_ManifestItemId",
                        column: x => x.ManifestItemId,
                        principalSchema: "doc",
                        principalTable: "ManifestItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VesselDischarges_Stores_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "basicInfo",
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });         

            migrationBuilder.CreateIndex(
                name: "IX_VesselDischarges_IpasVesselDischargeId",
                schema: "operation",
                table: "VesselDischarges",
                column: "IpasVesselDischargeId",
                unique: true,
                filter: "[IpasVesselDischargeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VesselDischarges_ManifestItemId",
                schema: "operation",
                table: "VesselDischarges",
                column: "ManifestItemId");

            migrationBuilder.CreateIndex(
                name: "IX_VesselDischarges_StoreId",
                schema: "operation",
                table: "VesselDischarges",
                column: "StoreId");
    
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropForeignKey(
                name: "FK_TerminalDischarges_CargoTypes_CargoTypeId",
                schema: "operation",
                table: "TerminalDischarges");

            migrationBuilder.DropTable(
                name: "VesselDischarges",
                schema: "operation");

            migrationBuilder.DropColumn(
                name: "IpasItemId",
                schema: "doc",
                table: "ManifestItems");
        }
    }
}
