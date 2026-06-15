using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TDM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_declaration_container_and_goods : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeclarationContainers",
                schema: "doc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    No = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeAndSizeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeAndSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeclarationItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeclarationContainers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeclarationContainers_DeclarationItems_DeclarationItemId",
                        column: x => x.DeclarationItemId,
                        principalSchema: "doc",
                        principalTable: "DeclarationItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeclarationContainerGoods",
                schema: "doc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<long>(type: "bigint", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeclarationContainerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommodityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PackageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeclarationContainerGoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeclarationContainerGoods_Commodities_CommodityId",
                        column: x => x.CommodityId,
                        principalSchema: "basicInfo",
                        principalTable: "Commodities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeclarationContainerGoods_DeclarationContainers_DeclarationContainerId",
                        column: x => x.DeclarationContainerId,
                        principalSchema: "doc",
                        principalTable: "DeclarationContainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeclarationContainerGoods_Packages_PackageId",
                        column: x => x.PackageId,
                        principalSchema: "basicInfo",
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationContainerGoods_CommodityId",
                schema: "doc",
                table: "DeclarationContainerGoods",
                column: "CommodityId");

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationContainerGoods_DeclarationContainerId",
                schema: "doc",
                table: "DeclarationContainerGoods",
                column: "DeclarationContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationContainerGoods_PackageId",
                schema: "doc",
                table: "DeclarationContainerGoods",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationContainers_DeclarationItemId",
                schema: "doc",
                table: "DeclarationContainers",
                column: "DeclarationItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeclarationContainerGoods",
                schema: "doc");

            migrationBuilder.DropTable(
                name: "DeclarationContainers",
                schema: "doc");
        }
    }
}
