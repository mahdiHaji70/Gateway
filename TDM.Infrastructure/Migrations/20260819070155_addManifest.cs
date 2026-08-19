using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TDM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addManifest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.CreateTable(
                name: "Manifests",
                schema: "doc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SerialNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ManifestRegistrationNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VoyageNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NoticeNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ETA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ETD = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShipLine = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ShipAgent = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    VesselName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Imo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TerminalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manifests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ManifestItems",
                schema: "doc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManifestItemNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ManifestNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Consignor = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ShipLine = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ManifestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrafficId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConsigneeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShipAgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManifestItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManifestItems_Companies_ConsigneeId",
                        column: x => x.ConsigneeId,
                        principalSchema: "basicInfo",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ManifestItems_Companies_ShipAgentId",
                        column: x => x.ShipAgentId,
                        principalSchema: "basicInfo",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ManifestItems_Manifests_ManifestId",
                        column: x => x.ManifestId,
                        principalSchema: "doc",
                        principalTable: "Manifests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ManifestItems_Traffics_TrafficId",
                        column: x => x.TrafficId,
                        principalSchema: "basicInfo",
                        principalTable: "Traffics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ManifestContainers",
                schema: "doc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContainerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManifestItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BillOfLadingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SealNumber = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DangerousCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Classification = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IgnitionTemperature = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IgnitionTemperatureUnit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContainerId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManifestContainers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManifestContainers_Containers_ContainerId",
                        column: x => x.ContainerId,
                        principalSchema: "basicInfo",
                        principalTable: "Containers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ManifestContainers_Containers_ContainerId1",
                        column: x => x.ContainerId1,
                        principalSchema: "basicInfo",
                        principalTable: "Containers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ManifestContainers_ManifestItems_ManifestItemId",
                        column: x => x.ManifestItemId,
                        principalSchema: "doc",
                        principalTable: "ManifestItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ManifestGoods",
                schema: "doc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PackNb = table.Column<long>(type: "bigint", nullable: false),
                    GrossWeight = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    NetWeight = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Volume = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManifestItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommodityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PackageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManifestGoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManifestGoods_Commodities_CommodityId",
                        column: x => x.CommodityId,
                        principalSchema: "basicInfo",
                        principalTable: "Commodities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ManifestGoods_ManifestItems_ManifestItemId",
                        column: x => x.ManifestItemId,
                        principalSchema: "doc",
                        principalTable: "ManifestItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ManifestGoods_Packages_PackageId",
                        column: x => x.PackageId,
                        principalSchema: "basicInfo",
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ManifestContainerGoods",
                schema: "doc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PackNb = table.Column<long>(type: "bigint", nullable: false),
                    GrossWeight = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    NetWeight = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    ManifestContainerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PackageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommodityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManifestContainerGoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManifestContainerGoods_Commodities_CommodityId",
                        column: x => x.CommodityId,
                        principalSchema: "basicInfo",
                        principalTable: "Commodities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ManifestContainerGoods_ManifestContainers_ManifestContainerId",
                        column: x => x.ManifestContainerId,
                        principalSchema: "doc",
                        principalTable: "ManifestContainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ManifestContainerGoods_Packages_PackageId",
                        column: x => x.PackageId,
                        principalSchema: "basicInfo",
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ManifestContainerGoods_CommodityId",
                schema: "doc",
                table: "ManifestContainerGoods",
                column: "CommodityId");

            migrationBuilder.CreateIndex(
                name: "IX_ManifestContainerGoods_ManifestContainerId",
                schema: "doc",
                table: "ManifestContainerGoods",
                column: "ManifestContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_ManifestContainerGoods_PackageId",
                schema: "doc",
                table: "ManifestContainerGoods",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_ManifestContainers_ContainerId",
                schema: "doc",
                table: "ManifestContainers",
                column: "ContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_ManifestContainers_ContainerId1",
                schema: "doc",
                table: "ManifestContainers",
                column: "ContainerId1");

            migrationBuilder.CreateIndex(
                name: "IX_ManifestContainers_ManifestItemId",
                schema: "doc",
                table: "ManifestContainers",
                column: "ManifestItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ManifestGoods_CommodityId",
                schema: "doc",
                table: "ManifestGoods",
                column: "CommodityId");

            migrationBuilder.CreateIndex(
                name: "IX_ManifestGoods_ManifestItemId",
                schema: "doc",
                table: "ManifestGoods",
                column: "ManifestItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ManifestGoods_PackageId",
                schema: "doc",
                table: "ManifestGoods",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_ManifestItems_ConsigneeId",
                schema: "doc",
                table: "ManifestItems",
                column: "ConsigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_ManifestItems_ManifestId",
                schema: "doc",
                table: "ManifestItems",
                column: "ManifestId");

            migrationBuilder.CreateIndex(
                name: "IX_ManifestItems_ShipAgentId",
                schema: "doc",
                table: "ManifestItems",
                column: "ShipAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_ManifestItems_TrafficId",
                schema: "doc",
                table: "ManifestItems",
                column: "TrafficId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManifestContainerGoods",
                schema: "doc");

            migrationBuilder.DropTable(
                name: "ManifestGoods",
                schema: "doc");

            migrationBuilder.DropTable(
                name: "ManifestContainers",
                schema: "doc");

            migrationBuilder.DropTable(
                name: "ManifestItems",
                schema: "doc");

            migrationBuilder.DropTable(
                name: "Manifests",
                schema: "doc");

            
        }
    }
}
