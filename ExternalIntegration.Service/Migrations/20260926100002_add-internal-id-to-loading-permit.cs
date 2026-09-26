using System;
using ExternalIntegration.Service.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExternalIntegration.Service.Migrations
{
    /// <inheritdoc />
    [DbContext(typeof(GatewayDbContext))]
    [Migration("20260926100002_add-internal-id-to-loading-permit")]
    public partial class addinternalidtoloadingpermit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "InternalId",
                table: "LoadingPermits",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID()");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoadingPermits",
                table: "LoadingPermits");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoadingPermits",
                table: "LoadingPermits",
                column: "InternalId");

            migrationBuilder.CreateIndex(
                name: "IX_LoadingPermits_Id",
                table: "LoadingPermits",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LoadingPermits_Id",
                table: "LoadingPermits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoadingPermits",
                table: "LoadingPermits");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoadingPermits",
                table: "LoadingPermits",
                column: "Id");

            migrationBuilder.DropColumn(
                name: "InternalId",
                table: "LoadingPermits");
        }
    }
}
