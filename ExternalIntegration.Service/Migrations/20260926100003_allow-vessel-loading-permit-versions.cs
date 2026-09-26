using ExternalIntegration.Service.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExternalIntegration.Service.Migrations
{
    /// <inheritdoc />
    [DbContext(typeof(GatewayDbContext))]
    [Migration("20260926100003_allow-vessel-loading-permit-versions")]
    public partial class allowvesselloadingpermitversions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VesselLoadingPermits_Id",
                table: "VesselLoadingPermits");

            migrationBuilder.CreateIndex(
                name: "IX_VesselLoadingPermits_Id_ExpirationDate",
                table: "VesselLoadingPermits",
                columns: new[] { "Id", "ExpirationDate" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VesselLoadingPermits_Id_ExpirationDate",
                table: "VesselLoadingPermits");

            migrationBuilder.CreateIndex(
                name: "IX_VesselLoadingPermits_Id",
                table: "VesselLoadingPermits",
                column: "Id",
                unique: true);
        }
    }
}
