using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExternalIntegration.Service.Migrations
{
    /// <inheritdoc />
    public partial class addVesselLoadingList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LoadingPermits",
                table: "LoadingPermits");

            migrationBuilder.AddColumn<int>(
                name: "ArrivalType",
                table: "StoreReceipts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDate",
                table: "StoreReceipts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GoodClassification",
                table: "StoreReceipts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocalNo",
                table: "StoreReceipts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrackingId",
                table: "StoreReceipts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VoyageNoticeNo",
                table: "StoreReceipts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SerialNo",
                table: "LoadingPermits",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "InternalId",
                table: "LoadingPermits",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "LoadingPermits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoadingPermits",
                table: "LoadingPermits",
                column: "InternalId");

            migrationBuilder.CreateTable(
                name: "StoreReceiptManifestItems",
                columns: table => new
                {
                    StoreReceiptId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BillOfLadingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreReceiptManifestItems", x => new { x.StoreReceiptId, x.BillOfLadingId });
                    table.ForeignKey(
                        name: "FK_StoreReceiptManifestItems_StoreReceipts_StoreReceiptId",
                        column: x => x.StoreReceiptId,
                        principalTable: "StoreReceipts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VesselLoadingLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TerminalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Port = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PortCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Voyage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Permits = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VesselLoadingLists", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoadingPermits_Id_ExpirationDate",
                table: "LoadingPermits",
                columns: new[] { "Id", "ExpirationDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoreReceiptManifestItems_BillOfLadingId_StoreReceiptId",
                table: "StoreReceiptManifestItems",
                columns: new[] { "BillOfLadingId", "StoreReceiptId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoreReceiptManifestItems");

            migrationBuilder.DropTable(
                name: "VesselLoadingLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoadingPermits",
                table: "LoadingPermits");

            migrationBuilder.DropIndex(
                name: "IX_LoadingPermits_Id_ExpirationDate",
                table: "LoadingPermits");

            migrationBuilder.DropColumn(
                name: "ArrivalType",
                table: "StoreReceipts");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "StoreReceipts");

            migrationBuilder.DropColumn(
                name: "GoodClassification",
                table: "StoreReceipts");

            migrationBuilder.DropColumn(
                name: "LocalNo",
                table: "StoreReceipts");

            migrationBuilder.DropColumn(
                name: "TrackingId",
                table: "StoreReceipts");

            migrationBuilder.DropColumn(
                name: "VoyageNoticeNo",
                table: "StoreReceipts");

            migrationBuilder.DropColumn(
                name: "InternalId",
                table: "LoadingPermits");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "LoadingPermits");

            migrationBuilder.AlterColumn<int>(
                name: "SerialNo",
                table: "LoadingPermits",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoadingPermits",
                table: "LoadingPermits",
                column: "Id");
        }
    }
}
