using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TDM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addstoreOperation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StoreReceiptOperations",
                schema: "doc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreReceiptHeadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreReceiptContainerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OperationTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PackNb = table.Column<long>(type: "bigint", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Volume = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsNonPalletized = table.Column<bool>(type: "bit", nullable: false),
                    IsDamaged = table.Column<bool>(type: "bit", nullable: false),
                    IsVoluminous = table.Column<bool>(type: "bit", nullable: false),
                    IsDangerous = table.Column<bool>(type: "bit", nullable: false),
                    DangerousCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Classification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IgnitionTemperature = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IgnitionTemperatureUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreReceiptOperations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreReceiptOperations_OperationTypes_OperationTypeId",
                        column: x => x.OperationTypeId,
                        principalSchema: "basicInfo",
                        principalTable: "OperationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoreReceiptOperations_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalSchema: "basicInfo",
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoreReceiptOperations_StoreReceiptContainers_StoreReceiptContainerId",
                        column: x => x.StoreReceiptContainerId,
                        principalSchema: "doc",
                        principalTable: "StoreReceiptContainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoreReceiptOperations_StoreReceiptHeads_StoreReceiptHeadId",
                        column: x => x.StoreReceiptHeadId,
                        principalSchema: "doc",
                        principalTable: "StoreReceiptHeads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoreReceiptOperations_Stores_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "basicInfo",
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StoreReceiptOperations_OperationTypeId",
                schema: "doc",
                table: "StoreReceiptOperations",
                column: "OperationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreReceiptOperations_ServiceId",
                schema: "doc",
                table: "StoreReceiptOperations",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreReceiptOperations_StoreId",
                schema: "doc",
                table: "StoreReceiptOperations",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreReceiptOperations_StoreReceiptContainerId",
                schema: "doc",
                table: "StoreReceiptOperations",
                column: "StoreReceiptContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreReceiptOperations_StoreReceiptHeadId",
                schema: "doc",
                table: "StoreReceiptOperations",
                column: "StoreReceiptHeadId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoreReceiptOperations",
                schema: "doc");
        }
    }
}
