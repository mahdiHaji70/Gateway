using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TDM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addcargotypetomanifestitem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ManifestContainerId",
                schema: "operation",
                table: "VesselDischarges",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CargoTypeId",
                schema: "doc",
                table: "ManifestItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_VesselDischarges_ManifestContainerId",
                schema: "operation",
                table: "VesselDischarges",
                column: "ManifestContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_ManifestItems_CargoTypeId",
                schema: "doc",
                table: "ManifestItems",
                column: "CargoTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ManifestItems_CargoTypes_CargoTypeId",
                schema: "doc",
                table: "ManifestItems",
                column: "CargoTypeId",
                principalSchema: "basicInfo",
                principalTable: "CargoTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VesselDischarges_ManifestContainers_ManifestContainerId",
                schema: "operation",
                table: "VesselDischarges",
                column: "ManifestContainerId",
                principalSchema: "doc",
                principalTable: "ManifestContainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ManifestItems_CargoTypes_CargoTypeId",
                schema: "doc",
                table: "ManifestItems");

            migrationBuilder.DropForeignKey(
                name: "FK_VesselDischarges_ManifestContainers_ManifestContainerId",
                schema: "operation",
                table: "VesselDischarges");

            migrationBuilder.DropIndex(
                name: "IX_VesselDischarges_ManifestContainerId",
                schema: "operation",
                table: "VesselDischarges");

            migrationBuilder.DropIndex(
                name: "IX_ManifestItems_CargoTypeId",
                schema: "doc",
                table: "ManifestItems");

            migrationBuilder.DropColumn(
                name: "ManifestContainerId",
                schema: "operation",
                table: "VesselDischarges");

            migrationBuilder.DropColumn(
                name: "CargoTypeId",
                schema: "doc",
                table: "ManifestItems");
        }
    }
}
