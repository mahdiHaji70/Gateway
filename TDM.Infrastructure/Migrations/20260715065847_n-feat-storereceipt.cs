using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TDM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class nfeatstorereceipt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_TerminalDischarges_CargoTypes_StoreId",
            //    schema: "operation",
            //    table: "TerminalDischarges");

            migrationBuilder.AlterColumn<string>(
                name: "TerminalCode",
                schema: "operation",
                table: "TerminalDischarges",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 4);

            migrationBuilder.AlterColumn<decimal>(
                name: "IgnitionTemperature",
                schema: "operation",
                table: "TerminalDischarges",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            //migrationBuilder.AddColumn<Guid>(
            //    name: "IpasTerminalDischargeId",
            //    schema: "operation",
            //    table: "TerminalDischarges",
            //    type: "uniqueidentifier",
            //    nullable: true);

            //migrationBuilder.AddColumn<DateTime>(
            //    name: "IpasTerminalDischargeReceivedAt",
            //    schema: "operation",
            //    table: "TerminalDischarges",
            //    type: "datetime2",
            //    nullable: true);

            migrationBuilder.CreateTable(
                name: "ArrivalTypes",
                schema: "basicInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArrivalTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gates",
                schema: "operation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeclarationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Vehicle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContainerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EnterDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExitDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gates_Declarations_DeclarationId",
                        column: x => x.DeclarationId,
                        principalSchema: "doc",
                        principalTable: "Declarations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoreReceiptStates",
                schema: "basicInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreReceiptStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeightBridges",
                schema: "operation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeclarationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Vehicle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GrossWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TareWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightBridges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeightBridges_Declarations_DeclarationId",
                        column: x => x.DeclarationId,
                        principalSchema: "doc",
                        principalTable: "Declarations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoreReceiptHeads",
                schema: "doc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TerminalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IPASStoreReceiptNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConsigneeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConsigneeRepId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CargoTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstDischargeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrafficId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreReceiptStateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VoyageNoticeNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArrivalTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeclarationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BillOfLadingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreReceiptHeads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreReceiptHeads_ArrivalTypes_ArrivalTypeId",
                        column: x => x.ArrivalTypeId,
                        principalSchema: "basicInfo",
                        principalTable: "ArrivalTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoreReceiptHeads_CargoTypes_CargoTypeId",
                        column: x => x.CargoTypeId,
                        principalSchema: "basicInfo",
                        principalTable: "CargoTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoreReceiptHeads_Companies_ConsigneeId",
                        column: x => x.ConsigneeId,
                        principalSchema: "basicInfo",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoreReceiptHeads_Companies_ConsigneeRepId",
                        column: x => x.ConsigneeRepId,
                        principalSchema: "basicInfo",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoreReceiptHeads_Companies_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "basicInfo",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreReceiptHeads_Declarations_DeclarationId",
                        column: x => x.DeclarationId,
                        principalSchema: "doc",
                        principalTable: "Declarations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StoreReceiptHeads_StoreReceiptStates_StoreReceiptStateId",
                        column: x => x.StoreReceiptStateId,
                        principalSchema: "basicInfo",
                        principalTable: "StoreReceiptStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoreReceiptHeads_Traffics_TrafficId",
                        column: x => x.TrafficId,
                        principalSchema: "basicInfo",
                        principalTable: "Traffics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreReceiptContainers",
                schema: "doc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreReceiptHeadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContainerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SealNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DangerousCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Classification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IgnitionTemperature = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IgnitionTemperatureUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreReceiptContainers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreReceiptContainers_Containers_ContainerId",
                        column: x => x.ContainerId,
                        principalSchema: "basicInfo",
                        principalTable: "Containers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreReceiptContainers_StoreReceiptHeads_StoreReceiptHeadId",
                        column: x => x.StoreReceiptHeadId,
                        principalSchema: "doc",
                        principalTable: "StoreReceiptHeads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoreReceiptGoods",
                schema: "doc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreReceiptHeadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommodityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PackageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoBrandName = table.Column<bool>(type: "bit", nullable: false),
                    PackageQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GrossWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Volume = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsHeavy = table.Column<bool>(type: "bit", nullable: false),
                    IsNonPalletized = table.Column<bool>(type: "bit", nullable: false),
                    IsDamaged = table.Column<bool>(type: "bit", nullable: false),
                    IsVoluminous = table.Column<bool>(type: "bit", nullable: false),
                    IsDangerous = table.Column<bool>(type: "bit", nullable: false),
                    DangerousNotNoticed = table.Column<bool>(type: "bit", nullable: false),
                    DangerousCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Classification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IgnitionTemperature = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IgnitionTemperatureUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreReceiptGoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreReceiptGoods_Commodities_CommodityId",
                        column: x => x.CommodityId,
                        principalSchema: "basicInfo",
                        principalTable: "Commodities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoreReceiptGoods_Packages_PackageId",
                        column: x => x.PackageId,
                        principalSchema: "basicInfo",
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoreReceiptGoods_StoreReceiptHeads_StoreReceiptHeadId",
                        column: x => x.StoreReceiptHeadId,
                        principalSchema: "doc",
                        principalTable: "StoreReceiptHeads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoreReceiptContainerGoods",
                schema: "doc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreReceiptContainerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommodityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PackageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoBrandName = table.Column<bool>(type: "bit", nullable: false),
                    PackageQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GrossWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Volume = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsHeavy = table.Column<bool>(type: "bit", nullable: false),
                    IsNonPalletized = table.Column<bool>(type: "bit", nullable: false),
                    IsDamaged = table.Column<bool>(type: "bit", nullable: false),
                    IsVoluminous = table.Column<bool>(type: "bit", nullable: false),
                    IsDangerous = table.Column<bool>(type: "bit", nullable: false),
                    DangerousNotNoticed = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreReceiptContainerGoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreReceiptContainerGoods_Commodities_CommodityId",
                        column: x => x.CommodityId,
                        principalSchema: "basicInfo",
                        principalTable: "Commodities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoreReceiptContainerGoods_Packages_PackageId",
                        column: x => x.PackageId,
                        principalSchema: "basicInfo",
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoreReceiptContainerGoods_StoreReceiptContainers_StoreReceiptContainerId",
                        column: x => x.StoreReceiptContainerId,
                        principalSchema: "doc",
                        principalTable: "StoreReceiptContainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateIndex(
            //    name: "IX_TerminalDischarges_CargoTypeId",
            //    schema: "operation",
            //    table: "TerminalDischarges",
            //    column: "CargoTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Gates_DeclarationId",
                schema: "operation",
                table: "Gates",
                column: "DeclarationId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreReceiptContainerGoods_CommodityId",
                schema: "doc",
                table: "StoreReceiptContainerGoods",
                column: "CommodityId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreReceiptContainerGoods_PackageId",
                schema: "doc",
                table: "StoreReceiptContainerGoods",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreReceiptContainerGoods_StoreReceiptContainerId",
                schema: "doc",
                table: "StoreReceiptContainerGoods",
                column: "StoreReceiptContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreReceiptContainers_ContainerId",
                schema: "doc",
                table: "StoreReceiptContainers",
                column: "ContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreReceiptContainers_StoreReceiptHeadId",
                schema: "doc",
                table: "StoreReceiptContainers",
                column: "StoreReceiptHeadId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreReceiptGoods_CommodityId",
                schema: "doc",
                table: "StoreReceiptGoods",
                column: "CommodityId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreReceiptGoods_PackageId",
                schema: "doc",
                table: "StoreReceiptGoods",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreReceiptGoods_StoreReceiptHeadId",
                schema: "doc",
                table: "StoreReceiptGoods",
                column: "StoreReceiptHeadId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreReceiptHeads_ArrivalTypeId",
                schema: "doc",
                table: "StoreReceiptHeads",
                column: "ArrivalTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreReceiptHeads_CargoTypeId",
                schema: "doc",
                table: "StoreReceiptHeads",
                column: "CargoTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreReceiptHeads_ConsigneeId",
                schema: "doc",
                table: "StoreReceiptHeads",
                column: "ConsigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreReceiptHeads_ConsigneeRepId",
                schema: "doc",
                table: "StoreReceiptHeads",
                column: "ConsigneeRepId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreReceiptHeads_CreatorId",
                schema: "doc",
                table: "StoreReceiptHeads",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreReceiptHeads_DeclarationId",
                schema: "doc",
                table: "StoreReceiptHeads",
                column: "DeclarationId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreReceiptHeads_StoreReceiptStateId",
                schema: "doc",
                table: "StoreReceiptHeads",
                column: "StoreReceiptStateId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreReceiptHeads_TrafficId",
                schema: "doc",
                table: "StoreReceiptHeads",
                column: "TrafficId");

            migrationBuilder.CreateIndex(
                name: "IX_WeightBridges_DeclarationId",
                schema: "operation",
                table: "WeightBridges",
                column: "DeclarationId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_TerminalDischarges_CargoTypes_CargoTypeId",
            //    schema: "operation",
            //    table: "TerminalDischarges",
            //    column: "CargoTypeId",
            //    principalSchema: "basicInfo",
            //    principalTable: "CargoTypes",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TerminalDischarges_CargoTypes_CargoTypeId",
                schema: "operation",
                table: "TerminalDischarges");

            migrationBuilder.DropTable(
                name: "Gates",
                schema: "operation");

            migrationBuilder.DropTable(
                name: "StoreReceiptContainerGoods",
                schema: "doc");

            migrationBuilder.DropTable(
                name: "StoreReceiptGoods",
                schema: "doc");

            migrationBuilder.DropTable(
                name: "WeightBridges",
                schema: "operation");

            migrationBuilder.DropTable(
                name: "StoreReceiptContainers",
                schema: "doc");

            migrationBuilder.DropTable(
                name: "StoreReceiptHeads",
                schema: "doc");

            migrationBuilder.DropTable(
                name: "ArrivalTypes",
                schema: "basicInfo");

            migrationBuilder.DropTable(
                name: "StoreReceiptStates",
                schema: "basicInfo");

            migrationBuilder.DropIndex(
                name: "IX_TerminalDischarges_CargoTypeId",
                schema: "operation",
                table: "TerminalDischarges");

            migrationBuilder.DropColumn(
                name: "IpasTerminalDischargeId",
                schema: "operation",
                table: "TerminalDischarges");

            migrationBuilder.DropColumn(
                name: "IpasTerminalDischargeReceivedAt",
                schema: "operation",
                table: "TerminalDischarges");

            migrationBuilder.AlterColumn<int>(
                name: "TerminalCode",
                schema: "operation",
                table: "TerminalDischarges",
                type: "int",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4);

            migrationBuilder.AlterColumn<float>(
                name: "IgnitionTemperature",
                schema: "operation",
                table: "TerminalDischarges",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddForeignKey(
                name: "FK_TerminalDischarges_CargoTypes_StoreId",
                schema: "operation",
                table: "TerminalDischarges",
                column: "StoreId",
                principalSchema: "basicInfo",
                principalTable: "CargoTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
