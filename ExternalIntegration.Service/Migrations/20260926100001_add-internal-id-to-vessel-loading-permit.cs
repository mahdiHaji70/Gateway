using System;
using ExternalIntegration.Service.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExternalIntegration.Service.Migrations
{
    /// <inheritdoc />
    [DbContext(typeof(GatewayDbContext))]
    [Migration("20260926100001_add-internal-id-to-vessel-loading-permit")]
    public partial class addinternalidtovesselloadingpermit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "InternalId",
                table: "VesselLoadingPermits",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID()");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VesselLoadingPermits",
                table: "VesselLoadingPermits");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VesselLoadingPermits",
                table: "VesselLoadingPermits",
                column: "InternalId");

            migrationBuilder.CreateIndex(
                name: "IX_VesselLoadingPermits_Id",
                table: "VesselLoadingPermits",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VesselLoadingPermits_Id",
                table: "VesselLoadingPermits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VesselLoadingPermits",
                table: "VesselLoadingPermits");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VesselLoadingPermits",
                table: "VesselLoadingPermits",
                column: "Id");

            migrationBuilder.DropColumn(
                name: "InternalId",
                table: "VesselLoadingPermits");
        }
    }
}
