using ExternalIntegration.Service.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExternalIntegration.Service.Migrations
{
    /// <inheritdoc />
    [DbContext(typeof(GatewayDbContext))]
    [Migration("20260926100004_allow-loading-permit-versions")]
    public partial class allowloadingpermitversions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LoadingPermits_Id",
                table: "LoadingPermits");

            migrationBuilder.CreateIndex(
                name: "IX_LoadingPermits_Id_ExpirationDate",
                table: "LoadingPermits",
                columns: new[] { "Id", "ExpirationDate" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LoadingPermits_Id_ExpirationDate",
                table: "LoadingPermits");

            migrationBuilder.CreateIndex(
                name: "IX_LoadingPermits_Id",
                table: "LoadingPermits",
                column: "Id",
                unique: true);
        }
    }
}
